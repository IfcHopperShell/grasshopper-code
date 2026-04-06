import ifcopenshell.api.root

def ifc_site_component(
		model: ifcopenshell.file,
		relating_object_id: int,
		names: list[str] = ["Hopper Site"]
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates IfcSite entities and relates them to a specified IfcRelAggregates entity.

	Args:
		model (ifcopenshell.file): The IFC model to which the IfcSite entities will be added.
		relating_object_id (int): The ID of the IfcRelAggregates entity to which the IfcSite entities will be related.
		names (list[str], optional): A list of names for the IfcSite entities. Defaults to ["Hopper Site"].

	Returns:
		tuple[ifcopenshell.file, list[int]]: A tuple containing the modified IFC model and a list of IDs of the created IfcSite entities.
	"""
	
	# Set default values
	if names == None:
		names = ["Hopper Site"]
	
	# Initalize empty array
	site_ids = []

	# Initialize new model because we don't want to modify the input model
	model = ifcopenshell.file.from_string(model.to_string())

	# Create sites (one per name)
	for name in names:
		site = ifcopenshell.api.root.create_entity(model, ifc_class="IfcSite", name=name)
		relating_object = model.by_id(relating_object_id)
		ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[site])
		site_ids.append(int(site.id()))

	return model, site_ids
