using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_5a44c96e : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "5a44c96e-c44b-4ce7-b1c8-75d96446d4b0";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAfhJREFUSEvF1eFJXEEUxfElRIKgSIIo2oEVpAIrSBpIKrACbUArsIKkAW1AK7CC2IAdmPODPTBk375dP0gu/Hmzd+7cOTP3vreL/207YT8chpNwusSYz5yYN9tukKAJN3EUrNnKPoUuPAuX4S68hNclf8JDMCem8dZutM9B8E14DlfhfOkb+R5ugxixfF/CRjsIgr8OT0p/BaphzDfGeKrJrH0MvXuLJHsKTkGxk3iCz5yYbqAWckyabminXASLJfL7W7gOlMOYz9zPINYav+WY7KzjMCZXPIoV9Hfgr3pjPurFiB03kWvFTKDJBStgC/wjUD6qNydGrDWPoXlWrCcAlf+e4j7oFkjEV/WjEEyeYKyBo9ukCsdaNBGfOQU2toZ/bQ1UX4AF1BtTrYi9Y8ohWa9RjFjz7aYPYcX6BlPTF8db66mg2tIYxl6yMcbvnnTyjd4LJnvPxi2ap6vhl5zSznUjc05rPPldGk/QRb4/npLxtz35XEkV27D18HuyBt2A0qrrol7J2DGNI4Kv6ic7qCagiT17XaNCibRoE46s7aCar6HAHrWK/XY97RToHup1VK/Nd2zWtKoPVhWBUonblpKO/wN9wqd+K1MPm/XtVoOxoOrRayzUT/b/nLXwxR33bS+zRd3GbEKd+vRk/dfjny3qO9ti8RfvOHpRNKrtzgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("5a44c96e-c44b-4ce7-b1c8-75d96446d4b0");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_5a44c96e() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Info By Guid",
        nickname: "Ifc Get Info By Guid",
        description: @"Get object info given the Guid.",
        category: "IfcHopperShell",
        subCategory: "4 - Utilities"
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
