import rhinoscriptsyntax as rs
import ifcopenshell.api.root
import Grasshopper.Kernel as gh
import Rhino.Geometry as rg
from Grasshopper import DataTree
import ghpythonlib.treehelpers as th

def have_trees_same_shape(tree1, tree2):
    """
    Compares two Grasshopper Data Trees to check if they have the same set of 
    branch paths AND the same number of items in each corresponding branch.
    
    Args:
        tree1 (GH_Structure): The first Data Tree.
        tree2 (GH_Structure): The second Data Tree.
        
    Returns:
        bool: True if both shape and counts are identical, False otherwise.
    """
    
    # 1. Check Path Count
    if tree1.BranchCount != tree2.BranchCount:
        return False

    # 2. Get and sort the paths for consistent iteration
    # We convert to string and sort to ensure we check the correct corresponding paths.
    paths_A = sorted([path.ToString() for path in tree1.Paths])
    paths_B = sorted([path.ToString() for path in tree2.Paths])

    # If the sorted path names are different, the shapes are not identical.
    if paths_A != paths_B:
        return False
        
    # 3. Check Element Counts for each branch
    # Since paths_A and paths_B are sorted and equal, we can iterate simultaneously.
    for path_str in paths_A:
        
        # Convert the string path back to a GH_Path object to access the branch data
        # Note: We can simplify this by using the original tree1.Paths and tree2.Paths 
        # and checking the counts while iterating, but converting to strings first 
        # guarantees a paired iteration. A dictionary lookup is cleaner.
        
        # A simpler way is to build a dictionary of {path_string: count}
        
        # Build dictionaries of {PathString: BranchItemCount}
        branch_map_A = {p.ToString(): tree1.Branch(p).Count for p in tree1.Paths}
        branch_map_B = {p.ToString(): tree2.Branch(p).Count for p in tree2.Paths}
        
        # Compare the counts using the path string as the key
        if branch_map_A[path_str] != branch_map_B[path_str]:
            # The count of items in this specific branch is different
            return False

    # If all paths matched and all corresponding branch counts matched, they are identical in structure
    return True

def isinstance_tree(data_tree, expected_type):
    """
    Checks every single element in a Grasshopper DataTree against a specified Python type.

    Args:
        data_tree (GH_Structure): The input Data Tree.
        expected_type (type): The target Python type (e.g., int, float, str).

    Returns:
        bool: True if every element is of the expected type, False otherwise.
    """
    
    # 1. Iterate through all the paths (branches) in the tree
    for path in data_tree.Paths:
        # 2. Get the list of items for the current branch
        branch_data = data_tree.Branch(path)
        
        # Handle the case of empty branches (they don't violate the type constraint)
        if not branch_data:
            continue
            
        # 3. Iterate through every item in the current branch
        for item in branch_data:
            # 4. Perform the type check
            if not isinstance(item, expected_type):
                # If any item fails the check, we can stop immediately and return False
                return False

    # 5. If the loops complete without returning False, all elements matched the type
    return True

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Set default values
# Relating Object Id
# If it does not have the same shape of name
if not have_trees_same_shape(name, relating_object_id):

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
        ghenv.Component.AddRuntimeMessage(w, "Relating Object Id can either contain one element or have the same shape of the Name tree.")

# Context Id
# If it does not have the same shape of name
if not have_trees_same_shape(name, context_id):

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
        ghenv.Component.AddRuntimeMessage(w, "Context Id can either contain one element or have the same shape of the Name tree.")

# Class
# If it's empty or does not have the same shape of name
if ifc_class.BranchCount == 0 or not have_trees_same_shape(name, ifc_class):
    
    # If it't not empty warn the user
    if (ifc_class.BranchCount != 0):
        ghenv.Component.AddRuntimeMessage(w, "Class can either be empty or the same shape of the Name tree.\nThe default \"IfcBuildingElementProxy\" will be used for all objects.")

    # In any case ignore the malformed input and set it to "IfcBuildingElementProxy"
    ifc_class = DataTree[object]()

    for path in name.Paths:
        original_branch_data = name.Branch(path)
        new_data = ["IfcBuildingElementProxy"] * len(original_branch_data)
        ifc_class.AddRange(new_data, path)

# Mesh
# If it's empty or does not have the same shape of name
if mesh.BranchCount == 0 or not have_trees_same_shape(name, mesh):

    # If it's not empty warn the user
    if (mesh.BranchCount != 0):
        ghenv.Component.AddRuntimeMessage(w, "Mesh can either be empty or the same shape of the Name tree.\nObjects will have no mesh.")

    # In any case ignore the malformed input and set it to None
    mesh = DataTree[object]()

    for path in name.Paths:
        original_branch_data = name.Branch(path)
        new_data = [None] * len(original_branch_data)
        mesh.AddRange(new_data, path)

# Style
# If it's empty
if style_id.BranchCount == 0:
    style_id = DataTree[object]()

    for path in name.Paths:
        original_branch_data = name.Branch(path)
        new_data = [None] * len(original_branch_data)
        style_id.AddRange(new_data, path)

# If it does not have the same shape of name
if not have_trees_same_shape(name, style_id):

    # if it only has one element
    if style_id.BranchCount == 1 and len(style_id.Branch(style_id.Paths[0])) == 1:

        # Use the first element
        first_element = style_id.Branch(style_id.Paths[0])[0]

        style_id = DataTree[object]()

        for path in name.Paths:
            original_branch_data = name.Branch(path)
            new_data = [first_element] * len(original_branch_data)
            style_id.AddRange(new_data, path)
    else:
        
        # Use the first element
        first_element = style_id.Branch(style_id.Paths[0])[0]

        style_id = DataTree[object]()

        for path in name.Paths:
            original_branch_data = name.Branch(path)
            new_data = [first_element] * len(original_branch_data)
            style_id.AddRange(new_data, path)

        # And warn the user
        ghenv.Component.AddRuntimeMessage(w, "Style Id can either contain one element or have the same shape of the Name tree.")

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

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
        if(mesh_branch[j]):

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

# Save model
model_out = model