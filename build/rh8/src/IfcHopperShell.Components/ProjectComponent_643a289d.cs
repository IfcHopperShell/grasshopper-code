using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_643a289d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "643a289d-f1f2-487f-9618-70ba13c27651";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAoxJREFUSEvFlU9oE0EUhzf/ECSSKsbgWolgDnpKg3gTY70oUklBL/YSEIpBD41FraBQa2svxUMjSMXSICbQpDbZlMQomhSiaA+KYPDQk+JJRUlS0lbbsM/3hm1iwia7rKA/+CAzO/O+2Z3sLPe/swnZhmyXYQuiRzTHiPDIcaQXOYV0Ik5kF0LXdiCaJbR63mQylV0u16LD4fhss9m+m83mZb1eL+K1drqOaJYwgU6ng8ZQn8FgIMluGoNokrQUUP72ThQFFJQAjtO0J6oEFC0SGmBBVAko1EfjJcxI01BxWgUbLFfMaDSygo3gxq9L8+g9kU21uHck4js0kPzivjDBiq74R6C0xw2Vdx9YWy4kobmIrKCuuOVMSHT6E2DpCUP/YBxK9sOw5OyCYpurqURJQK9+tbj7WhoK5V/w5OYD4DxBGAhkQSyUmGSp4yT73RglAXXy7Wcj657RjDQFoMjthcyVu0xC2ZCUPedY+88oCWjn+a6hdN7eOwMvhh5D8OAYfBqeZJKJuRxwUwLEEhn2mFb6hqWytSgJTAhd5OP9sbVwZwAGr6fYynOJ16x45MYdJvvac1EqWR9Ve5D2R/NU/NY4rhiLj91/ye5k7naUFV/2XgZ79Cn0LbyXytaiSjB7enI17ZuWpgC0hVIwNZqC8NGA1APQ/XwBnEJWatWiJGBHQ+Rq0Bc6Mi7SHlC8ubdMMht6BYWfa9AhzIMllIQ3335ApVKpQ0lAYXexIclcisOM5x50x7IiSVjxh0lx/7ETIp2kjVit1jzNR+gr2DRbkaokdX76I7UPCPPFfY+erXojgo/aLdiJ0NNoGSZpAb3xVEQO+tSqymaEbpVOVfoLU5seYcuT8h+H434DgXt+gdKD7qsAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("643a289d-f1f2-487f-9618-70ba13c27651");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_643a289d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Model",
        nickname: "Ifc Model",
        description: @"Create empty IfcOpenShell model.",
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
