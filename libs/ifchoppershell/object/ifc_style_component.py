import ifcopenshell.api.root

def ifc_style_component(
		model: ifcopenshell.file,
		name: list[str]=None,
		color: list[object]=None
	) -> tuple[ifcopenshell.file, list[int]]:
	"""
	Creates a style for a list of colors, and adds it to the model. Optionally, a name can be added to each style.

	Args:
		model (ifcopenshell.file): The Ifc model to which the style will be added.
		name (list[str], optional): A list of names for each style. Defaults to "Hopper Style" for all styles.
		color (list[object], optional): A list of colors for each style, as Grasshopper color objects. Defaults to white (255, 255, 255, 255) for all styles.

	Returns:
		tuple[ifcopenshell.file, list[int]]: The updated Ifc model and a list of the created style ids.
	"""

	# Set default values
	if name == None:
		name = ["Hopper Style"] * len(color)

	# Initialize model
	model = ifcopenshell.file.from_string(model.to_string())

	# Initalize empty array
	style_id = []

	# Create sites (one per name)
	for i in range(len(name)):
		style = ifcopenshell.api.style.add_style(model)

		surface_style = ifcopenshell.api.style.add_surface_style(model,
						style=style,
						attributes={
							"SurfaceColour": { "Name": name[i], "Red": color[i].R/255, "Green": color[i].G/255, "Blue": color[i].B/255 },
							"Transparency": (255 - color[i].A)/255, # 0 is opaque, 1 is transparent
						})

		style_id.append(int(style.id()))

	return model, style_id