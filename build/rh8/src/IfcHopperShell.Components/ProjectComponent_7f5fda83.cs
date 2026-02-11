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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAX9JREFUSEvNlc1JBEEQRgfBi+hFRNEMjMC7YAQagRGYg1dNxAhMQCMwAk3AjUDrQb+hprvHXd05WPCgu36+6r/dGf6T7QYHBcaL2U5wFJxV4CO2sbGqw4DCzEmA4EXwUGCMj1idj0Z3h6dBXmEGwc/gq8DYJj1o3JjBlw7vAcL3Bcb4ernqNGbAVfa4LPRisrYBPAZvaX4b1EL4jJNLjXNobD8w6JHcJF9uksXJwUeNPrQa430TvAso+Aieik9skH3kkIufWnxoNeYr4qKeAxvl11I3IKYwNV4yWhPbCwhcBRR4NKsgn23dgBg5jD0qNJijOdpxgNPtZgHevPO6AbG8gHysaI5mAsX5ffM68Lmj3MAVk2O+j0O90fIOFBGPAPQxPg+I5Vzo7sA7oCg3eQ0807oBECNHP7VoEJvcAcaflIVz1A3mQGti+Uf2E5s2gMmPTef1GmzQi2XUG02HAtsy24A3vQRNA75EOpdictF8W7kUP+rbgtavvtd/tGH4Bp2+rwTaf8cWAAAAAElFTkSuQmCC";

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
