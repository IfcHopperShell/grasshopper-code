import ifcopenshell.api.root

# Set default values
if context_type == None:
    context_type = "Model"

if context_identifier == None:
    context_identifier = "Body"

if target_view == None:
    target_view = "MODEL_VIEW"

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Subcotext
if parent_context_id != None:
    parent = model.by_id(parent_context_id)
    context = ifcopenshell.api.context.add_context(model, context_type=context_type,
        context_identifier=context_identifier, target_view=target_view, parent=parent)

# Context
else:
    context = ifcopenshell.api.context.add_context(model, context_type=context_type,
        context_identifier=context_identifier, target_view=target_view)

context_id = context.id()

# Save model
model_out = model