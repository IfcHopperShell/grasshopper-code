import ifcopenshell.api.root
import ghpythonlib.treehelpers as th
import Grasshopper.Kernel as gh
import Rhino

# Shortcut aliases for Grasshopper runtime message levels
e = gh.GH_RuntimeMessageLevel.Error
w = gh.GH_RuntimeMessageLevel.Warning

def ifc_project_component(
		model: ifcopenshell.file,
		name: str = "Hopper Project"
		) -> tuple[ifcopenshell.file, int]:
	"""
	Creates an IfcProject entity in the given model and assigns units to the model based on the Rhino document's model units.
	
	Args:
		model (ifcopenshell.file): The IFC model to which the IfcProject will be added.
		name (str, optional): The name of the IfcProject. Defaults to "Hopper Project".

	Returns:
		tuple[ifcopenshell.file, int]: A tuple containing the modified IFC model and the STEP ID of the created IfcProject.
	"""

	# Set default values
	if name == None:
		name = "Hopper Project"

	# Initialize new model because we don't want to modify the input model
	model = ifcopenshell.file.from_string(model.to_string())

	# Units
	length = None
	area = None
	volume = None

	# Note: Rhino 8 does not support the switch statement beacuse it uses Python 3.9, so we have to use if-elif statements instead.
	if (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Nanometers"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="NANO")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="NANO")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="NANO")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Microns"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="MICRO")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="MICRO")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="MICRO")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Millimeters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="MILLI")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="MILLI")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="MILLI")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Centimeters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="CENTI")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="CENTI")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="CENTI")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Decimeters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="DECI")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="DECI")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="DECI")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Meters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Dekameters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="DECA")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="DECA")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="DECA")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Hectometers"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="HECTO")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="HECTO")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="HECTO")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Kilometers"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="KILO")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="KILO")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="KILO")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Megameters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="MEGA")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="MEGA")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="MEGA")

	elif (str(Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem) == "Gigameters"):
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT", prefix="GIGA")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT", prefix="GIGA")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT", prefix="GIGA")

	else:
		# If the units is not one of the above, assume the model is in meters and warn the user
		length = ifcopenshell.api.unit.add_si_unit(model, unit_type="LENGTHUNIT")
		area = ifcopenshell.api.unit.add_si_unit(model, unit_type="AREAUNIT")
		volume = ifcopenshell.api.unit.add_si_unit(model, unit_type="VOLUMEUNIT")
		
		warning_message = """Unsupported model unit. Assuming Meters.
		
		Supported units are:
		- Nanometers
		- Microns
		- Millimeters
		- Centimeters
		- Decimeters
		- Meters
		- Dekameters
		- Hectometers
		- Kilometers
		- Megameters
		- Gigameters"""
		ghenv.Component.AddRuntimeMessage(w, warning_message)

	# Create project
	project = ifcopenshell.api.root.create_entity(model, ifc_class="IfcProject", name=name)
	ifcopenshell.api.unit.assign_unit(model, units=[length, area, volume])
	project_step_id = int(project.id())

	return model, project_step_id