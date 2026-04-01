import ifcopenshell

def ifc_read_component(file_path: str) -> tuple[ifcopenshell.file, str]:
    """
    Reads an IFC file and returns the model object and its schema.

    Args:
        file_path (str): The absolute or relative path to the .ifc file.

    Returns:
        Tuple[ifcopenshell.file, str]: A tuple containing:
            - model: The loaded ifcopenshell file object.
            - schema_version: The IFC schema ('IFC2X3', 'IFC4' or 'IFC4X3').

    Raises:
        FileNotFoundError: If the file does not exist at the provided path.
        OSError: If the file is corrupted or not a valid IFC format.
    """

    # Get model from file path
    model = ifcopenshell.open(file_path)
    
    # Get schema version
    schema_version = model.schema
    
    return model, schema_version
