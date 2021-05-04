using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using digitalEnsi.Factories;
using digitalEnsi.Models;
using digitalEnsi.Models.Configuration;
using digitalEnsi.Services;
using AutoMapper;
using digitalEnsi.Profiles;

namespace digitalEnsi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            JwtSettings settings;
            settings =GetJwtSettings();
            


            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSingleton<JwtSettings>(settings);
            services.AddSingleton<JwtFactory>();
            services.AddScoped<IGroupeService, GroupeService>();
            services.AddScoped<IInscriptionService, InscriptionService>();
            services.AddScoped<IEtudiantService, EtudiantService>();
            services.AddScoped<ISeanceService, SeanceService>();
            services.AddScoped<IEnseignantService, EnseignantService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme="JwtBearer";
                option.DefaultChallengeScheme="JwtBearer";
            })
            .AddJwtBearer("JwtBearer",jwtBearerOptions=>
            {
                jwtBearerOptions.TokenValidationParameters=
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey=true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(settings.Key)),
                            ValidateIssuer= true,
                            ValidIssuer=settings.Issuer,

                            ValidateAudience=true,
                            ValidAudience=settings.Audience,

                            ValidateLifetime=true,
                            ClockSkew=TimeSpan.FromMinutes(settings.MinutesToExpiration)

                        
                        
                    };
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();;
                                });
            });

            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            services.AddControllers();
           

            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));
            services.AddIdentity<ApplicationUser,IdentityRole>(options=>{
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddIdentityCore<Etudiant>(options=>{
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddIdentityCore<Enseignant>(options=>{
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddIdentityCore<Administrateur>(options=>{
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "digitalEnsi", Version = "v1" });
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    p => p.RequireAuthenticatedUser().RequireRole("Admin"));

                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "digitalEnsi v1"));
            }

            //app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }








        public JwtSettings GetJwtSettings(){
            JwtSettings settings = new JwtSettings();
            settings.Key=Configuration["JwtSettings:key"];
            settings.Audience=Configuration["JwtSettings:audience"];
            settings.Issuer=Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration=Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"]);
            return settings; 
        }



    }
}
