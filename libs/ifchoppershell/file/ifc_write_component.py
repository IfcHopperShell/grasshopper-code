import ifcopenshell
from pathlib import Path

def ifc_write_component(
        model: ifcopenshell.file,
        folder: str,
        file_name: str,
        write: bool
    ) -> str:
    """
    Writes an IFC model to a specified location with a given file name.

    Args:
        model (ifcopenshell.file): The IFC model to be written to file.
        folder (str): The directory where the IFC file will be saved.
        file_name (str, optional): The name of the IFC file without extension. Defaults to "Hopper File".
        write (bool, optional): If True, the file will be written to disk. Defaults to False.

    Returns:
        str: The full path to the IFC file that would be written (or has been written if write=True).

    Raises:
        OSError: If there is an error writing the file to disk (e.g., permission issues, invalid path).
    """

    # Set default values
    if folder == None:
        folder = str(Path.home() / "IfcHopperShell") + "\\"

    if file_name == None:
        file_name = "Hopper File"

    if write == None:
        write = False

    # Set out path
    full_path = folder + file_name + ".ifc"

    # Write file
    if write:
        model.write(full_path)

    return full_path
