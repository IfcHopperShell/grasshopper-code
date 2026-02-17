import ifcopenshell.api.root

# Set default values
if Ct == None:
    Ct = "Model"

if Ci == None:
    Ci = "Body"

if Tv == None:
    Tv = "MODEL_VIEW"

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Subcotext
if PCId != None:
    parent = model.by_id(PCId)
    context = ifcopenshell.api.context.add_context(model, context_type=Ct,
        context_identifier=Ci, target_view=Tv, parent=parent)

# Context
else:
    context = ifcopenshell.api.context.add_context(model, context_type=Ct,
        context_identifier=Ci, target_view=Tv)

CId = context.id()

# Save model
Mo = model