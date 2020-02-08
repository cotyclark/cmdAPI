using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CmdApi.Models;

namespace CmdApi
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

		public Startup(IConfiguration configuration) => Configuration = configuration;
		// public Startup(IConfiguration configuration)
		// {
		// 	Configuration = configuration;
		// }
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<CommandContext>
				(opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseMvc();
        }
    }
}
