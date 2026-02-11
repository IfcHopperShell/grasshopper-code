using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_bb4165ef : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "bb4165ef-5edc-4202-b614-125cf11f175d";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAVlJREFUSEvNlO1pAkEURZegBCQiSjBoB/4XrCAdpAIrsIM0ECuwg1SQQtKBDWgFyT3wLgzLrpmdXYIXDpl5X7O+N5nqXvQoXsQ6YI1tMKXF00MGk4v+BN4PoploO2Aqeok+u9iH8AGsbe81i4WgyEm4uDkKfMQUayUochEU3QasseEjplgUgKuoH3AW9hfrVouw4evVormgyEZQkF8C7j8QUyzPYB9/U2wrnsFEUOBV0JKv2ANrbPjYE9tZ9f675022znN4EC7mK7pLbKyx+aoCOdl6EiTRZwp9x54HznPBhs+zICdbS0HSp6DIe+x5l/w2YcNHDHtysjQSJHA1KQCssY2DNj+5f4oXkuCDINm3J/1C/0LfJmLZZ72uPoB/JpLfYp/2uD4jtzDrAD/R3HF/GYNNbwlrD5sYf0TW0+0eGwphqwubDzFNcY3yTXkWt5LweR7k/Leq6hdQkU1zKIYftwAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("bb4165ef-5edc-4202-b614-125cf11f175d");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_bb4165ef() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Project",
        nickname: "Ifc Project",
        description: @"Create an Ifc Project.\nUnits are taken from the Rhino document.",
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
