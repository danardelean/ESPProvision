using System;
using Microsoft.Extensions.DependencyInjection;
using Shiny;

namespace ESPProvision
{
    public class ESPShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {
            services.UseBleClient();
        }
    }
}
