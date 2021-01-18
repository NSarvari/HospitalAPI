namespace Hospital
{
    using DataAccess;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Http;
    using DataAccess.IRepositories;
    using DataAccess.Repositories;
    using AutoMapper;
    using Hospital.Services.Interfaces;
    using Hospital.Services;
    using System;
    using Hospital.Mapping;
    using DataStructure;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;

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


            //dependency injection
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(MappingProfile));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IPatientDoctorRepository, PatientDoctorRepository>();
            services.AddTransient<IPatientMedicineRepository, PatientMedicineRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IMedicineService, MedicineService>();
            services.AddTransient<IMedicalRecordService, MedicalRecordService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IPatientDoctorService, PatientDoctorService>();
            services.AddTransient<IPatientMedicineService, PatientMedicineService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DbInitializer.Seed(serviceProvider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
