import ifcopenshell
from pathlib import Path

# Set default values
if D == None:
    D = str(Path.home() / "IfcHopperShell") + "\\"

if Fn == None:
    Fn = "Hopper File"

if W == None:
    W = False

# Set out path
out_path = D + Fn + ".ifc"

# Write file
if W:
    Mi.W(FP)