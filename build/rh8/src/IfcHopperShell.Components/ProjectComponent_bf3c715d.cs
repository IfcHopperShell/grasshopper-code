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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAU9JREFUSEvdlNtJQ0EURYP4oyiiiKIdWIEVWIG2ZQV2YAPagFZgBVZgB2YvmHW5zCPcSPzJgQVzXntmTuZmtfd2EE7CZbitIEaOmj/ZabgJtXANNdQuNk50HhR4Cm/hJ/wWWBMjZx09i26j+F1ARNERH4FaN9loXFXxr4DAZ4H1c6GOU+smw3FxPWfOqWh8Lf538REB1sTIUYNPDz4a3VHxIihgrjRwOvyH4r8XHzw5ubnvb4JWYz5FT8QJOZWj0gdvRG7ue2O0GiMB89eyLfSq05gJCh0P+KPOn6RjJGfMMek3ZuJfNjgMS77apaCF5mTXgcTjgPtQixDr1QJ5NCeziSuO4LUgCqx7NaLeZAaYaQ+fKq/EV0asVwvNBhfB4Ai/D3gpsU00/0vHgf+RmrNgkxvok+v1oLWVjTbYmV0FRYXYzuwozL8T1sT23larNeTpjbUE65ebAAAAAElFTkSuQmCC";

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
