import ifcopenshell.api.root
import ifcopenshell.api.georeference
import math
import Grasshopper.Kernel as gh

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_georeference_component(
        model: ifcopenshell.file,
		coordinate_reference_system: int = 4326,
		eastings: float = 0.0,
		northings: float = 0.0,
		north_angle: float = 0.0,
		origin_scale: float = 1.0
	) -> tuple[ifcopenshell.file, int]:
	"""
	Adds georeferencing information to an IFC model.

	Args:
		model (ifcopenshell.file): The IFC model to which georeferencing information will be added.
		coordinate_reference_system (int, optional): The EPSG code of the projected coordinate reference system. Defaults to 4326 (WGS 84).
		eastings (float, optional): The false origin eastings (horizontal). Defaults to 0.0.
		northings (float, optional): The false origin northings (vertical). Defaults to 0.0.
		north_angle (float, optional): The angle between the projected north and the true north in degrees. Defaults to 0.0.
		origin_scale (float, optional): The scale factor at the origin. Defaults to 1.0.

	Returns:
		tuple[ifcopenshell.file, int]: A tuple containing the modified IFC model and the ID of the context to which georeferencing information was assigned.
	"""

	# Set default values
	if coordinate_reference_system == None:
		coordinate_reference_system = 4326

	if eastings == None:
		eastings = 0.0

	if northings == None:
		northings = 0.0

	if north_angle == None:
		north_angle = 0.0

	if origin_scale == None:
		origin_scale = 1.0

	# Initialize model
	model = ifcopenshell.file.from_string(model.to_string())

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

	context_id = context.id()

	# Add georeferencing
	ifcopenshell.api.georeference.add_georeferencing(model)

	ifcopenshell.api.georeference.edit_georeferencing(model,
		projected_crs={"Name": "EPSG:" + str(CRS)},
		coordinate_operation={
			"Eastings": eastings, # False origin (horizontal)
			"Northings": northings, # False origin (vertical)
			"XAxisAbscissa": math.cos(math.radians(north_angle)), # Horizontal component of project north vector
			"XAxisOrdinate": math.sin(math.radians(north_angle)), # Vertical component of project north vector
			"Scale": origin_scale, # Scale factor at origin
		})

	return model, context_id