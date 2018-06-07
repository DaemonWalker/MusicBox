using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MusicBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicBox.Utils
{
    public static class AppConfigurations
    {
        public static CustomConfigModel Configuration
        {
            get
            {
                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                using (var sp = new ServiceCollection().AddOptions().Configure<CustomConfigModel>(
                        config.GetSection("CustomConfigModel")).BuildServiceProvider())
                {
                    var _appConfiguration = sp.GetService<IOptions<CustomConfigModel>>();
                    return _appConfiguration.Value;
                }
            }
        }
    }
}
