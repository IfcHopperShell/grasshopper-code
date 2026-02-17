import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Set default values
if N == None:
    N = "Hopper Pset"

if K != None:
    K = [K] * len(ObId)

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initialize empty arrays
products = []
psets = []
PsetId = []

values_list = []

properties_list = []

# Validate values
if K != None and V.BranchCount != 0:
    values_list = th.tree_to_list(V)
    
    if V.BranchCount == 1:
        values_list = [values_list] * len(ObId)

    elif V.BranchCount != len(ObId):
        ghenv.Component.AddRuntimeMessage(w, "Values tree branch count must be one, or match the length of the Ifc Object Id array.")

    for value in values_list:
        if len(value) != len(K[0]):
            ghenv.Component.AddRuntimeMessage(w, "The number of values has to match the number of keys, for each branch.")

# Create Pset, associate properties and objects
for object_index in range(len(ObId)):

    # Get object
    products.append( model.by_id(ObId[object_index]) )

    # Add Pset
    psets.append( ifcopenshell.api.pset.add_pset(model, product=products[object_index], name=N) )

    # Add properties to Pset
    if K != None and V.BranchCount != 0:
        properties_list.append({})

        # values is a tree with a number of branches that matches the number of objetcs and a number of leafs that match the number of keys
        for i in range(len(K[0])):
            properties_list[object_index][K[object_index][i]] = values_list[object_index][i]

        ifcopenshell.api.pset.edit_pset(model, pset=psets[object_index], properties=properties_list[object_index])

    PsetId.append(int(psets[object_index].id()))

# Save model
Mo = model