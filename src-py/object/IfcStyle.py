import ifcopenshell.api.root

# Set default values
if N == None:
    N = ["Hopper Style"] * len(C)

# Initialize model
model = ifcopenshell.file.from_string(Mi.to_string())

# Initalize empty array
SyId = []

# Create sites (one per name)
for i in range(len(N)):
    style = ifcopenshell.api.style.add_style(model)

    surface_style = ifcopenshell.api.style.add_surface_style(model,
                    style=style,
                    attributes={
                        "SurfaceColour": { "Name": N[i], "Red": C[i].R/255, "Green": C[i].G/255, "Blue": C[i].B/255 },
                        "Transparency": (255 - C[i].A)/255, # 0 is opaque, 1 is transparent
                    })

    SyId.append(int(style.id()))

# Save model
Mo = model