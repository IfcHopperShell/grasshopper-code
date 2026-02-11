using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_6e749283 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "6e749283-03bb-4d66-ad22-4bbe8df2f00e";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAapJREFUSEvFlEtKA1EQRYNDUUQRRcGhKIK7EFyACoJrEeeiOHA/giBOEwQ3oAMngok/QgzEe6QvVLpfpzsSseCQSn/qvbp1+zX+M6bEvFgWK2IuuzaRoBBFV3MsiIkEO6fgvmhnkHNtRrgTd8lm6JS8Vpc8TLF2s9kcgPKn7JpZEn4uwmKVi/jhTqvVGoDynngX1+JcHIlNkeqSTkaGJboUFH0UvLwuDsWZuBId0Q9dPgjeo7ORsSh+OhDskryMt9AlG+EaMhXCA7OuF+I0y8tYE33xLD6FJcLSQ0HxaMttwUv+n8LFyXfFXZYz/MKQrbkHxkDpwMVMHKiLw5Z4yfJZUYiULdGfRSLdxEDNq9gQBXkILxBtyS6ZQaQb7nfFgfAC92Inyws2jRLhBKCIXzbx/rG4EbfiRCDrh/Cgh6TKD9mkFsmzJ74S0hWsGm2KE1ygahEc1wvS+Vuo/NimhYuULcLgsTO/ls4SFeaQivwitihHCC4r+xBrHXgOyxUtzPnkI4Rjhd1SFFnIaxcnUhaurXOdSFl4LJ2roszCY+lcFdHCv9L5j6LR+Ab7WrbB4HACSgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("6e749283-03bb-4d66-ad22-4bbe8df2f00e");

    public override GH_Exposure Exposure { get; } = GH_Exposure.tertiary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_6e749283() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Mesh",
        nickname: "Ifc Get Mesh",
        description: @"Get all geometires of the Model as meshes, with relative colors, ids, psets and qsets.",
        category: "IfcHopperShell",
        subCategory: "1 - File"
        )
    {
    }

    protected override void AppendAdditionalComponentMenuItems(SWF.ToolStripDropDown menu)
    {
      base.AppendAdditionalComponentMenuItems(menu);
      if (m_script is null) return;
      m_script.AppendAdditionalMenuItems(this, menu);
    }

    protected override void RegisterInputParams(GH_InputParamManager _) { }

    protected override void RegisterOutputParams(GH_OutputParamManager _) { }

    protected override void BeforeSolveInstance()
    {
      if (m_script is null) return;
      m_script.BeforeSolve(this);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
      if (m_script is null) return;
      m_script.Solve(this, DA);
    }

    protected override void AfterSolveInstance()
    {
      if (m_script is null) return;
      m_script.AfterSolve(this);
    }

    public override void RemovedFromDocument(GH_Document document)
    {
      ProjectComponentPlugin.DisposeScript(this, m_script);
      base.RemovedFromDocument(document);
    }

    public override BoundingBox ClippingBox
    {
      get
      {
        if (m_script is null) return BoundingBox.Empty;
        return m_script.GetClipBox(this);
      }
    }

    public override void DrawViewportWires(IGH_PreviewArgs args)
    {
      if (m_script is null) return;
      m_script.DrawWires(this, args);
    }

    public override void DrawViewportMeshes(IGH_PreviewArgs args)
    {
      if (m_script is null) return;
      m_script.DrawMeshes(this, args);
    }
  }
}
