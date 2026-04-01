import ifcopenshell.api.project
from datetime import datetime

def ifc_model_component(
        schema_version: str = "IFC4",
        name: str = "Hopper Model",
        description: str = "...",
        author_name: str = "...",
        author_surname: str = "...",
        authoring_organization: str = "...",
        authorization: str = "...",
    ) -> ifcopenshell.file:
    """
    Creates a new IFC model with the specified schema version and header information.

    Args:
        schema_version (str): The IFC schema version to use ('IFC2X3', 'IFC4' or 'IFC4X3'). Defaults to "IFC4".
        name (str): The name of the IFC file. Defaults to "Hopper Model".
        description (str): A description of the IFC file. Defaults to "...".
        author_name (str): The given name of the author. Defaults to "...".
        author_surname (str): The family name of the author. Defaults to "...".
        authoring_organization (str): The name of the organization responsible for authoring the file. Defaults to "...".
        authorization (str): The authorization information for the file. Defaults to "...".

    Returns:
        ifcopenshell.file: The created IFC model object.

    Raises:
        ValueError: If an invalid schema version is provided.
    """

    # Set default values
    if schema_version == None:
        schema_version = "IFC4"
    
    if name == None:
        name = "Hopper Model"
    
    if description == None:
        description = "..."

    if author_name == None:
        author_name = "..."

    if author_surname == None:
        author_surname = "..."

    if authoring_organization == None:
        authoring_organization = "..."

    if authorization == None:
        authorization = "..."

    # Initialize model
    model = None

    # Set owner history if IFC2X3
    if (schema_version == "IFC2X3"):

        # Create a new IFC file of the specified version
        model = ifcopenshell.api.project.create_file(version=schema_version)

        application = ifcopenshell.api.owner.add_application(model)

        # Add a person to the IFC file, using their given and family names to create an identification code
        person = ifcopenshell.api.owner.add_person(
            model,
            identification=(author_name + " " + author_surname).lower().replace(" ", "_"),
            family_name=author_name,
            given_name=author_surname
        )

        # Add an organisation to the IFC file, using its identification and name
        organisation = ifcopenshell.api.owner.add_organisation(
            model,
            identification=authoring_organization.lower().replace(" ", "_"),
            name=authoring_organization
        )

        # Link the person and organisation, creating a user entity in the model
        user = ifcopenshell.api.owner.add_person_and_organisation(
            model,
            person=person,
            organisation=organisation
        )

        # Set the API's user and application settings to the ones just created
        ifcopenshell.api.owner.settings.get_user = lambda x: user
        ifcopenshell.api.owner.settings.get_application = lambda x: application

        # Create the owner history entity in the IFC file
        ifcopenshell.api.owner.create_owner_history(model)

    else:

        # If not 'IFC2X3', simply create the file without owner history
        model = ifcopenshell.api.project.create_file(version=schema_version)

    # Header
    fd = model.header.file_description
    fd.description = ("ViewDefinition [CoordinationViewV2.0]", description)
    fd.implementation_level = "2;1"

    # Name
    fn = model.header.file_name
    fn.name = name
    fn.time_stamp = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    fn.author = [author_name + " " + author_surname]
    fn.organization = [authoring_organization]
    fn.preprocessor_version = "ifcopenshell 0.8.4"
    fn.originating_system = "IfcHopperShell 0.2.0"
    fn.authorization = authorization

    return model
