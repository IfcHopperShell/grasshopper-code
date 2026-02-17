import ifcopenshell.api.root

# Set default values
if N == None:
    N = ["Hopper Building"]

# Intialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initialize empty arrays
BId = []

# Create buildings (one per name)
for i in range(len(N)):
    building = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuilding", name=N[i])
    relating_object = model.by_id(ROId)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[building])

    BId.append(int(building.id()))

# Save model
Mo = model