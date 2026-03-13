using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_6e749283 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "6e749283-03bb-4d66-ad22-4bbe8df2f00e";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAZlJREFUSEvFlE1KxEAQhT9ciiIOoii4FEXwFoIHUEHwLOJeFBfeRxAGtwmCF9CFG8HxlzAKIw+6oOx0Jj1B8cEjTdKp6nr1uuAfMQXMA0vAMjAX3v0KFEhBVyL24o1doZMr4B4wCNRa72ZcJValDqNKtc6qUpsVbFAUxUgEHqJqFt0+TyVrTWKbn8uyHInAEHgDroAz4BDYaKhSlYyFSXQRgt6Hn9eAA+AUuNQBgC9X5V34T5WNxYJVEE4Zy+D56qrUQUymGrwttekcOEkE9FxVBcAj8OEkkqVrwb0tt8JPccBUcK13gJuwVvNrTY5tqYaqgjiob6gFFzeBp7CejYMLKVtKfyXxrBINNb4A6yl5BEvgbalTqgeelfteAfsuwS2wHdY1m3qJ5ARRQVIS2fcjoA9cA8dB1nfX6B9SxU02ppLE3AU+E9LVrOptKifkJpHjhom70HrZpjOSqPGys54mXfa4EOIkZlGNELms6SJmDTyDyeUtrPlkI0RjpdPINqQsnK1zDlIWnkjnNjRZeCKd2+At3EnnP8M3+1q2wZuNV08AAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("6e749283-03bb-4d66-ad22-4bbe8df2f00e");

    public override GH_Exposure Exposure { get; } = GH_Exposure.tertiary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_6e749283() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Mesh",
        nickname: "Ifc Get Mesh",
        description: @"Get all geometires of the Model as meshes, with relative colors, ids, psets and qsets.",
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
