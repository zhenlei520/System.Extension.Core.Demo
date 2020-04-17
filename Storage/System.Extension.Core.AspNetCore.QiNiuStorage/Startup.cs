using EInfrastructure.Core.AspNetCore.Exception;
using EInfrastructure.Core.QiNiu.Storage;
using EInfrastructure.Core.QiNiu.Storage.Config;
using EInfrastructure.Core.QiNiu.Storage.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace System.Extension.Core.AspNetCore.QiNiuStorage
{
    public class Startup
    {
        private IServiceProvider serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddQiNiuStorage(() =>
            {
                var config = new QiNiuStorageConfig("accessKey", "secretKey", ZoneEnum.ZoneCnSouth, "访问图片域名", "空间名");
                config.SetCallBack(EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Enumerations
                        .CallbackBodyType.Json.Id, "回调地址域名，后不加/", "回调地址相对路径，前需要加/",
                    "{\"key\":\"$(key)\",\"hash\":\"$(etag)\",\"fsiz\":$(fsize),\"bucket\":\"$(bucket)\",\"name\":\"$(x:name)\",\"mimeType\":\"$(mimeType)\"}");
                return config;
            });

            serviceProvider =
                EInfrastructure.Core.AutoFac.AspNetCore.AutofacAutoRegister.Use(services, (builder) => { });
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseErrorHandling((context, exs) => { return false; });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet("/Check/Healthy",
                    async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}