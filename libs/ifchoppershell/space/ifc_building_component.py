import ifcopenshell.api.root

def ifc_building_component(
		model: ifcopenshell.file,
		relating_object_id: int,
		names: list[str] = ["Hopper Building"]
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates IfcBuilding components in the IFC model.

	Args:
		model (ifcopenshell.file): The IFC model.
		relating_object_id (int): The ID of the relating object.
		names (list[str]): A list of names for the buildings to create.

	Returns:
		tuple[ifcopenshell.file, list[int]]: A tuple containing the updated model and a list of the IDs of the created buildings.
	"""

	# Set default values
	if names == None:
		names = ["Hopper Building"]

	# Intialize model
	model = ifcopenshell.file.from_string(model.to_string())

	# Initialize empty arrays
	building_ids = []

	# Create buildings
	for name in names:
		building = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuilding", name=name)
		relating_object = model.by_id(relating_object_id)
		ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[building])

		building_ids.append(int(building.id()))

	return model, building_ids