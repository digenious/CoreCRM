using CoreCRM.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace CoreCRM.Common.Helpers
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Register Data Accessor
        /// </summary>
        /// <param name="services"></param>
        /// <param name="path"></param>
        public static void RegisterDataLayer(this IServiceCollection services, string path)
        {
            var dir = new DirectoryInfo(path);

            var libs = dir.GetFileSystemInfos("CoreCRM.Plugins.Configuration.DataLayer*.dll");

            foreach(var lib in libs)
            {
                var assembly = GetAssembly(lib);

                var registrationType = assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IDataAccessProviderRegistration).IsAssignableFrom(t));

                if ((registrationType != null) && (registrationType != typeof(IDataAccessProviderRegistration)))
                {
                    var instance = Activator.CreateInstance(registrationType) as IDataAccessProviderRegistration;

                    instance.Register(services);
                }
            }
        }

        public static void RegisterPlugins(this IServiceCollection services, string path)
        {

        }

        public static Assembly GetAssembly(FileSystemInfo lib)
        {
            Assembly assembly;
            try
            {
                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(lib.FullName);
            }
            catch (FileLoadException)
            {
                // Get loaded assembly. This assembly might be loaded
                assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(lib.Name)));

                if (assembly == null)
                {
                    throw;
                }

                string loadedAssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                string tryToLoadAssemblyVersion = FileVersionInfo.GetVersionInfo(lib.FullName).FileVersion;

                // Or log the exception somewhere and don't add the module to list so that it will not be initialized
                if (tryToLoadAssemblyVersion != loadedAssemblyVersion)
                {
                    throw new Exception($"Cannot load {lib.FullName} {tryToLoadAssemblyVersion} because {assembly.Location} {loadedAssemblyVersion} has been loaded");
                }
            }
            return assembly;
        }
    }
}
