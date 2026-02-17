import ifcopenshell.api.root

# Set default values
if N == None:
    N = ["Hopper Site"]

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initalize empty array
SId = []

# Create sites (one per name)
for i in range(len(N)):
    site = ifcopenshell.api.root.create_entity(model, ifc_class="IfcSite", name=N[i])
    relating_object = model.by_id(ROId)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[site])

    SId.append(int(site.id()))

# Save model
Mo = model