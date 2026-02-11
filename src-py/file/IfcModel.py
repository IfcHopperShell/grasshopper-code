import ifcopenshell.api.project
from datetime import datetime

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

if organization == None:
    organization = "..."

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
        identification=organization.lower().replace(" ", "_"),
        name=organization
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

    # Create the owner history entity in the IFC file, required for some IFC versions
    ifcopenshell.api.owner.create_owner_history(model)
else:

    # If not 'IFC2X3' and 'ownerHistory' is not set, simply create the file without owner history information
    model = ifcopenshell.api.project.create_file(version=schema_version)

# Header
# Description
fd = model.header.file_description
fd.description = ("ViewDefinition [CoordinationViewV2.0]",)
fd.implementation_level = "2;1"

# Name
fn = model.header.file_name
fn.name = name
fn.time_stamp = datetime.utcnow().strftime('%Y-%m-%d %H:%M:%S')
fn.author = [author_name + " " + author_surname]
fn.organization = [organization]
fn.preprocessor_version = "ifcopenshell 0.8.3"
fn.originating_system = "IfcHopperShell 0.1.1"
fn.authorization = authorization

# Save model
model_out = model