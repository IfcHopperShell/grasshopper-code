using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_88d0a17a : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "88d0a17a-aa52-4449-b95b-3c7e271d03ce";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAdBJREFUSEvdVT1LA0EUHEQRRRFFFNMoWmkhWkgasTIhSEialKktLILtFcbKKjkTtDDmTAI2Nn6V+QVWlmlstbBNfkFkbm8vd7t3BwlWGRiueG/nvTf7lgPGETMA5gEsOd8pNWFUTAJYARAL4IKaPCwmAKzaYrv5OFKVMk5u60iWip4ii+qhYUArYogXEsg0u8i2+i7TVsdTRDQRTeZotoqD6VrbJy6ZLF8GCEWR9+eDCKjC7hS1tsz5xeZHF1v9IDLm5C2rBdbsQKbxo4mTqaopC3xi/fwLG2YQGQsrwJFithWqeLbZsy9etyGKvFMfpt0gi8hJMg8dHBo5J8Z7mnUOR5E5gWBA7USSFqqbwdXm6gp7BekEmw0Fg8KuQdcUoZgXLOYVVhk6BV+zOrJKHhZrbVzlcP/cQfO9D+vlGyXL+zC1SdiV2kk486dxNN66triX5bp8M9pbYHcxY+csV9m/KIfRLXDdMjVxkhOJHFqoF6juFc3WQakfRrfA3VNbE5ccTOrDnGZDFGmFKkyysMjhPfnATeEL1MXCaDkXLNl47aFgJJw4HRkZXN3BJDePln0nR8fbnu7V1R4a/AnpU4mfFtf9X8DVphXy98rf7ZjhD4MB7sEYgcwvAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("88d0a17a-aa52-4449-b95b-3c7e271d03ce");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_88d0a17a() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Pset",
        nickname: "Ifc Pset",
        description: @"Create a Pset and add to object.",
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
