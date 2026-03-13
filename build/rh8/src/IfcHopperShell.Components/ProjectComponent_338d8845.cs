using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_338d8845 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "338d8845-edcc-4b21-bed6-7182e2d28d74";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAApJJREFUSEvFlF9IU3EUxw9BRP+YSRRJYNBTLylE+GCUSHtqtIgeREaCJBUU7CWIwR586CUlsYdCgrbIzaY2bOU2IpEyMiPSLKKQHDooBsrWUmqFnfge7+9yvc7m3KAvHA6/y72f7z3n/H4/ov+k9URUSkRlWt5ERDu09U4i2mj+IB8BBlCuwHt5S4c7rkb9uxsDv5GxTtRdDKdoLydtZ8bXaqLDbc3RcbJ7uLyph5G73N444N/KDzPyzMlzLwwmaGdOoafywVF3eBLQhvYhTs5luPr8PTF5eO0+Q/MNl8Tki8MplRHRrtWYYHBL4FDG08vJ/cd0k1jiuzyfs581m2Aj/FOL5do9XFLvE8jX19Oc6AgJSJncevOZvRNTvBCLy/P0geMp7Vv84HYi2mIGK8kWlIGiHTefs+dgCwfrPDzs7hBY9IaP6XYfV/secbLCZq7AGGCtMxvAWV7ovxKZUPCqC0FpzbMHw8vgH10tYwZoKxFFiMi6kgnKK4s4u98BHrkc4j1NPWyp97G/bUCqCdwdXIRbKvltm1cMHeGnqCBARKwFWqZMLEYD+ZPOmvY/vtrrnEn/4NHJWe76MM0VwQH2n74jJunHI9J/qKSznzcfsS4Y4CqmDXPRJddC1NXrB2ioOSyQ0ZmU/Kkymf2U4OTPX3ziyUumQ7VmsIr32Qywj7Gfl5igktbQKzGp7BvkWHpecg74Ps1gq9EA0g+bmgXaheyKjIzBBG1ZJRxDzir9uoAJZoKKsMZAS2usmSzgbPBl29SolW7TU1nAecOV0C51/yOqNIizGHCj1AEEWMGUScFwaJsG6DZBG4sBh+SEE1GUiOJaBly1riA4pN9RWWKD+eW1CgcGpxIHERVhXTR4wfoLlGmoD/6FAWwAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("338d8845-edcc-4b21-bed6-7182e2d28d74");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_338d8845() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Write",
        nickname: "Ifc Write",
        description: @"Write an Ifc file.",
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
