using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace RazorEngineCore
{
    public class RazorEngineCompilationOptions
    {
        public HashSet<Assembly> ReferencedAssemblies { get; set; } = new HashSet<Assembly>()
        {
            typeof(object).Assembly,
            Assembly.Load(new AssemblyName("Microsoft.CSharp")),
            typeof(RazorEngineTemplateBase).Assembly,
            Assembly.Load(new AssemblyName("System.Runtime")),
            Assembly.Load(new AssemblyName("System.Linq")),
            Assembly.Load(new AssemblyName("System.Linq.Expressions"))
        };

        public HashSet<MetadataReference> MetadataReferences { get; set; } = new HashSet<MetadataReference>();
        public string TemplateNamespace { get; set; } = "TemplateNamespace";
        public string Inherits { get; set; } = "RazorEngineCore.RazorEngineTemplateBase";

        public HashSet<string> DefaultUsings { get; set; } = new HashSet<string>()
        {
            "System.Linq"
        };

        public RazorEngineCompilationOptions()
        {
            // Loading netstandard explicitly causes runtime error on Linux/OSX
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                this.ReferencedAssemblies.Add(Assembly.Load(new AssemblyName("netstandard")));
            }
        }
    }
}