import ifcopenshell.api.root

# Set default values
if name == None:
    name = ["Hopper Storey"]

# Intialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Initialize empty arrays
storey_id = []

# Create buildings (one per name)
for i in range(len(name)):
    storey = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuildingStorey", name=name[i])
    relating_object = model.by_id(relating_object_id)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[storey])

    storey_id.append(int(storey.id()))

# Save model
model_out = model