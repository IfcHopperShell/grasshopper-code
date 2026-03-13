using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_bb4165ef : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "bb4165ef-5edc-4202-b614-125cf11f175d";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAUZJREFUSEvNlP1pAkEQxZeQIIgSDGLQDvw/kArswAqsIB2kAa3ADqzAQtKBDWgFyg/eg2FZde88JA8GZufjzTkzTkr/BL2U0mdKaSZBx9YZInks0hlMepb43QnebxQY5sFNQZ9Ntg4F0G1/aBYfItkGcstGPmJaYyqSo0i/JOjY8BHTGm7DqVDg0MWwb7UI28MtGolkLkJ+CeL+I8S0hmewCoQW21rPoC+ChVqyD+To2PDxJrYx8v675yVb4zm8BDKv6HewocdVRcipxiD0GaI/vTlwngs2fJ4FOdWYKGknkl+9uUu+TdjwEcObnCq8KoHV9M6jY3uTXPOTexdcSIJ/su2JX+hf6G0ilnfVdXUB/kwkLws9zmfkFlYV8Ilmx/1lDDZuCbqHTYw/oup0u8cWiLDlwOYillJcEd6U8Z0kfJ4HOc/HBVCRTXO1vaecAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("bb4165ef-5edc-4202-b614-125cf11f175d");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_bb4165ef() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Project",
        nickname: "Ifc Project",
        description: @"Create an Ifc Project.\nUnits are taken from the Rhino document.",
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
