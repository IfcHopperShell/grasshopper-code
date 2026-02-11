import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Initialize empty arrays
ifc_objects = []
id_list = []

for i_type in ifc_type:
    try:
        ifc_objects.append(model.by_type(i_type))
    except:
        ghenv.Component.AddRuntimeMessage(w, f"Type {i_type} not found in schema")

for i in range(len(ifc_objects)):

    if len(ifc_objects[i]) == 0:
        ghenv.Component.AddRuntimeMessage(w, f"No object of type {ifc_type[i]} was found")

    id_list.append([])

    for j in ifc_objects[i]:
        id_list[i].append(int(j.id()))

step_id = th.list_to_tree(id_list)