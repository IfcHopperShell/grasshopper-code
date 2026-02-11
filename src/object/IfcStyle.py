import ifcopenshell.api.root

# Set default values
if name == None:
    name = ["Hopper Style"] * len(color)

# Initialize model
model = ifcopenshell.file.from_string(model_in.to_string())

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

# Save model
model_out = model