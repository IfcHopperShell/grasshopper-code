import ifcopenshell.api.root

def ifc_context_component(
		model: ifcopenshell.file, 
		context_type: str = "Model",
		context_identifier: str = "Body",
		target_view: str = "MODEL_VIEW",
		parent_context_id: int = None
	) -> tuple[ifcopenshell.file, int]:
	"""
	Creates an IfcContext entity in the given IFC model.

	Args:
		model (ifcopenshell.file): The IFC model to which the IfcContext entity will be added.
		context_type (str, optional): The type of the context. Defaults to "Model".
		context_identifier (str, optional): The identifier for the context. Defaults to "Body".
		target_view (str, optional): The target view for the context. Defaults to "MODEL_VIEW".
		parent_context_id (int, optional): The ID of the parent context to which this context will be related. If None, the context will be created without a parent. Defaults to None.

	Returns:
		tuple[ifcopenshell.file, int]: A tuple containing the modified IFC model and the ID of the created IfcContext entity.
	"""

	# Set default values
	if context_type == None:
		context_type = "Model"

	if context_identifier == None:
		context_identifier = "Body"

	if target_view == None:
		target_view = "MODEL_VIEW"
	
	# Initialize new model because we don't want to modify the input model
	model = ifcopenshell.file.from_string(model.to_string())

	# Subcontext
	if parent_context_id is not None:
		parent = model.by_id(parent_context_id)
		context = ifcopenshell.api.context.add_context(model, context_type=context_type,
			context_identifier=context_identifier, target_view=target_view, parent=parent)
	
	# Context
	else:
		context = ifcopenshell.api.context.add_context(model, context_type=context_type,
			context_identifier=context_identifier, target_view=target_view)

	# Get ID of created context
	context_id = int(context.id())

	return model, context_id