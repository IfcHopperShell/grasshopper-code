import ifcopenshell.api.root
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Initialize model
model = ifcopenshell.open(file_path)

schema_version = model.schema

# Save model
model_out = model