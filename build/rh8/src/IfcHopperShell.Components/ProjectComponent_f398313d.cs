using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_f398313d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "f398313d-41a2-4938-88e8-c128eb3e2253";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAATlJREFUSEvNlYFJBUEMRAdRBBFEEEQ7sAIb+YXYgRXYgHZgBRZiBVqBFSgPdiCsSf6eIjgwsFwyc3eZvT3pH+BY0rmkS0nXg6y5Ru3HOJJ0EUwr0kPvJpxIuhoGt5IeJb1J+hxkzTVq9NCLZgm8tp/uLphWpMf9S2/iWd8nZhXpdTYtTkfjLjHZRzRo21E51JfEYB/ROPQSnuUshh+SngZZz3VofYrDsGtmIYxhVuF7V+H1Dd491fw945We9AM8GMWbRAhfRw2ynuvQD4BXCm/RyqAjGrTtVuV86Wbc0RnhUcJBw/fEpCK91qUBR/gtqiAzOtz26Q0C8kH3kJjNpIdeNGW4M+KB95yYmtTcl27NDpwp3U2ieXv+dHAe802i+dks2or5JtF8KdQVxHH9eiwV/Bvd9Hv8c3wB6Uq32lFnlmYAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("f398313d-41a2-4938-88e8-c128eb3e2253");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_f398313d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Georeference",
        nickname: "Ifc Georeference",
        description: @"Adds IfcProjectedCrs and IfcMapConversion objects to the model.",
        category: "IfcHopperShell",
        subCategory: "2 - Space"
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
