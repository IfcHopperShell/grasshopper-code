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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAXpJREFUSEvFlTFOw0AQRb8okZAjCiSofAMfIRUnCH2OkCvkJq6h8SmgTUOfGxByAqO3yq7GgyfYiIgvfWk1++fPena9K/0zriRdS7qVdCfp4UTGxJhDMxsk3Ui6N6YR0aCdXAihXe2TpGdJ75L6ExkTY85+1Y9FEORVP0p6NaYR0aDNXxMWsSsn4XPELCLaXCT8Evr4G/OxIngNYFsTtmW9Xif6uCG5o63iuOUN9UmFu90u0ccd88bjWcCZJvgykpDYNE2fwdjPG+KBF54FeXPtURywbdtSgLGfN8Qjb3ZBPstenFhVVTEHh8MhxbzOMPtNK7DZbAYFADGvO1fgbIv2+733TzGvO3G0ReEmL5dL713AnNdHmxwe067rUs+3221f13UiY2LMeX10TO2P9mYTVqvVx2Kx8CY9MeZcnFw8vv1owF4VR284geSEVwXwl92cItY8vOyAv64H7QqIZtJ1nTH24HAy/INDbPaDk4HwYk+mBUkXefT/DF/rhW/w7o6UcwAAAABJRU5ErkJggg==";

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
