using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.liuning;
using IOT_ErpManageSystem.DAL.DBHelper;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.DAL.liuning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IOT_ErpManageSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDBHelper,DBHelper>();
            services.AddSingleton<IRequDal, RequDal>();
            services.AddSingleton<IRequBLL, RequBLL>();
            services.AddCors(options =>
            {
                // Policy 名稱 CorsPolicy 是自訂的，可以自己改
                options.AddPolicy("cors", policy =>
                {
                    // 設定允許跨域的來源，有多個的話可以用 `,` 隔開
                    policy.WithOrigins("http://localhost:52645", "http://localhost:52649")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
