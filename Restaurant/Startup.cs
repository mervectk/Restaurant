using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using Restaurant.Data;
using Restaurant.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                CloseButton = true,
                PositionClass = ToastPositions.BottomRight,
                PreventDuplicates = true
            });


            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                //merve düzeltme//
                /*(options => options.SignIn.RequireConfirmedAccount = true)*/
                                                         //silinecek kimlik doğrulamayı biz denetleyeceğiz
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = Configuration["App:GoogleClientId"];
                        options.ClientSecret = Configuration["App:GoogleClientSecret"];
                    });
                
                   //.AddGoogle(options =>                            //google+facebook ayarı!
                   // {
                   //     options.ClientId = Configuration["App:GoogleClientId"];
                   //     options.ClientSecret = Configuration["App:GoogleClientSecret"];
                   // })
            // .AddFacebook(options =>                                              
            //paket y.k. komutları çalıştırdıktan sonra tanımlanır
            // {
            // options.AppId = Configuration["App:FacebookClientId"];
            // options.ClientSecret = Configuration["App:FacebookClientSecret"];
            //});




            services.AddSingleton<IEmailSender, EmailSender>();//gerekli servisi açtım
            services.Configure<EmailOptions>(Configuration);// email için gerekli servisi açtım
            services.AddControllersWithViews()
                   .AddRazorRuntimeCompilation();//front end tarafında yapılan değişiklikleri değişiklikle günceller
            services.AddRazorPages();
            services.ConfigureApplicationCookie(options =>  //KULLANICI LOGIN İLE GİRİLECEK SAYFALARA ERİŞMEYE ÇALIŞTIĞINDA
                                                            //KULANICIYI LOGİN SAYFASINA YÖNLENDİRİR!!
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Musteri}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
