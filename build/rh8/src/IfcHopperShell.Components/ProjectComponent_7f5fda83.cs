using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_7f5fda83 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "7f5fda83-0787-4b7e-882d-2f423a7bddaf";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAXFJREFUSEvNlc1NQzEQhEdIXBBcUASCDqiAOxIVhAqogB64QiNUQANQARVAA1AB6JN2ntZrPxKSHFhpJGd/Zuxdv1j6R7Yv6SjAeme2J2kh6bwAH7G1jV0dR2HGaRBeSnoIsMZHrObDMTzh2WCXBoSfkr4DrC0yAsKdOfgywHsQ3wdY46t5wDydOeBdjnAVqP6MlQLgUdJb+n07IMLnOLnUZI7ODlPQLbmZEcnk5OCjxj64OuN+E7yLgg9JT2VXtQ2AHHLxU4sPrs58ixjUcxLKt6UKEDMxNR4yXI0dROC6tOar9LYKECOHtVsFB7/hnOykHDcTcOfnBIjlDeS2wjlZJsj3m9uRT5QFvGNy6vdivsnyCUxiuAVV4CJiNX94As+AoizymnpaBQAxcjI5HMSaGWD8SblwDlVgDnA1lj+y37CuAGg+NjuXK2CB6q8wXydQB7YpZgW407tAJzB6ErdFM2jeVobiR31bwPWn93pj+wGdvq8ES2zV8wAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("7f5fda83-0787-4b7e-882d-2f423a7bddaf");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_7f5fda83() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Qto",
        nickname: "Ifc Qto",
        description: @"Create an Ifc Qto and assign it to an object.",
        category: "IfcHopperShell",
        subCategory: "3 - Object"
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
