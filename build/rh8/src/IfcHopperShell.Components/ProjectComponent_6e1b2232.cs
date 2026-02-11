using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_6e1b2232 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "6e1b2232-0bf6-4d82-bd25-a4e4f7352852";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAJNJREFUSEvNlksKgDAMRLsTTyB6/3tqIpnSYotpDI0Db9MmMxDoJ0VpJXbiUMK1C6HWiDnYCLXQdCpBvVruATy/1lhug56wL7VMV72ZuwVUhgZ+FqAV6qW35HEusOEVwHBIFhbLpi/AL2tugFXoF6/AAAeCA6xCv3gFBjgwP8DyRL5RPaF8MfFCq9ACew19AoxK6QLxyim/m5Z82AAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("6e1b2232-0bf6-4d82-bd25-a4e4f7352852");

    public override GH_Exposure Exposure { get; } = GH_Exposure.quarternary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_6e1b2232() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Building Storey",
        nickname: "Ifc Building Storey",
        description: @"Create an Ifc Building Storey.",
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
