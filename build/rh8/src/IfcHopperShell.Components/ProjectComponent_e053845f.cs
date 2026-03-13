using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_e053845f : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "e053845f-ad10-481f-87a5-dfb8330521f8";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAATdJREFUSEvFlTFOA0EMRb8QVSQaikik3bPQb8EVtyD3CAU1JS09ewLQQ/HIa2xlNiLhS19aeezvGds7I/0zbiRtJN1L2kraHck3NtbwWQ2C7iQ9ONGK+ODbneg27PZJ0rOkN0lfR/KNjTV/qpNJcLBdP0o6ONGK+OBrpymTsGA7J+AzEauIryUpT0IdzxHPkqC1gC9NWZZxHF9htDsSm5aKcbOGxqDGeZ7fYbQHWuPRbGCmMe6TgMZhGD5gtAeigRaaDdZcP4rnEg1rdoPNcnRe0BDtCU3vegm6StSZIC1RV5M7E6RN7hrTzgTpmPof7SUJ+uE0TQcY7Y7EovHrRwP+qpiT4FMkprwqQLzs1iTx4uVlB+J1XZbLEZ+u69rgT2KNZzLig4Nt9YNjwPFiT6YHQRd59P8M3/2iMfDZPoP6AAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("e053845f-ad10-481f-87a5-dfb8330521f8");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_e053845f() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Info",
        nickname: "Ifc Get Info",
        description: @"Get object info given the step Id.",
        category: "IfcHopperShell",
        subCategory: "4 - Utilities"
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
