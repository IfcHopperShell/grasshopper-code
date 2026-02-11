using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_d108de7b : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "d108de7b-849c-4e7b-817d-04c67de8b396";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAK1JREFUSEvNlcEKg0AMBffWs6dS//8/bbZ0QoIJZNV2HZhDdl8SENQ2i4f4EteiPdt7yowMx95ThqatKPkyly/InvlnAGS1SD4le+bhQKAWyae4gQe82QKo1iL9uHsvuAgHQFaLdji694JD23RG5in/XQBHa3HyggucvACojS6HYM7IKa4RqI0uh2DOyClhY+BoThltjO6s5JTsc33Gp6hUf/LL1+jOuvvY/YjW3jC8nv4vqcRSAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("d108de7b-849c-4e7b-817d-04c67de8b396");

    public override GH_Exposure Exposure { get; } = GH_Exposure.tertiary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_d108de7b() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Building",
        nickname: "Ifc Building",
        description: @"Create and Ifc Building.",
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
