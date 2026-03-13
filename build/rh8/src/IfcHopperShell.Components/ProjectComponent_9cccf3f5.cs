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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAi5JREFUSEvlVc1LG0EcfRShIIIoRev2YFh7iWipRNmL5JQUD1YPzTFeLHjoIYoX2UMDFUTTJI34Wbr5KIqFSm17qv4D3jzupR5jDyKiyV+Q8mazcbIriZpSCn3wYHZm9r3ZNzP7A/4RNAFoA6CUyTb7GsY9AK2SsJMc45w7oRlApy0W65+bTg/F8iTbkkkXgBbny7VwXxYm1wbeGLmheEmm4Vs09d5XIWke3+G7NXGVc3hKw+r2B0T0IJ/n+2YnM4OxE6fRpm9hP+x5oUlG1LgWjESBP+BF6mMC2e+lCtd3Pot+QFl+Gk1mB98WnUapgdcJ/0NNzClrucAsLYN3uSQyX4tVJplvBcSNKOdQaMM3v2uL05DG0ldQqwrMToEWCeJZXIiIiNZ2dqtMSGMvD31BZB95/DLI/bEjMuGJfkKXiNS5H5bBsB7CeK6E5+m8aLOPYsYX02W0smXYK/6BR6FzqPkCekps1zewObq5jydhawOXNmZEbCTbgBJHp3YK9ZDCNm9nYHMklUC33yv2xx/wTqDdewxPQhZuzIAcyxb4NVz1JXoKTuHGDchhPUQBp+j/YUBYl2Q8W3QJ39DgAmqxonMN2sUAj+Xo+wOXeB2DX1APeADK4tRygf/1jsoKGNdY2qxncAbVlGIhqVGzRvDfbv2XyMDSTCU2yYBxHKFbXLgyb1UXqisZL9nIctI2+AlPkpdNEr9zZWPdfSAJOcmxP1KbeeTkKnej6vVX8BvvrbZCg/IjjwAAAABJRU5ErkJggg==";

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
