using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_5a44c96e : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "5a44c96e-c44b-4ce7-b1c8-75d96446d4b0";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAfFJREFUSEvF1eFpVUEQBeCDGERQgiKKdmAFVpAKtAGtwAq0Aa3ACrSB2IBWYAXaQDpI+GAPDC83N88f4sBw987OzJ7ZM7ub/Gc5SfIwyZMkz5O8WGrMZo7PX8v9laAJb9OnK+YouTcCXyb5kOQ8yUWSy6W/k/xYc3zqL/ZWebScPyf5k+RjkrMN1G+SfFk+fNkeHybbktPl/Gp8If26UFNjtunji5NduTv2XpBkv1YVEKvEl7KZ49MFcCHHpuiGdsr7FSyR/9dJPi3k1JjN3LvlK8a/HJud9ewgOfIgRui3ZS96Yzbo+fCdi8h1TUpek3NGYAl+u5BP9Ob48BXzc+S5Jq2AQnlYxffVLVQitqKfQG6sYHKg9JIqeHLRRGzmEGwsZpcD7HMQAL0x1EjsHkNOJes28unWtpvuHCYnPcHQ9OA4tb4I1ZbdAmOHbPr4b6WbJ/rBmuw+G5c0X1vDLjmknetC5lRrvHkvzQoa5P7pArM92eY5sWD58L/JQReAtOga1C2ZHVM/INiKfrODKhyauGXTiVAiLdqEU2/soIrbsCX7FrH/nnBjqnug11HdNvfYrmhVF9ZE1bumbSnpfAfme+CqP0rwYbGe7t6mra7vwAQC/Wb/78l83ag9nm8z3SX1GLEIdPhpZX312HdJ/edyBe84elGCd8Q8AAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("5a44c96e-c44b-4ce7-b1c8-75d96446d4b0");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_5a44c96e() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Ifc Get Info By Guid",
        nickname: "Ifc Get Info By Guid",
        description: @"Get object info given the Guid.",
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
