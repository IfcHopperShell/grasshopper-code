import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Set default values
if N == None:
    N = "Hopper Qto"

if K != None:
    K = [K] * len(ObId)

if Qt == None:
    Qt = ["Length"] * len(ObId)

elif len(Qt) == 1:
    Qt = Qt * len(ObId)

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initialize empty arrays
products = []
qtos = []
QtoId = []

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

# Create Qto, associate properties and objects
for object_index in range(len(ObId)):

    # Get object
    products.append( model.by_id(ObId[object_index]) )

    # Add Qto
    qtos.append( ifcopenshell.api.pset.add_qto(model, product=products[object_index], name=N) )

    # Add properties to Qto
    if K != None:
        properties_list.append({})

        # values is a tree with a number of branches that matches the number of objetcs and a number of leafs that match the number of keys
        
        for i in range(len(K[0])):
            if len(values_list) > 0:

                if Qt[i] == "Length":
                    properties_list[object_index][K[object_index][i]] = model.createIfcLengthMeasure(values_list[object_index][i])

                elif Qt[i] == "Numeric":
                    properties_list[object_index][K[object_index][i]] = model.createIfcNumericMeasure(values_list[object_index][i])

                elif Qt[i] == "Area":
                    properties_list[object_index][K[object_index][i]] = model.createIfcAreaMeasure(values_list[object_index][i])

                elif Qt[i] == "Volume":
                    properties_list[object_index][K[object_index][i]] = model.createIfcVolumeMeasure(values_list[object_index][i])
                
                elif Qt[i] == "Count":
                    properties_list[object_index][K[object_index][i]] = model.createIfcCountMeasure(values_list[object_index][i])

                elif Qt[i] == "Time":
                    properties_list[object_index][K[object_index][i]] = model.createIfcTimeMeasure(values_list[object_index][i])

            else:
                properties_list[object_index][K[object_index][i]] = None

        print(properties_list[object_index])
        ifcopenshell.api.pset.edit_qto(model, qto=qtos[object_index], properties=properties_list[object_index])

    QtoId.append(int(qtos[object_index].id()))

# Save model
Mo = model