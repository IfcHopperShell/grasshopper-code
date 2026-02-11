using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_76ce7f38 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "76ce7f38-466e-4a26-a23a-a2fda24dcc09";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAZ1JREFUSEvFlDFOw0AQRS1KJOSIAgmq3MBHSMUJQu8j5Aq5iWtocgpo3dD7BgROsMxbdpyxPWucCImRnrSa/fNnPbtJ8d9xJVwLt8Kd8JBgTY49NGcHRTfCvaCmOdCgXdwIoT3tk/AsvAshwZoce6qj5tcmCPTUj8KroKY50KClhtpsE3tyCj4Fz9ADrTbJfglzvMRcsU3wGoQdTXYsdV1HvL0EtXhMRsVzY4NL8wojbdtGvD2DXjyeffCmSb4IXlGoqiposPY0CTzwwrMPvVz7FAc0TZPsQ1x7mgQeeOHZBwnwCkJZlsn6J47HY8x52oT69THbYLfbJetTkPO0iUmD2RF1XZdsT0HO0wruiLKXvNlskuU02BvrBfeSs8/0cDjEme/3+7BeryOsybE31gvuM7U/tDehL9hutx+r1coaRMixN8pTi4f7n2T/Kr4EW7gEarJ/FQQd9bLPbWLN8ZicXsOOioLBuDKgUXN3NOOwXwJcGi/DPmHW5PRCYfbk40DIHPVr5kCDdrG5DYp4brxp+1WsybF3kfEfRVF8A+uFb/DG88KkAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("76ce7f38-466e-4a26-a23a-a2fda24dcc09");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_76ce7f38() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Site",
        nickname: "Ifc Site",
        description: @"Create an Ifc Site.",
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
