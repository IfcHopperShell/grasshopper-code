import ifcopenshell
import Grasshopper.Kernel as gh
import Rhino.Geometry as rg
from Grasshopper import DataTree
import ghpythonlib.treehelpers as th

from ..helpers import ghtrees

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_object_component(
		model: ifcopenshell.file,
		name: list[list[str]],
		relating_object_id: list[list[int]],
		context_id: list[list[int]],
		ifc_class: list[list[str]],
		mesh: list[list[rg.Mesh]],
		style_id: list[list[int]],
		component: gh.GH_Component
	) -> tuple[ifcopenshell.file, list[list[int]]]:
	
	# Set default values
	# Relating Object Id
	# If it does not have the same shape of name
	if not ghtrees.have_trees_same_shape(name, relating_object_id):

		# if it only has one element
		if relating_object_id.BranchCount == 1 and len(relating_object_id.Branch(relating_object_id.Paths[0])) == 1:

			# Use the first element
			first_element = relating_object_id.Branch(relating_object_id.Paths[0])[0]

			relating_object_id = DataTree[object]()

			for path in name.Paths:
				original_branch_data = name.Branch(path)
				new_data = [first_element] * len(original_branch_data)
				relating_object_id.AddRange(new_data, path)
		else:
			
			# Use the first element
			first_element = relating_object_id.Branch(relating_object_id.Paths[0])[0]

			relating_object_id = DataTree[object]()

			for path in name.Paths:
				original_branch_data = name.Branch(path)
				new_data = [first_element] * len(original_branch_data)
				relating_object_id.AddRange(new_data, path)

			# And warn the user
			component.AddRuntimeMessage(w, "Relating Object Id can either contain one element or have the same shape of the Name tree.")

	# Context Id
	# If it does not have the same shape of name
	if not ghtrees.have_trees_same_shape(name, context_id):

		# if it only has one element
		if context_id.BranchCount == 1 and len(context_id.Branch(context_id.Paths[0])) == 1:

			# Use the first element
			first_element = context_id.Branch(context_id.Paths[0])[0]

			context_id = DataTree[object]()

			for path in name.Paths:
				original_branch_data = name.Branch(path)
				new_data = [first_element] * len(original_branch_data)
				context_id.AddRange(new_data, path)
		else:
			
			# Use the first element
			first_element = context_id.Branch(context_id.Paths[0])[0]

			context_id = DataTree[object]()

			for path in name.Paths:
				original_branch_data = name.Branch(path)
				new_data = [first_element] * len(original_branch_data)
				context_id.AddRange(new_data, path)

			# And warn the user
			component.AddRuntimeMessage(w, "Context Id can either contain one element or have the same shape of the Name tree.")

	# Class
	# If it's empty or does not have the same shape of name
	if ifc_class.BranchCount == 0 or not ghtrees.have_trees_same_shape(name, ifc_class):
		
		# If it't not empty warn the user
		if (ifc_class.BranchCount != 0):
			component.AddRuntimeMessage(w, "Class can either be empty or the same shape of the Name tree.\nThe default \"IfcBuildingElementProxy\" will be used for all objects.")

		# In any case ignore the malformed input and set it to "IfcBuildingElementProxy"
		ifc_class = DataTree[object]()

		for path in name.Paths:
			original_branch_data = name.Branch(path)
			new_data = ["IfcBuildingElementProxy"] * len(original_branch_data)
			ifc_class.AddRange(new_data, path)

	# Mesh
	# If it's empty or does not have the same shape of name
	if mesh.BranchCount == 0 or not ghtrees.have_trees_same_shape(name, mesh):

		# If it's not empty warn the user
		if (mesh.BranchCount != 0):
			component.AddRuntimeMessage(w, "Mesh can either be empty or the same shape of the Name tree.\nObjects will have no mesh.")

		# In any case ignore the malformed input and set it to None
		mesh = DataTree[object]()

		for path in name.Paths:
			original_branch_data = name.Branch(path)
			new_data = [None] * len(original_branch_data)
			mesh.AddRange(new_data, path)

	# Style
    # If it's empty or does not have the same shape of name
	if style_id.BranchCount == 0 or not ghtrees.have_trees_same_shape(name, style_id):

		# If it's not empty warn the user
		if (style_id.BranchCount != 0):
			component.AddRuntimeMessage(w, "Style Id can either be empty or the same shape of the Name tree.\nObjects will have no style.")

		# In any case ignore the malformed input and set it to None
		style_id = DataTree[object]()

		for path in name.Paths:
			original_branch_data = name.Branch(path)
			new_data = [None] * len(original_branch_data)
			style_id.AddRange(new_data, path)

	# Initialize model
	model = ifcopenshell.file.from_string(model.to_string())

	# Initialize empty arrays
	object_id_list = []

	# Create objects
	for i in range(len(name.Paths)):
		name_branch = name.Branch(name.Paths[i])
		relating_object_id_branch = relating_object_id.Branch(name.Paths[i])
		context_id_branch = context_id.Branch(name.Paths[i])
		ifc_class_branch = ifc_class.Branch(name.Paths[i])
		mesh_branch = mesh.Branch(name.Paths[i])
		style_id_branch = style_id.Branch(name.Paths[i])

		object_id_list.append([])

		for j in range(len(name_branch)):

			# Get spatial structure and context
			relating_object = model.by_id(relating_object_id_branch[j])
			context = model.by_id(context_id_branch[j])

			# Create entity
			ifc_object = ifcopenshell.api.root.create_entity(model, ifc_class=ifc_class_branch[j], name=name_branch[j] )
			ifcopenshell.api.geometry.edit_object_placement(model, product=ifc_object)

			# Relating object
			ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[ifc_object])

			object_id_list[i].append(ifc_object.id())
            
			# If there is a mesh
			if(mesh_branch != None and mesh_branch[j] != None):

				vertices = []
				faces = []

				# Get vertex positions
				# for vertex in list(mesh_branch[j].Vertices):
				#     vertices.append((vertex.X, vertex.Y, vertex.Z))
				vertices = [(vertex.X, vertex.Y, vertex.Z) for vertex in mesh_branch[j].Vertices]

				# Build quad or tri faces
				for face in list(mesh_branch[j].Faces):
					if face.IsTriangle:
						faces.append((face.A, face.B, face.C))
					else:
						faces.append((face.A, face.B, face.C,face.D))

				# Geometric representation
				representation = ifcopenshell.api.geometry.add_mesh_representation(model, context=context, vertices=[vertices], faces=[faces])
				ifcopenshell.api.geometry.assign_representation(model, product=ifc_object, representation=representation)

				# Style representation
				if (style_id_branch[j] != None):
					style = model.by_id(style_id_branch[j])
					ifcopenshell.api.style.assign_representation_styles(model, shape_representation=representation, styles=[style])

	object_id = th.list_to_tree(object_id_list)

	return model, object_id
