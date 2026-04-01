import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_qto_component(
		model: ifcopenshell.file,
		object_ids: list[int],
		name: str=None,
		quantity: list[str]=None,
		keys: list[str]=None,
		values: gh.DataTree[object]=None	
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates a quantity takeoff (Qto) for a list of Ifc objects, and associates it with the objects. Optionally, properties can be added to the Qto.

	Args:
		model (ifcopenshell.file): The Ifc model to which the Qto will
		object_ids (list[int]): A list of Ifc object ids, to which the Qto will be associated.
		name (str, optional): The name of the Qto. Defaults to "Hopper Qto".
		quantity (list[str], optional): The quantity type for each Qto property. Can be "Length", "Area", "Volume", "Count" or "Time". Defaults to "Length" for all properties.
		keys (list[str], optional): A list of property names to be added to the Qto. If not provided, no properties will be added. Defaults to None.
		values (gh.DataTree[object], optional): A tree of property values to be added to the Qto. The tree must have a number of branches that matches the number of object ids, and a number of leafs in each branch that matches the number of keys. If not provided, properties will be added with null values. Defaults to None.

	Returns:
		tuple[ifcopenshell.file, list[int]]: The updated Ifc model and a list of the created Qto ids.
	"""

	# Set default values
	if name == None:
		name = "Hopper Qto"

	if keys != None:
		keys = [keys] * len(object_ids)

	if quantity == None:
		quantity = ["Length"] * len(object_ids)

	elif len(quantity) == 1:
		quantity = quantity * len(object_ids)

	# Initialize model
	model = ifcopenshell.file.from_string(model.to_string())

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
			values_list = [values_list] * len(object_ids)

		elif values.BranchCount != len(object_ids):
			ghenv.Component.AddRuntimeMessage(w, "Values tree branch count must be one, or match the length of the Ifc Object Id array.")

		for value in values_list:
			if len(value) != len(keys[0]):
				ghenv.Component.AddRuntimeMessage(w, "The number of values has to match the number of keys, for each branch.")

	# Create Qto, associate properties and objects
	for object_index in range(len(object_ids)):

		# Get object
		products.append( model.by_id(object_ids[object_index]) )

		# Add Qto
		qtos.append( ifcopenshell.api.pset.add_qto(model, product=products[object_index], name=name) )

		# Add properties to Qto
		if keys != None:
			properties_list.append({})

			# values is a tree with a number of branches that matches the number of objetcs and a number of leafs that match the number of keys
			
			for i in range(len(keys[0])):
				if len(values_list) > 0:

					if quantity[object_index] == "Length":
						properties_list[object_index][keys[object_index][i]] = model.createIfcLengthMeasure(values_list[object_index][i])

					elif quantity[object_index] == "Numeric":
						properties_list[object_index][keys[object_index][i]] = model.createIfcNumericMeasure(values_list[object_index][i])

					elif quantity[object_index] == "Area":
						properties_list[object_index][keys[object_index][i]] = model.createIfcAreaMeasure(values_list[object_index][i])

					elif quantity[object_index] == "Volume":
						properties_list[object_index][keys[object_index][i]] = model.createIfcVolumeMeasure(values_list[object_index][i])
					
					elif quantity[object_index] == "Count":
						properties_list[object_index][keys[object_index][i]] = model.createIfcCountMeasure(values_list[object_index][i])

					elif quantity[object_index] == "Time":
						properties_list[object_index][keys[object_index][i]] = model.createIfcTimeMeasure(values_list[object_index][i])

				else:
					properties_list[object_index][keys[object_index][i]] = None

			print(properties_list[object_index])
			ifcopenshell.api.pset.edit_qto(model, qto=qtos[object_index], properties=properties_list[object_index])

		qto_id.append(int(qtos[object_index].id()))

	return model, qto_id