using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.GoodsInfo;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.BLL.Supplier;
using IOT_ErpManageSystem.BLL.TuiHuo;
using IOT_ErpManageSystem.DAL.DBHelper;
using IOT_ErpManageSystem.BLL.liuning;
using IOT_ErpManageSystem.DAL.liuning;
using IOT_ErpManageSystem.BLL.InRBAC_Role;
using IOT_ErpManageSystem.BLL.RBAC_Allot;
using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.BLL.SManage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IOT_ErpManageSystem.DAL.IDall;
using IOT_ErpManageSystem.DAL.Dall;
using IOT_ErpManageSystem.BLL.IBLL;
using IOT_ErpManageSystem.BLL.BLL;

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
            services.AddSingleton<IGoodsBLL, GoodsBLL>();
            services.AddSingleton<IDBHelper,DBHelper>();
            services.AddSingleton<ISupplierBLL, SupplierBLL>();
            services.AddSingleton<ITuiHuoBLL, TuiHuoBLL>();
            services.AddSingleton<IRequDal, RequDal>();
            services.AddSingleton<IRequBLL, RequBLL>();
            services.AddSingleton<IDal, Dal>();
            services.AddSingleton<IBLLs, BLLs>();
            services.AddSingleton<IIStorageManage, IStorageManage>();
            services.AddSingleton<IOStorageManage, OStorageManage>();
            services.AddSingleton<AllotInterface, RBAC_Allot>();
            services.AddSingleton<RoleInterface, RBAC_RoleBll>();
            services.AddSingleton<IStorageStructure, StorageStructure>();
            services.AddCors(options =>
            {
                // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
                options.AddPolicy("ZXL", policy =>
                {
                    // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
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
            app.UseCors("ZXL");
            app.UseRouting();
            app.UseCors("DSZ");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
