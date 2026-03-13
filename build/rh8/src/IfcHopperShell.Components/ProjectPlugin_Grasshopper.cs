using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Resources;
using SD = System.Drawing;

using Rhino;
using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class AssemblyInfo : GH_AssemblyInfo
  {
    static readonly string s_assemblyIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA85JREFUSEvFlf9PlVUcx88PVPMboHNFw5CQvuCiXblc4XK/cC9cvkl8GyIKrNHSLVrlHT/oXVTQplGWMzKYzpKm09yicO7miqb36i2NgoEECaHBlVCoNs/zF7zaeQCnN8Av1Xptz57tnPO83+e8z+c5R4j/mWIhRI8Q4roQojq0858QKYRoT3x4GUcqnRypciKE8IcOuleUeE9FUjzB1zeh3kII+W+uoF2JBl4uIGLB/Up8ZDqmPaED7wVHzNLF+sxVPEIIrHFRekyqXQhhCP3gbvG1rLdQY1mti7eUWvSVKBMhRG/o4Lsldmb2KprASwUoM2V006Pi8k3HVRQqcDvcauaqYtTM1bvG+iTeF1301Rcim8vpeysf7zY7npIErKuXzxhuDRWaC793cw7eLTnIXVUEd5YhP9iIbNlA4A0XXo8db52N4EfrkJ8VINvzCTRZsT6t75Uqgtvuz3X5biVyzybk3nLkvg0E6l3ELF90IyKDwYA1LZkKVzTBzzORp7KQZzJpqUtQ/epnnNdEj0HuL0N+XErf7pxb8m9oaGCG1tZWEh9bQt8XZuSP6cgeG97WxBmT2FDhGZAHS5GHSpBHi/CUPTGngUK1VRQ+hDZgQRsyo11O5e36lapdFcGsII8VItueQR7Pp3GLvuxbHrfbjd/vp7i4+Eab9msK2pgJ7Voy2h9JxMQ8oNpnjcrv3ZmK/DIX2ZFN8IQTz3NxeJ5/lJqNK7AaI/9mGBEehjZhRPtzDeOTRgbHTdROreL9UHHFJ55nVyF9LmQgA3neiexKR/ba0PotaINpBHtMeNzRurAyaN67kuCEkf7fTJwbTeWrS2m8eUjfi1kPRofaONnpQHbbkRdsU/n+Yp6K4cpatKtTMfh8Cew7GE/v2FrOjqTiHU7j05+t7O+zU3PAMKeBwt+4PQ7tYhrasBltZDrf6Riu/W5k6KqJrispnL5s5viQhcMDNpovpNPY7eTVzkxsW/XimDUihWFpeJj89uRTaOPJaJNGjh6OY2zSyMC4ie9HU+i4ZKZt0EJrv52mXgc7ujLYdt7FC4FsKn25LIxaqAzURTUn1ZERYTR/GMvIRDI1tdHUvbeKk8NpHLto5cBPdnb3OGj4IYPacy42n82m/HQeeR35xFY9Pm88N6PKbDR3/YM0nTCwKDyMsu3xvNPt5LXOTF75LovqMzmUnsoj6+t8rG25RGU9osTViasurDtCDWxQt9mCJffpVRO9ZhmOHUkUfbMOU7Mdwy4zK0riCFus96vc71g8FJWpMlPXppqlElTXqIrDPd/x8J/zFxdpXVxaNA8IAAAAAElFTkSuQmCC";
    static readonly string s_categoryIconData = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAlFJREFUOE+Nk11Ik1EYxx9ytLVSJ1rM2mppTdtmWvvQ6abOXnMp1Ft+ZtrVhCCFCoMIKy8ivbCUGV0YSR8IQdCCqV0k2YVZoVjRx8oyo1FrOeEdXXixi3+cUTBeU/xdPpznd56Pc4j+j4aIOHFwJUiIqPvI7vRIWaYKRJQpPrAcEoVMem+gwYHq7LQFIhr9K1wxx65VFSBPswFpyfGRmpw0VkGV+NBSSHamJvk7Ksw4YNgC96F8bExcGyEi10rb4Fhyi12P/rpCNNm0cB+2wN1oQotzO3K1SX4i6iQihTjxH51TrTymL1Qi1F2LZ+ecaOMNOMPvwECrBaH7+zDaa4U1SzG31HZuCr11EPqq8eC0HZK4VZDJZPB4PPB6veA5Lb6PFCH0ohB8WQprrXix4PZBCHf3o96hZsOLCnw+Hxgcx+GkS4XwtBXzM2bodWtmiUgWK+h5f2MPhGEn+tuyUF+eCptRgcQEKZRKZVRYX5MCIWhE4JcRHT1bWYyPFTT0nTVAeFoCYaII4dd2hD/kI+gz4+J5NdTq1Rge0eGl34JHn624PGRkgvZYgWyXPj4w/6ogWmb4ay7CP0wIBY34EjBhfMaCoU/5uPXWjq6pYhztMzHBiVgBw3ncpYyEfxoxOJiBd99MGJvNg+djAa6/KcSlSQdOjXNofOLE5tJNbJDbxAIGb3Mk/O66o4OtYj2uPLehfaIEzWOlqH3sxN6H5dA0aNntzeLEWJREdFUqj5uTJ0sXcpoyYGjNhroyHXLVuklWqThhOdiq2M7Z42FffBF/APBADa0mEdeKAAAAAElFTkSuQmCC";

    public static readonly SD.Bitmap PluginIcon = default;
    public static readonly SD.Bitmap PluginCategoryIcon = default;

    static AssemblyInfo()
    {
      if (!s_assemblyIconData.Contains("ASSEMBLY-ICON"))
      {
        using (var aicon = new MemoryStream(Convert.FromBase64String(s_assemblyIconData)))
          PluginIcon = new SD.Bitmap(aicon);
      }

      if (!s_categoryIconData.Contains("ASSEMBLY-CATEGORY-ICON"))
      {
        using (var cicon = new MemoryStream(Convert.FromBase64String(s_categoryIconData)))
          PluginCategoryIcon = new SD.Bitmap(cicon);
      }
    }

    public override Guid Id { get; } = new Guid("295b15b1-3500-40a2-b08e-8b333981d480");

    public override string AssemblyName { get; } = "IfcHopperShell.Components";
    public override string AssemblyVersion { get; } = "0.1.2.35556";
    public override string AssemblyDescription { get; } = @"This Grasshopper plugin integrates the IfcOpenShell library directly into Rhino and Grasshopper, enabling users to work with Industry Foundation Classes (IFC) files within their parametric design workflows. The plugin provides a comprehensive toolkit for importing, inspecting, editing, and exporting BIM data using the open IFC standard.";
    public override string AuthorName { get; } = "Mattia Bressanelli & Luca Florio";
    public override string AuthorContact { get; } = "mattiabressanelli@gmail.com";
    public override GH_LibraryLicense AssemblyLicense { get; } = GH_LibraryLicense.unset;
    public override SD.Bitmap AssemblyIcon { get; } = PluginIcon;
  }

  public class ProjectComponentPlugin : GH_AssemblyPriority
  {
    static readonly Guid s_projectId = new Guid("295b15b1-3500-40a2-b08e-8b333981d480");
    static readonly dynamic s_projectServer = default;
    static readonly object s_project = default;

    static ProjectComponentPlugin()
    {
      s_projectServer = ProjectInterop.GetProjectServer();
      if (s_projectServer is null)
      {
        RhinoApp.WriteLine($"Error loading Grasshopper plugin. Missing Rhino3D platform");
        return;
      }

      // get project
      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["projectAssembly"] = typeof(ProjectComponentPlugin).Assembly;
      dctx.Inputs["projectId"] = s_projectId;
      dctx.Inputs["projectData"] = GetProjectData();

      object project = default;
      if (s_projectServer.TryInvoke("plugins/v1/deserialize", dctx)
            && dctx.Outputs.TryGet("project", out project))
      {
        // server reports errors
        s_project = project;
      }
    }

    public override GH_LoadingInstruction PriorityLoad()
    {
      if (AssemblyInfo.PluginCategoryIcon is SD.Bitmap icon)
      {
        Grasshopper.Instances.ComponentServer.AddCategoryIcon("IfcHopperShell", icon);
      }
      Grasshopper.Instances.ComponentServer.AddCategorySymbolName("IfcHopperShell", "IfcHopperShell"[0]);

      return GH_LoadingInstruction.Proceed;
    }

    public static bool TryCreateScript(GH_Component ghcomponent, string serialized, out object script)
    {
      script = default;

      if (s_projectServer is null) return false;

      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["component"] = ghcomponent;
      dctx.Inputs["project"] = s_project;
      dctx.Inputs["scriptData"] = serialized;

      if (s_projectServer.TryInvoke("plugins/v1/gh/deserialize", dctx))
      {
        return dctx.Outputs.TryGet("script", out script);
      }

      return false;
    }

    public static void DisposeScript(GH_Component ghcomponent, object script)
    {
      if (script is null)
        return;

      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["component"] = ghcomponent;
      dctx.Inputs["project"] = s_project;
      dctx.Inputs["script"] = script;

      if (!s_projectServer.TryInvoke("plugins/v1/gh/dispose", dctx))
        throw new Exception("Error disposing Grasshopper script component");
    }

    static string GetProjectData()
    {
      var rm = new ResourceManager("Plugin.Data", Assembly.GetExecutingAssembly());
      return rm.GetString("PROJECT-DATA");
    }
  }
}
