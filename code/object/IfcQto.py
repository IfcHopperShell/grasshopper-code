import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Set default values
if name == None:
    name = "Hopper Qto"

if keys != None:
    keys = [keys] * len(ifc_object_id)

if quantity_type == None:
    quantity_type = ["Length"] * len(ifc_object_id)

elif len(quantity_type) == 1:
    quantity_type = quantity_type * len(ifc_object_id)

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Initialize empty arrays
products = []
qtos = []
qto_id = []

values_list = []

properties_list = []

# Validate values
if keys != None and values.BranchCount != 0:
    values_list = th.tree_to_list(values)
    
    if values.BranchCount == 1:
        values_list = [values_list] * len(ifc_object_id)

    elif values.BranchCount != len(ifc_object_id):
        ghenv.Component.AddRuntimeMessage(w, "Values tree branch count must be one, or match the length of the Ifc Object Id array.")

    for value in values_list:
        if len(value) != len(keys[0]):
            ghenv.Component.AddRuntimeMessage(w, "The number of values has to match the number of keys, for each branch.")

# Create Qto, associate properties and objects
for object_index in range(len(ifc_object_id)):

    # Get object
    products.append( model.by_id(ifc_object_id[object_index]) )

    # Add Qto
    qtos.append( ifcopenshell.api.pset.add_qto(model, product=products[object_index], name=name) )

    # Add properties to Qto
    if keys != None:
        properties_list.append({})

        # values is a tree with a number of branches that matches the number of objetcs and a number of leafs that match the number of keys
        
        for i in range(len(keys[0])):
            if len(values_list) > 0:

                if quantity_type[i] == "Length":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcLengthMeasure(values_list[object_index][i])

                elif quantity_type[i] == "Numeric":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcNumericMeasure(values_list[object_index][i])

                elif quantity_type[i] == "Area":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcAreaMeasure(values_list[object_index][i])

                elif quantity_type[i] == "Volume":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcVolumeMeasure(values_list[object_index][i])
                
                elif quantity_type[i] == "Count":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcCountMeasure(values_list[object_index][i])

                elif quantity_type[i] == "Time":
                    properties_list[object_index][keys[object_index][i]] = model.createIfcTimeMeasure(values_list[object_index][i])

            else:
                properties_list[object_index][keys[object_index][i]] = None

        print(properties_list[object_index])
        ifcopenshell.api.pset.edit_qto(model, qto=qtos[object_index], properties=properties_list[object_index])

    qto_id.append(int(qtos[object_index].id()))

# Save model
model_out = model