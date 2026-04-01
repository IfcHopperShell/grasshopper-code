import ifcopenshell.api.root

def ifc_building_storey_component(
		model: ifcopenshell.file,
		relating_object_id: int,
		names: list[str] = ["Hopper Storey"]
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates IfcBuildingStorey components in the IFC model.

	Args:
		model (ifcopenshell.file): The IFC model.
		relating_object_id (int): The ID of the relating object.
		names (list[str]): A list of names for the building storeys to create.

	Returns:
		tuple[ifcopenshell.file, list[int]]: A tuple containing the updated model and a list of the IDs of the created building storeys.
	"""
    
	# Set default values
	if names == None:
		names = ["Hopper Storey"]

	# Intialize model
	model = ifcopenshell.file.from_string(model.to_string())

	# Initialize empty arrays
	storey_ids = []

	# Create buildings (one per name)
	for name in names:
		storey = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuildingStorey", name=name)
		relating_object = model.by_id(relating_object_id)
		ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[storey])

		storey_ids.append(int(storey.id()))

	return model, storey_ids