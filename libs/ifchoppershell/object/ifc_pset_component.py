import ifcopenshell
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_pset_component(
		model: ifcopenshell.file,
		object_ids: list[int],
		name: str,
		keys: list[str],
		values: list[list[any]],
		component: gh.GH_Component
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates a property set (Pset) for a list of Ifc objects, and associates it with the objects. Optionally, properties can be added to the Pset.

	Args:
		model (ifcopenshell.file): The Ifc model to which the Pset will
		object_ids (list[int]): A list of Ifc object ids, to which the Pset will be associated.
		name (str, optional): The name of the Pset. Defaults to "Hopper Pset".
		keys (list[str], optional): A list of property names to be added to the Pset. If not provided, no properties will be added. Defaults to None.
		values (gh.DataTree[object], optional): A tree of property values to be added to the Pset. The tree must have a number of branches that matches the number of object ids, and a number of leafs in each branch that matches the number of keys. If not provided, properties will be added with null values. Defaults to None.

	Returns:
		tuple[ifcopenshell.file, list[int]]: The updated Ifc model and a list of the created Pset ids.
	"""

	# Set default values
	if name == None:
		name = "Hopper Pset"

	if keys != None:
		keys = [keys] * len(object_ids)

	# Initialize model
	model = ifcopenshell.file.from_string(model.to_string())

	# Initialize empty arrays
	products = []
	psets = []
	pset_id = []

	values_list = []

	properties_list = []

	# Validate values
	if keys != None and values.BranchCount != 0:
		values_list = th.tree_to_list(values)
		
		if values.BranchCount == 1:
			values_list = [values_list] * len(object_ids)

		elif values.BranchCount != len(object_ids):
			component.AddRuntimeMessage(w, "Values tree branch count must be one, or match the length of the Ifc Object Id array.")

		for value in values_list:
			if len(value) != len(keys[0]):
				component.AddRuntimeMessage(w, "The number of values has to match the number of keys, for each branch.")

	# Create Pset, associate properties and objects
	for object_index in range(len(object_ids)):

		# Get object
		products.append( model.by_id(object_ids[object_index]) )

		# Add Pset
		psets.append( ifcopenshell.api.pset.add_pset(model, product=products[object_index], name=name) )

		# Add properties to Pset
		if keys != None and values.BranchCount != 0:
			properties_list.append({})

			# values is a tree with a number of branches that matches the number of objetcs and a number of leafs that match the number of keys
			for i in range(len(keys[0])):
				properties_list[object_index][keys[object_index][i]] = values_list[object_index][i]

			ifcopenshell.api.pset.edit_pset(model, pset=psets[object_index], properties=properties_list[object_index])

		pset_id.append(int(psets[object_index].id()))

	return model, pset_id
