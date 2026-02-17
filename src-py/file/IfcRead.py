import ifcopenshell.api.root
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Initialize model
model = ifcopenshell.open(FP)

Sv = model.schema

# Save model
Mo = model