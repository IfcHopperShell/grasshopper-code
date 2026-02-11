using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_f398313d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "f398313d-41a2-4938-88e8-c128eb3e2253";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAT5JREFUSEvNlYFJxjAUhIsoggjygyC6gRO4iIO4gRP8C+gGTuAgTqATOIHeBz0I8V5IfxE8+CA0965tXpou/0GnYieuxM0KY64xd7BOxKVwaAUevJt0Jq4FAXfiSbyLrxXGXGMOD15qpsRr++kehEMr8Ng/9SZe60eRAhN4qaF2qHOB8V6koBHUUDtcKjf1VaSQEdRQS0YpDJACPsXzCuPkcX3UsWCSnZGK22ZWzfeuIuuHvHuq9fcaz3jiB3gkmLwVqfhNMAeMk8cPQFaUt2gVMIIaaodblfMF08wH1uMekVHKjYYPkYISeF0XG9zKb1E1MuHmDp/eokE+6PYiBbbgwUtN2dxe7YH3IlIwMGff5n8DZ8roJm349FHdy/3ob9KGX4hfqb9JGz7V1Bm1y2UOXpZKBLJTNv0e/1jL8g3pSrfa/nXQdgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("f398313d-41a2-4938-88e8-c128eb3e2253");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_f398313d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Georeference",
        nickname: "Ifc Georeference",
        description: @"Adds IfcProjectedCrs and IfcMapConversion objects to the model.",
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
