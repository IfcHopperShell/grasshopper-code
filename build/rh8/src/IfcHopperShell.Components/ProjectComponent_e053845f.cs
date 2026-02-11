using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_e053845f : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "e053845f-ad10-481f-87a5-dfb8330521f8";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAVZJREFUSEvFlDFOxEAMRSNEhURDgcS2OQt9Cq6YAu6xFFtT0tKTEyx+q/yRyf4JsxGILz0pGtt/Jh4n3X/rKrgJ7oL7YDfDM2vEyLlYFN0GD4FMa5BDbvNG10E+7VPwHLwFxxmeWSOmPGp+3IQEnfox2AcyrUEOudRQW92EgE5OwWfgDB3kapPqm9DHLeYib4LXN+XWVNsyDMMBXGyGWjzOWsW4EeDSXOGJaZrewcUSung8i5hpFl8CV3Si7/sPcLEEHnjhWaTLzaO4FTzwwrOIBXAFBcnFFsiv6M83aGqR5GIJ26KmS5ZcLGEvuWlMJRdL2DHNH9pr4AqP4zjuwcVmqMXD/pPyr2IKnMEa1FR/FYgdddmXbpLN8Tg7vZRbRUG1XQlyZG5bs1R+E+DSmIw8wjyzpguF1ZMvRSJ91NusQQ65zeZZFDFuzHR+K55ZI7bJ+JfUdV/9ojHwMM6XewAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("e053845f-ad10-481f-87a5-dfb8330521f8");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_e053845f() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Info",
        nickname: "Ifc Get Info",
        description: @"Get object info given the step Id.",
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
