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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAUhJREFUSEvVlT1qwzAcxUUghJSU0BAKzZqpW5biE3QqpDdKD1BSvHaJoeA9Yy6QnsBjpw6dk8mLQX2v6B9U2YqNo1D64IfQ13uWJdnqrzUEEzAGXTaE1BWguXADgoXQiKa3YAvuTT1YSA9IQAZ2IHjICJwthJNpQjOa0lyb8uSQknkURR95nn+xZN20tw65Br/Mi6LYa4hlRQjHN9YFqDQXeUI4rwNqdQk4YQl0HMfvaZpuXdjOfjOO42UltSH2CvaAJj7YLyuITMmTVyt7D3whtvkT+AQ8zqzzDh2Ve4rcENucpnKE5XXxE1MrX4htLn0SvDFtjV4T5YbwCW1zge00lz7uo1fyeTgFb8AAVE1oQx+U9HMH4tlimdw9a2Hw8Jqpx0QLOzU98DabZ2q11gdeEtloepX0/wNC7oF3o93/cBsaXbRAUuobUrnoKE3VhIIAAAAASUVORK5CYII=";

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
