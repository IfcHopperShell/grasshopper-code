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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAddJREFUSEvdlb9PwkAUx1+Mxmg0RmM0dtHopIPRwbAYJyHEEFwYmR0ciGsHcXKiFaKDSgUSFhd/jfwFTo4srjq4wl9Q73t3lWt7RUQmvsknTfpe3697l9JQaoIxzZiTzzHGQDTKWGAYGmYY/9IIY5Fh0GY2RsmiRQdXZUoU8vydYJbRtzAKg2K5OKWrLTqsuT+knCa3CUQR3YFPaKziw9RNwxfcI2GdcXvv4Px8EgZdcIDE0ueLVl9btObqgE36zTN8WmIYlK58ahMkSza3M95o+eSdVmwdsEm/UAK0ZPBRhBJU2/zgZYIewZn6NM4QRiTxOknfNWnXzEgbzmmSgY+7AR+tYFCrUMEIg5uB1cbqivEKMAkUGykYxbgEqBpBEEwVkqmBg0R2gdusa1sFH4u1Ns8zdPvQpOqLS87jBxUc9WKGOkFVahXdyR7FqPLc4sFVrLJ3Z0J3AdUZ5sZxprh9akUBH85FzQ4FB+hI+GCEPvEEpa28XdspuFHAh3N939AmAJ5PQFMMz/A7GIUuOBILH5yTT9gU3MBwsCgcecAelac25cy4tGMifQurK5Kgk8u6w89kb39dvkf1wdX+s/AT6nTTAT8trPtAhNXGKLCSeOJ3O1Qi+gaDAe7BA4awQAAAAABJRU5ErkJggg==";

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
