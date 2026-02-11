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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAThJREFUSEvFlesJwjAUhYt/BFFEEEE3cBA3cCwdRBfQCZzACXQBnUDPBz0SStq0jeKBj3Bv7iOPRot/aSDGYi6WYlWO2PiZ762RcNE6mCeusybCRbbiJB7iVY7Y+B1DfGuxIiceBEXrYN6xrXbCmfpYwuJ7sRH4GbGrTchL3gkXRzDbdwEXroLfMT4u8hvF10HgWZDISrEXYigQIzZ+74R4bPIb5ePxhXr1Lm5h4/cuiMcmv1EEAUlgO6YusR95B09BUmoHviviWzX4+R3kfkXJtxC+g6NwgZ1wI0Zsz93EWjA3E0mFLzlsEuNejlfRqUn1t4gz9sUz0hg/RSneqwk78XE1kdUk9n8A2CyAItlNUko1mYpsxZpcSh98RWETivuzTj6+LnITw4vP+t+OiTP3yr9evEZF8QYVj2iF4f3w0gAAAABJRU5ErkJggg==";

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
