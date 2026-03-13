using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_a9cd0d31 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "a9cd0d31-ef65-4e02-9918-e92a70f93b8b";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAATVJREFUSEvFleFpAzEMhR/9EwgpIRAC6QYdpBt0rHaQZIFkgk7QCdoF2glaPvALwvjO9l1CHggjWX6yJOtOuhMeJK0kbSXtJT2lFR07+5OxDKRDwj5+3XgMJK+STpJ+JP2lFR27ffBvBjfywUMiHRL27duUCTV1WSL5u6SXZGdFz4NwrtoTGueymMDEuWC3j8vF+VHwOnA8h5uj7yQtkg8rOnZngj8650fh8rihvr3JDfSYBf4u0yicvlO3XkKP7wXO4LcxA/cK/6YAN+/B3FdUnYU4B8dA8JbNAbr3viQ9p71NTlhCnOQYpCTfaf3sDZJ/i6ixG89KYOyQQj4pSMvXFJkVpPQ/QNC5ACSzg9RQC7LOD0xBKchHyPgqiEEg97OuDl8PHMTCxFf/Eb2g5r751ckH8Q8Vj2iFOppxGwAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("a9cd0d31-ef65-4e02-9918-e92a70f93b8b");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_a9cd0d31() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Id By Type",
        nickname: "Ifc Get Id By Type",
        description: @"Get the Step Ids of the given types.",
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
