using graduate_work.Common;
using graduate_work.Databases;
using graduate_work.Databases.MySQL;
using graduate_work.Databases.Repositories;
using graduate_work.Interfaces;
using graduate_work.Interfaces.IRepository;
using graduate_work.Interfaces.Services;
using graduate_work.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace graduate_work
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ApiConfig.LoadMessagesTemplate();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
            })
            .AddCookie("Cookies", options =>
            {
                options.Cookie.Name = "auth_cookie";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    },
                };
            });

            services.AddDbContext<MySQLContext>();

            services.AddTransient<IAuditoriumRepository, AuditoriumRepository>();
            services.AddTransient<IAuditoriumImgRepository, AuditoriumImgRepository>();
            services.AddTransient<IClassImgRepository, ClassImgRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IFamilyMemberRepository, FamilyMemberRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
            services.AddTransient<ILessonDurationRepository, LessonDurationRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IPersonalDataRepository, PersonalDataRepository>();
            services.AddTransient<IPersonalImgRepository, PersonalImgRepository>();
            services.AddTransient<IProgressRepository, ProgressRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();

            services.AddTransient<IUnitOfWork, DbUnit>();

            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IEmailService, EmailService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "graduate_work", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "graduate_work v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
