using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using AutoMapper;
using DentaCare.Api.Core;
using DentaCare.Implementation.Validators;
using DentaCare.Application;
using DentaCare.Application.Commands;
using DentaCare.Application.Queries;
using DentaCare.Implementation.Commands;
using DentaCare.Implementation.Logging;
using DentaCare.Implementation.Queries;
using DentaCareDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace DentaCare.Api
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
            services.AddTransient<DentaCareContext>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<ICreateAppointmentCommand, EfCreateAppointmentCommand>();
            services.AddTransient<ICreateContactCommand, EfCreateContactCommand>();
            services.AddTransient<ICreateDentistCommand, EfCreateDentistCommand>();
            services.AddTransient<ICreateEKartonCommand, EfCreateEKartonCommand>();
            services.AddTransient<ICreateJawCommand, EfCreateJawCommand>();
            services.AddTransient<ICreateJawSideCommand, EfCreateJawSideCommand>();
            services.AddTransient<ICreateJawJawSideToothCommand, EfCreateJawJawSideToothCommand>();
            services.AddTransient<ICreateToothCommand, EfCreateTeethCommand>();
            services.AddTransient<ICreateServiceTypeCommand, EfCreateServiceTypeCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();

            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IDeleteAppointmentCommand, EfDeleteAppointmentCommand>();
            services.AddTransient<IDeleteContactCommand, EfDeleteContactCommand>();
            services.AddTransient<IDeleteDentistCommand, EfDeleteDentistCommand>();
            services.AddTransient<IDeleteJawCommand, EfDeleteJawCommand>();
            services.AddTransient<IDeleteJawSideCommand, EfDeleteJawSideCommand>();
            services.AddTransient<IDeleteJawJawSideToothCommand, EfDeleteJawJawSideToothCommand>();
            services.AddTransient<IDeleteToothCommand, EfDeleteTeethCommand>();
            services.AddTransient<IDeleteServiceTypeCommand, EfDeleteServiceTypeCommand>();
            services.AddTransient<IDeleteEKartonCommand, EfDeleteEKartonCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            services.AddTransient<IGetRoleQuery, EfGetRolesQuery>();
            services.AddTransient<IGetAppointmentQuery, EfGetAppointmentQuery>();
            services.AddTransient<IGetDentistQuery, EfGetDentistQuery>();
            services.AddTransient<IGetEKartonQuery, EfGetEKartonQuery>();
            services.AddTransient<IGetJawQuery, EfGetJawQuery>();
            services.AddTransient<IGetJawSideQuery, EfGetJawSideQuery>();
            services.AddTransient<IGetServiceTypeQuery, EfGetServiceTypeQuery>();
            services.AddTransient<IGetTeethQuery, EfGetTeethQuery>();
            services.AddTransient<IGetUserQuery, EfGetUsersQuery>();
            services.AddTransient<IGetContactQuery, EfGetContactQuery>();

            services.AddTransient<IUpdateAppointmentCommand, EfUpdateAppointmentCommand>();
            services.AddTransient<IUpdateContactCommand, EfUpdateContactCommand>();
            services.AddTransient<IUpdateDentistCommand, EfUpdateDentistCommand>();
            services.AddTransient<IUpdateEKartonCommand, EfUpdateEKartonCommand>();
            services.AddTransient<IUpdateJawCommand, EfUpdateJawCommand>();
            services.AddTransient<IUpdateJawSideCommand, EfUpdateJawSideCommand>();
            services.AddTransient<IUpdateJawJawSideToothCommand, EfUpdateJawJawSideToothCommand>();
            services.AddTransient<IUpdateToothCommand, EfUpdateTeethCommand>();
            services.AddTransient<IUpdateServiceTypeCommand, EfUpdateServiceTypeCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();


            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonSerializer.Deserialize<JwtActor>(actorString);

                return actor;
            });
            services.AddControllers();

            services.AddAutoMapper(this.GetType().Assembly);
            services.AddAutoMapper(typeof(RoleProfile).Assembly);// nisam siguran dal treba za sve ovako...

            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<CreateAppointmentValidator>();
            services.AddTransient<CreateContactValidator>();
            services.AddTransient<CreateDentistValidator>();
            services.AddTransient<CreateJawValidator>();
            services.AddTransient<CreateJawSideValidator>();
            services.AddTransient<CreateEKartonValidator>();
            services.AddTransient<CreateServiceTypeValidator>();
            services.AddTransient<UpdateTeethValidator>();

            services.AddTransient<UpdateRoleValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateAppointmentValidator>();
            services.AddTransient<UpdateContactValidator>();
            services.AddTransient<UpdateDentistValidator>();
            services.AddTransient<UpdateJawValidator>();
            services.AddTransient<UpdateJawSideValidator>();
            services.AddTransient<UpdateServiceTypeValidator>();
            services.AddTransient<UpdateEKartonValidator>();
            services.AddTransient<UpdateTeethValidator>();
            
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMYVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
