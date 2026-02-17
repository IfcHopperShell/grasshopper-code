import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initialize empty arrays
ifc_objects = []

keys_list = []
values_list = []

for s_id in StepId:
    try:
        object_info = model.by_id(s_id).get_info()
        keys_list.append(list(object_info.keys()))
        values_list.append(list(object_info.values()))
    except:
        ghenv.Component.AddRuntimeMessage(w, f"No object was found with Id {s_id}")

K = th.list_to_tree(keys_list)
V = th.list_to_tree(values_list)