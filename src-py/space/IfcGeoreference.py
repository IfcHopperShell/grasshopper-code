import ifcopenshell.api.root
import ifcopenshell.api.georeference
import math
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

# Set default values
if CRS == None:
    CRS = 4326

if Es == None:
    Es = 0.0

if Ns == None:
    Ns = 0.0

if Na == None:
    Na = 0.0

if Os == None:
    Os = 1.0

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Validate context
# Georeferencig is assigned to the first context of type "Model" found in the model

# if there is at least one, but it's not of type "Model", create it and warn the user
if (model.by_type("IfcGeometricRepresentationContext", include_subtypes=False)):
    context_list = model.by_type("IfcGeometricRepresentationContext", include_subtypes=False)

    for context in context_list:
        if (context.ContextType != "Model"):
            context = ifcopenshell.api.context.add_context(model, context_type="Model")
    
            ghenv.Component.AddRuntimeMessage(w, f"{len(context_list)} context have been found, but none of type \"Model\". A new one is added, be aware that some objects are probably associated to different contexts.")
        else:
            if (len(context_list) > 1):
                ghenv.Component.AddRuntimeMessage(w, f"{len(context_list)} context have been found. Note that georeferencing will be assigned to the first one only.")

                context = context_list[0]

# if there isn't one, create it and warn the user
else:
    context = ifcopenshell.api.context.add_context(model, context_type="Model")

    ghenv.Component.AddRuntimeMessage(w, "No context was found. A new one is added, be aware that some objects are probably associated to different contexts.")

CId = context.id()

# Add georeferencing
ifcopenshell.api.georeference.add_georeferencing(model)

ifcopenshell.api.georeference.edit_georeferencing(model,
    projected_crs={"Name": "EPSG:" + str(CRS)},
    coordinate_operation={
        "Eastings": Es, # False origin (horizontal)
        "Northings": Ns, # False origin (vertical)
        "XAxisAbscissa": math.cos(math.radians(Na)), # Horizontal component of project north vector
        "XAxisOrdinate": math.sin(math.radians(Na)), # Vertical component of project north vector
        "Scale": Os, # Scale factor at origin
    })

# Save model
Mo = model