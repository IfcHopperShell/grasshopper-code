import ifcopenshell.api.root

# Set default values
if name == None:
    name = ["Hopper Site"]

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Initalize empty array
site_id = []

# Create sites (one per name)
for i in range(len(name)):
    site = ifcopenshell.api.root.create_entity(model, ifc_class="IfcSite", name=name[i])
    relating_object = model.by_id(relating_object_id)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[site])

    site_id.append(int(site.id()))

# Save model
model_out = model