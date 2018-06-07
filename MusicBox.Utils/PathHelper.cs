using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicBox.Utils
{
    public class PathHelper
    {
        private static string DirChar = Path.DirectorySeparatorChar.ToString();
        private static string contentRootPath = DI.ServiceProvider.GetRequiredService<IHostingEnvironment>().ContentRootPath;
        public static string MapPath(string path)
        {
            return Path.Combine(contentRootPath, path.TrimStart('~', '/').Replace("/", DirChar));
        }
    }

    public static class ExtensionsMethod
    {
        public static IServiceCollection AddWKMvcDI(this IServiceCollection service)
        {
            return service;
        }

        public static IApplicationBuilder UseWKMvcDI(this IApplicationBuilder builder)
        {
            DI.ServiceProvider = builder.ApplicationServices;
            return builder;
        }
    }
    public static class DI
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
