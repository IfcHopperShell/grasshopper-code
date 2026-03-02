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
    static readonly string s_assemblyIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA8pJREFUSEvFlf1PU1cYx/mBzSgqaMzGgiKrbBMjpgIV2t7WFsqbHQJBRIEsLNNkNb40/KDN0NElOjY345gr0bjZRaOSDMWYq5kYaLWbzg1T7GDCfIGKqJsmnvsXfPc8V0vcVhwLLPsm39ycl/s8z/mcc++J+b9VRg6SH5PruGOylEBuT39lNo7WWHG01gpq+9WRSRAHD1ZnpCK8Yy34SW1BnrQVtHPQwKYSxE99kYMPkhnTXh6cqCzJs6arlTMeakPSJKqYuJ/aWnXWBORrWWWEw7hIDd5SYVRXwkmo3aPOmIBSItUzmsDGEnAy6n/WjMtHZlyl5H8lJ1fOJ4Yr56dDWgh5gw2hxpUQniqEPrRD3mqGqzwN0qI5kYRb1LfHIb+8rhDy+kKI3bUI76qE+HwNRMtqBN63QXaZITeYEP5yBcQ3JRDtdgSaJUhL1L3iQ/CP+/NYfFIDsXctxL4qiP0UuNGG5Dlxo4i0Wi0kQxaqbUkIn8iD6MyHuJCHloY0HueP8blJVAziAFX+VQVCewpHA7Pdbjci8nq9SH9tBkIn9RA/LYcImiB70yNJUshRBXGoAuJwOcSxUrgq3xgzAYv7qle+DKXPCGVAD+VWDj5qnM/9fAiiCqKVNrPtTYhTdjStV5f9JzudTvj9fpSVlY32KbezoQzroNzPgvIwA8nJU7g/Kiq/vCsH4kwRREcBwqetcL2tgeudV+FYMxdSZsJo0IjjZ8ZCeZAJ5dFSjPyWif4RHeqfrOIz8t/0teutBRA+G0QgF+KyFaKb+PaYoPQShn4DwkEdXM4kNTDNh2fffIQpQe9dHS4N5eDbmwZ8cFjdi6g/RgtvnLhigbhqhrhGgZnvr8SXMdxZBuXeEww+Xxr2H0pFz/AyXBzMgXzDgOO/SDgQMsNxUDtmApa/aZsGynUDlBsUePAp36cY7v+eiYF7OnTfyUbXLT1ODRhxpM8Ez7XlaLpqxXtX8mDaoh6OqIhY2lkzY8V3ZxdDGaFqieuxIxoM07OP+P4wlI2Om3q09Rvh7TWjuceCnd252HrZhncDBajxFWFa4jROwBfVmKpLiI+F54sUDD7IgqM+CQ2fLsBZwtB6XcLBn83YE7TA/WMu6i/ZsO5iAaq6ilHcYUdK7evPxfOs+JgNFa16Cc2ntYijTa3cloqPCcN2wrD5+3zUXShERWcx8s/ZIbUVITF/HgfnPy5fWOMST3STxdQZL/DLSFo6G5adGSg9vwI6jxna3XrMLdcgdro6ztzHHfyvYqacjK9NrpID8jXKOJzkMX8P/7FiYv4AF2ldXIMWweMAAAAASUVORK5CYII=";
    static readonly string s_categoryIconData = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAlxJREFUOE+Vk11IU2EYxyVHWyt1osUsV6Y1zc20Nqf7UmfHPCnUKT9b2tWEIIWKBRFWXkR6YSkzujASS4QgaMHULpLswqxQrOhjZZnRqGVOOIcuvNjFv/c9R5Bi0frBA+95nv//eb/OG/MX0kgw0vD/kJHoOrI7I1yelQoyzhKzUSJTKeR3BhscqMlNXyLfYzQnVqLk2LVqKwrTNiA9KS5cm5dOV1Atlf6NbGdKYqC9Mh8H9FvgOWTBxoS1YZJ3kYhqGww1t9h16KsvQpNNC89hEzyNRrSw21GgTQwQTQcJlaiOQMe0m8PMhSqEuurw5ByLVk6PM9wODLpNCN3dh7EeM8w5qgWijXg7/XxPPfjeGtw7bYcsdhUUCgW8Xi98Ph84Rouvo8UIPSsCV55Mt1Yi2Vbo528dBH97P5wODT08sYHf7weFYRicdKVCmDFjcTYfuuw1c0SjEJ3LdL+9sQf8CIu+1hw4K1JgM6iQEC+HWq0WGzprk8HPGxD8YUB791aa40TnMg29Z/XgH5eCnyyG8NIO4Z0F8/58XDyvgUazGiOj2XgeMOHBRzMuDxtogzbJKqHYpYsLLr6wissUPhdA+GZEiMz4KWjExKwJwx8suPnajs7pEhztNdIGJyTrCuxxlzosfDdgaCgTb74YMT5XCO97K66/KsKlKQdOTTBofMRic9kmepDbJNvvcDZH/M/OgWzYKtfjylMb2iZL0TxehrqHLPber0Bag5bO3izJI6MmcVWujF1QJsmX8poyoXfnQlOVAWXquilSY0VVlNCrondOfx76xP8gJuYX8EANraJrT/4AAAAASUVORK5CYII=";

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
    public override string AssemblyVersion { get; } = "0.1.9557.21510";
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
