using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_9d7116a3 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "9d7116a3-0d9a-44fc-bbc2-68b3089c1c30";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAthJREFUSEvNVV1Ik2EUPsTEimxbhP0gKHixQsgoQshREHURDcwIKhPtopsgwi4ikMDsRshqOWhX4TehjQp/09qQauWwNIhZdmMDhwlDobVNFBHJE+fwvR/vPrcv5009cNje7Xuf57zPc/YO4D9CHgBsA4DdALAdALYAQKG63gEAm/QbckE+AOxSyYxqs37jWkCbmKD2bsBnvvBkxdEc+ErrWG2DLwmlmDxeN7lekTRyqFLQXONFem1p6YkQear4CK5XhDzlDdxxlYL1bSFMzC/h9aYeFul/0IWEhfobLJJwXB6XRMhWQ3CAjmb/uCAnLAdHMLHvFFZeecoi4cl4mgjZpgrQQBiCOyHPLTVe7jw+MYszLz5h0rxfE3EOT6AnMoUriRSmSo5iqujwsnQKQ/BICu+ftb1D5VArdp9XMHCrnbsNuL0I7b1Y6R3ARLlDfwIaZUNoAQ+0Do4J8oqr3WzNUN/HVeSjt13TuQTNJwg0dvqIvK/Go5ErriE+jbtzRCP/4vSw4Dl/yL/WE3DIXWcfL3qPuXBpbpEDfRmJYXn3G/TVdbDIjPct/o5Oc9AlzwdZxCiDDdJ1wKWd4GIHi0TnFphEiET6x5n80tBn/tzhD4lRpQbTQHeNuA72AsA9ABgGANyYl7+0Z2sp3jx5jckeDoY1ERI8/XqE12cCoQ9Sc2l3E3UuLq4TAJAkYpPJNG+322fKyspmaU1VXFCEjw7cwUb/6BjboVbtq/diejIGXKB+USGTR6NR9Hg8GAwG0e12/xQiOy2Fv+h5Ij3YG0z+jZwgrGFLqKqrq787nU5+TxUOh9FisfwQawBokrNSObJeD0KAPMwqYLVapzII0H+BVc0wK2SLUrJFiqIIi+IS+Tep86xdy6CQqRMRsiZCIdtstpiOnKaMnjXriYygH9P7kmUkSO8bpM5XzflaQCehn7gcXqbKqfNMIF8pOGGb6JiITfqH/yn+ABNzzNU/KdgvAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("9d7116a3-0d9a-44fc-bbc2-68b3089c1c30");

    public override GH_Exposure Exposure { get; } = GH_Exposure.secondary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_9d7116a3() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Read",
        nickname: "Ifc Read",
        description: @"Reads an Ifc file.",
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
