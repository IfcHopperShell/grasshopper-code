using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_9d7116a3 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "9d7116a3-0d9a-44fc-bbc2-68b3089c1c30";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAuhJREFUSEvNlV9Ik2EUxkdMrMi2RViJoOCFhZBRhJBSEHURDcoIKhPtoptAwi4ikMDsRshqKbSr8JvQRoV/09qQauWwNIhZdmMDhwkyIdsmiojk6TyH7/1I1+afKx/4sb3fdp5z3nPevTNtJKUxO5gsZiezjcnU17uYLcy6lc7sYWCWiq3MmoUgMSi/5/NYLj1dtNf5vmE9UV7tiZnyKHaiYlR9h1lTkiXmpjMaWcrchNf6+o4QzOM5R2m9SdBTCZCK2bSyMUDRmXm6UdshSbofthE0W3lTkkTtV4dVDIO2ppQM0F7nHVbm0IJ/gKL7T1PxtWeSJDg6Jc9VErQNcQwOREpJJei5lduCyqdGJiny8jPFLAeMJI7+EXKFxmgxGqd47jGKZx9ZULEwSSU5kqr3zxvfk3a4gdovauS73SzV+pw8j+ZOKnb3ULTQvnwHOMopZQy4p6F3SJkXVbVLa/q6PiWYD95pGlcxenxKyQ58Na0emHeVuQxzralPduNs5Xno5l8dLkl4wRvwIo5ZcQcy5LbzT+bcx5tofnpOBvoqNEGF7W/JU9EiSSLud/QnPC6Dzn3RK0kQp5OgTYy6DgRjB5dbJEl4elZMVJJQ97CYX+n7Is/t3oA6qihwiXDXqOtgH3Of6Wdoc1r6/N7teXTr1HUxe9QbNJIg4dk3A7I+5wt81OPBkrsJlauL6yQTY8hsNs+UlJRECgoKJrEGORnZ9PjgXarxDg5JO3TKX39QpwckDDiDwQdFjGEeDofJ5XKR3+8np9P5C8/Bbmvmb37NgumhTn9sJXNItUZaAkpLS384HA55D4LBIFmt1p9qzdQyyhTAI+n1oBKgh0kT2Gy2MbVmVAL8F9gYzDCp/m1RnDFapGmaatEUnut8Z1TlK15qEIaMShCAIRtJMOT8/PwJrHVgjlOG71qYVWv5MX3AqJYhId5XM6ryhHO+GmEn+Ikrk2SsqfL/CX3F4FTbACqGsZnZKDKZ/gITc8zV1l832wAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("9d7116a3-0d9a-44fc-bbc2-68b3089c1c30");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_9d7116a3() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Read",
        nickname: "Ifc Read",
        description: @"Reads an Ifc file.",
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
