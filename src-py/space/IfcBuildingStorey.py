import ifcopenshell.api.root

# Set default values
if N == None:
    N = ["Hopper Storey"]

# Intialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initialize empty arrays
StId = []

# Create buildings (one per name)
for i in range(len(N)):
    storey = ifcopenshell.api.root.create_entity(model, ifc_class="IfcBuildingStorey", name=N[i])
    relating_object = model.by_id(ROId)
    ifcopenshell.api.aggregate.assign_object(model, relating_object=relating_object, products=[storey])

    StId.append(int(storey.id()))

# Save model
Mo = model