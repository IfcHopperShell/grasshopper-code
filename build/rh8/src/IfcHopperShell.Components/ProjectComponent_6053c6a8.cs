using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_6053c6a8 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "6053c6a8-48c9-4228-927c-c54d6adfccf6";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAT1JREFUSEvVlTFqAkEYhR8BkYhBFAmY1iqdjewJUgnmRvEAQdk2jQvC9ilzAT3BllYWqbXaZmHCC/PL8LvjGh0JPngM7sx8z5n5Zxf4Z7UAPAHoAqjpzkvVtnBxL2QIQYQ+A1gCeAkdUncCMgDba4R0rhnCyYQQRijhJlTIATyKonWe599sQ4Q8anhRFDtjjGFbEsLxJ6vhg4s8IZx3p2FlerATptzzOI5XaZoutfncngnHcbyspDLEXcHOQnxmv6wgsi0rr1LuGfhCXPgEwMaWM3/zDh2VriId4sIJlRKW7eIrplK+EBcufRL89ZdtonQI/6ELF/M54W5FeSWvh0vsDWiWDD7X9xpO/d6BePA2TYbvRtwcfWR4TYx4i/7ei8E4w/zT7D1L5KDJOtDtB4Q8A+9B6+/wOT7pogXTD1K56Cjg538NAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("6053c6a8-48c9-4228-927c-c54d6adfccf6");

    public override GH_Exposure Exposure { get; } = GH_Exposure.tertiary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_6053c6a8() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Style",
        nickname: "Ifc Style",
        description: @"Create Ifc Style.",
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
