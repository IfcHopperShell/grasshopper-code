using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_9cccf3f5 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "9cccf3f5-684f-4b6f-8e20-3bcdb797da85";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAjdJREFUSEvdlc1rE1EUxQ8iCCKIRawdFw1TNxEVS1pmI1k10kVtF2YZNwouXMTiRrIwYKHYNIkpWltx8iFKBYtfK9t/wJ3L2egyuhARTf6CeM+bvHEmGdKmEREv/ODlvvfOmdw3by7+ldgvHBGMNhwzN3DsEw4LWrgTznHNnuKgMCwosdyZWzfKk7k64VjnhRHhkLDrOCB4wmR1/I5dm8y3/Nixu07m1PWkbx33cG/P+F3n1DULD549RjqT4O+F0zevVCZynzuN1mOLW6nIJcvb52qEBktiID4VRelJAdW3LY+HGy9UXuZXzmWL1YnlZqdRafx2IX7cUmvaWl3BWroG92pFVF43AyaVNw3k7SzXUGgttrCpxWlIY7XfhVqBYO0MWOkELuSViCrR6sZmwITYr+rILKrap09eTfB8dIkcRLLPMaJKKgTOwzU4n0lirtbCxXJdjZmjmP3S6TK6/9RW88I7nEh+h1lvYKzFcTvfw0Azs76Fsyn3AJfW5lXZCMeSy2PY+grzPYU1/RlopksFjMaj6nyEyxiKfkKk4BcezIDMVhv8N3zqnxhrhImTvRsQmadAmLDm/zVgMGlgrtoMFSc7GPyA2fR0QmJIMNRrOfNou1+DLzC3+QIoDVerK/hdPya4T8ByzZadnQy+wXR8ZSHU6Nkj+G13v0tkamneK5vPgOX4gFF14dr01ReCnYyXbHqlqA0+IlLkZfPmB+hs7LtHBS3UCef+SG/mK+fvcrvqXn8hgF/vrbZCLfIZkwAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("9cccf3f5-684f-4b6f-8e20-3bcdb797da85");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_9cccf3f5() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Object",
        nickname: "Ifc Object",
        description: @"Create an Ifc Object.",
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
