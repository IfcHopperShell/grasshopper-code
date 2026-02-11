import ifcopenshell
from pathlib import Path

# Set default values
if folder == None:
    folder = str(Path.home() / "IfcHopperShell") + "\\"

if file_name == None:
    file_name = "Hopper File"

if write == None:
    write = False

# Set out path
out_path = folder + file_name + ".ifc"

# Write file
if write:
    model_in.write(out_path)