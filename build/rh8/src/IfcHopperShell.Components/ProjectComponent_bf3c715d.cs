using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_bf3c715d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "bf3c715d-ea21-44dd-99dd-6e4d2e218bc0";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAUZJREFUSEvllP1JA0EQxR+SfyKKRCQSO0gFVpAKkrZSgR3YgDYQK7ACK7ADww/mhWV2V+7CgWAePLj52Lezs7Mn/XdcSbqR9CDpKREfMXLOwq2kVUM4kxxyB4OKFoXATtKbpG9JP0G+8RFzHmsGncbi6xCxaI+HyPUmv4KjWvwzBD6CfO+D2U+uN+m2i+O551TFwtewv8JGBPKNjxg5PonvpNkqJsI9d4XYm7Dfi367cmKl7TtBq4JH0RVRIVW5VbahT0SstH1itCq4unJaxpK11qngAIluD/SlliPpNhLLbfubDWYDX+1QooXmCY8R2Hb43BDBl/NM4mie4EX50koyLYhCv5MerVdt4Jea6VFlSjxl+HKeWW1w32hBpt8HfGnEM6v/0nX8RzLvikW5BcRyPkRrFHobTIZlowX4JsM8vRO+8V0AjuTpjbW3OHGlAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("bf3c715d-ea21-44dd-99dd-6e4d2e218bc0");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_bf3c715d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Context",
        nickname: "Ifc Context",
        description: @"Create an Ifc Context.",
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
