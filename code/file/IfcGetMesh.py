import multiprocessing
import ifcopenshell.api.root
import System.Drawing as sd
import Rhino
import ghpythonlib.treehelpers as th
import math

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Lists for storing output geometry and property sets
mesh = []
colors = []
step_id = []
pset_id_list = []
qto_id_list = []

# Configure geometry extraction settings and iterator for the IFC file
settings = ifcopenshell.geom.settings()
iterator = None
if include != None and len(include) > 0:
    iterator = ifcopenshell.geom.iterator(settings, model, multiprocessing.cpu_count(), include=include)
elif exclude != None and len(exclude) > 0:
    iterator = ifcopenshell.geom.iterator(settings, model, multiprocessing.cpu_count(), exclude=exclude)
else:
    iterator = ifcopenshell.geom.iterator(settings, model, multiprocessing.cpu_count())

# Iterate over all shapes in the IFC file
if iterator.initialize():
    while True:

        # Get the current shape (geometry chunk)
        shape = iterator.get()

        # Get transformation matrix
        matrix = ifcopenshell.util.shape.get_shape_matrix(shape)

        # Get materials
        materials = shape.geometry.materials
        alpha = 255
        if not math.isnan(materials[0].transparency):
            alpha = (1 - materials[0].transparency) * 255

        color = sd.Color.FromArgb(alpha, materials[0].diffuse.r()*255, materials[0].diffuse.g()*255, materials[0].diffuse.b()*255)

        colors.append(color)

        # Get grouped vertices and faces (as arrays)
        grouped_verts = ifcopenshell.util.shape.get_vertices(shape.geometry)
        grouped_faces = ifcopenshell.util.shape.get_faces(shape.geometry)
        
        # Mesh
        element_mesh = Rhino.Geometry.Mesh()

        vertices = []
        for vertex in grouped_verts:
            vertices.append(Rhino.Geometry.Point3d(vertex[0], vertex[1], vertex[2]))
            element_mesh.Vertices.Add(vertex[0], vertex[1], vertex[2])

        for face in grouped_faces:
            if len(face) == 3:
                element_mesh.Faces.AddFace(int(face[0]), int(face[1]), int(face[2]))
            elif len(face) == 4:
                element_mesh.Faces.AddFace(int(face[0]), int(face[1]), int(face[2]), int(face[3]))

        # Prepare Rhino transformation matrix
        rtsmatrix = Rhino.Geometry.Transform(1.0)

        rtsmatrix.M00 = matrix[0][0]
        rtsmatrix.M01 = matrix[0][1]
        rtsmatrix.M02 = matrix[0][2]
        rtsmatrix.M03 = matrix[0][3]
        rtsmatrix.M10 = matrix[1][0]
        rtsmatrix.M11 = matrix[1][1]
        rtsmatrix.M12 = matrix[1][2]
        rtsmatrix.M13 = matrix[1][3]
        rtsmatrix.M20 = matrix[2][0]
        rtsmatrix.M21 = matrix[2][1]
        rtsmatrix.M22 = matrix[2][2]
        rtsmatrix.M23 = matrix[2][3]
        rtsmatrix.M30 = matrix[3][0]
        rtsmatrix.M31 = matrix[3][1]
        rtsmatrix.M32 = matrix[3][2]
        rtsmatrix.M33 = matrix[3][3]

        element_mesh.Normals.ComputeNormals()
        element_mesh.Compact()
        element_mesh.Unweld(0, True)
        #mesh.Weld(Rhino.RhinoMath.ToRadians(90))

        element_mesh.Transform(rtsmatrix)

        # Append geometry and property set info for output
        mesh.append(element_mesh)

        # Retrieve the IFC element by its ID
        step_id.append(shape.id)

        element = model.by_id(shape.id)

        # Get Psets
        element_pset = []
        for pset in list(ifcopenshell.util.element.get_psets(element, psets_only=True)):
            element_pset.append(ifcopenshell.util.element.get_psets(element)[pset]["id"])

        # Get Qtos
        element_qto = []
        for qto in list(ifcopenshell.util.element.get_psets(element, qtos_only=True)):
            element_qto.append(ifcopenshell.util.element.get_psets(element)[qto]["id"])
    
        pset_id_list.append(element_pset)
        qto_id_list.append(element_qto)

        # Move to next shape in iterator
        if not iterator.next():
            break

pset_id = th.list_to_tree(pset_id_list)
qto_id = th.list_to_tree(qto_id_list)