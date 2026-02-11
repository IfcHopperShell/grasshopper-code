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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAApdJREFUSEvFlF9Ik1EYxj+CiP4xkyiUwKCrblKI8MIokXbVyIguJEaCFBUU7CaIwS686CYl0YtCgrbIzWY2bOU2IpEyMiPSLKKQHG5QDJStpdQKe3uf1+987B9N+4QeeDg743y/53vfc86n/S+tZZezK/VxA3ubPt/OXs/+ZwEGUClj3YplwO1XIr4dLf5fGDFPNF0IpbRdlLSdmlRr2CsKMeC21sik1uimqtN3CWOvyxMH/GvVAcI4e+zsc7WWjXaWFHoqDxxyhaYBbe4coeR8hurO3ZGQB1fvEbTQfFFCPtsdUhm7gl0yBBuXA4cy7n5K7jlshEQT3+T/+cYz+SE4CH/VUrkMKTvhFciXVzFKdAcFpEJuvP5EnqkZWozG5f/03iMp/Vm84Fb2JnZRyRGUDUU7rj8j9742CjS5adTVLbDINS9pNweozvuQktW2/AqyDdYado6QLAsGL4enFLz2fEBa8/T+aAH8g7NtQj3DbmeH2VZ9XhCC8irDjr63gIcvBWknnyALt8vXMSTV+G8PL8EtNfSmwyOB9tATVOBnk260TIVY2IbkTXrqO397G7ook/5O49Nz1Ps+RtWBIfKdvCUh6Udj0n+orGeQNh60LvJzCq4cY4OHfTEkn4WIs98H0EhrSCDjsyl5UxUy9zFByR8/6ejjF6Ttb8gHK79jFwTgHOM854SgkvbgSwmpGRimaHpBxhLw3WwEbGbnyLhsai/QLozO8NgEQtCWZcKxyUVlfC4Qgj1BRZhjQ8vrrRn+vRx4wTHNlhGS5+Ns03AltAuLFbyWDYiDbRqeLXUBAVYwFWIaDm1hA9DHzoa26KMpOCQ3nB1hx/URcPxnGg4Z36giXsdeFeHC4FbiIqIizFcNblKa9geUaagPm6oMgQAAAABJRU5ErkJggg==";

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
