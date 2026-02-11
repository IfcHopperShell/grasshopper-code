import ifcopenshell.api.root

# Set default values
if name == None:
    name = ["Hopper Building"]

# Intialize model
model = ifcopenshell.file.from_string(model_in.to_string())

# Initialize empty arrays
building_id = []

# Create buildings (one per name)
for i in range(len(name)):
    building = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuilding", name=name[i])
    relating_object = model.by_id(relating_object_id)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[building])

    building_id.append(int(building.id()))

# Save model
model_out = model