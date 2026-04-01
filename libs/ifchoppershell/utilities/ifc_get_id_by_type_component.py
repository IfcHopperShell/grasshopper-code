import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_get_id_by_type_component(
		model: ifcopenshell.file,
		ifc_types: list[str]
	) -> list[int]:
	"""
	Returns a list of lists containing the IDs of IFC objects for each specified type.

	Args:
		model (ifcopenshell.file): The IFC model to query.
		ifc_types (list[str]): A list of IFC type names to search for in the model.

	Returns:
		list[int]: A list of lists, where each inner list contains the IDs of IFC objects corresponding to the specified types.
	"""

	# Initialize empty arrays
	ifc_objects = []
	id_list = []

	for i_type in ifc_types:
		try:
			ifc_objects.append(model.by_type(i_type))
		except:
			ghenv.Component.AddRuntimeMessage(w, f"Type {i_type} not found in schema")

	for i in range(len(ifc_objects)):

		if len(ifc_objects[i]) == 0:
			ghenv.Component.AddRuntimeMessage(w, f"No object of type {ifc_types[i]} was found")

		id_list.append([])

		for j in ifc_objects[i]:
			id_list[i].append(int(j.id()))

	step_id = th.list_to_tree(id_list)

	return step_id