import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_get_info_by_id_component(
		model: ifcopenshell.file,
		step_ids: list[int]
	) -> tuple[list[int], list[int]]:
	"""
	Returns a tuple containing lists of keys and values for IFC objects identified by their IDs.

	Args:
		model (ifcopenshell.file): The IFC model to query.
		step_ids (list[int]): A list of IDs to search for in the model.

	Returns:
		tuple[list[int], list[int]]: A tuple containing two lists: one with the keys and one with the values from the object info.
	"""

	# Initialize empty arrays
	ifc_objects = []

	keys_list = []
	values_list = []

	for s_id in step_ids:
		try:
			object_info = model.by_id(s_id).get_info()
			keys_list.append(list(object_info.keys()))
			values_list.append(list(object_info.values()))
		except:
			ghenv.Component.AddRuntimeMessage(w, f"No object was found with Id {s_id}")

	keyes = th.list_to_tree(keys_list)
	values = th.list_to_tree(values_list)

	return keyes, values