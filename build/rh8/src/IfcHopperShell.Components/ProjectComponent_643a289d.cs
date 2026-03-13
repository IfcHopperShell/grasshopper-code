using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_643a289d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "643a289d-f1f2-487f-9618-70ba13c27651";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAoFJREFUSEvFlU1oE0EUx192EwSJpIoxGCsRzEFPaRBvYqwXRSop6MVeAkIx6KGxqBUUam3tpXhoBKlYGsQEmtTmoyRG0aQQRXtQBIOHnhRPtihJStpqG/bJG3eXdNlkYwP6hwc7szP/37z5BPjP2gIAOwBgp0psAwBO2eFvpAcAKwCcBIBuADgDAO0A4ACAPeK/Xc1AaPRWg8FQdjqd83a7/avFYvluNBqXOY4TAKC1WQgD6HQ6VIrqeJ4nyN5mIHUBpGYz0QSQOI7Dza5JQwDSZiDUwNQoQKoTARRGpWG1yJxGwRqrmen1emaoDJ7n18V+dE5UJZt7hsLeI33Jb65LY8x0xTeEpX0urHz4pOTJqspCFbDB3HQuKDh8CTR1hbC3P4Yl21FccnRgscVZE6IFoKMvm7tupLFQ/oXPbj9CcAewz59FoVBikKW20+xbKS0AVVpbz4fX3cMZuVMR9mPm2n0GIUmQsvtClfUfaQFo5a0dA+m8rXsKXw08xcDhEfwyOM4gYzM5hIk4RhMZNk0rPYNKf02AQdo5sd7oWqjdj/03U2zkucRbZh6+dY/BFrouK72ZtABsDdK+SJ7M74zmmPnIw9csk5m7EWa+7LmKtshz7Jn7qPRvDDB9dnw17Z2UO7UEUzgxnMLQcb9c1/lyDh3xrFyWpAVgV0P4esAbPDYq0BqQPLn3DDIdfIOFn2vYFp9FUzCJ7xZ/YKVS2RBaABLLQoJkrsRwyv0AO6NZgSDM/HFSOHjilEA3qTLMZnNeBNArWFPbqyGpi5OfqXwoPls88OTFqicc90qboUbsFmejrhikTtCJJxO1oKe2IW0VU6VblbYwlWkK696U/1y/AYF7foEjP2l+AAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("643a289d-f1f2-487f-9618-70ba13c27651");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_643a289d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Model",
        nickname: "Ifc Model",
        description: @"Create empty IfcOpenShell model.",
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
