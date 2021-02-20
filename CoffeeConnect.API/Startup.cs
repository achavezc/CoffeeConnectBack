using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Repository;
using CoffeeConnect.Service;
using Core.Common.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoffeeConnect.API
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

            var jwtOptions = new JwtOptions();
            var section = Configuration.GetSection("jwt");
            section.Bind(jwtOptions);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination").Build());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOptions.Issuer,
                            //ValidAudience = "readers",// Configuration["Jwt.Issuer"],
                            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                        };
                    });

            services.AddOptions();

            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));
            //services.Configure<MailServerSettings>(Configuration.GetSection("MailServerSettings"));
            //services.AddTransient<IVBRepository, VBRepository>();

            services.AddTransient<Core.Common.Logger.ILog, Core.Common.Logger.Log>();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IMaestroService, MaestroService>();
            services.AddTransient<IMaestroRepository, MaestroRepository>();
            

            services.AddTransient<IGuiaRecepcionMateriaPrimaService, GuiaRecepcionMateriaPrimaService>();
            services.AddTransient<IGuiaRecepcionMateriaPrimaRepository, GuiaRecepcionMateriaPrimaRepository>();

            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            
            services.AddTransient<ILoteService, LoteService>();
            services.AddTransient<ILoteRepository, LoteRepository>();

            services.AddTransient<INotaSalidaAlmacenRepository, NotaSalidaAlmacenRepository>();
            services.AddTransient<ICorrelativoRepository, CorrelativoRepository>();

            services.AddTransient<INotaCompraService, NotaCompraService>();
            services.AddTransient<INotaCompraRepository, NotaCompraRepository>();

            services.AddTransient<INotaIngresoAlmacenService, NotaIngresoAlmacenService>();
            services.AddTransient<INotaIngresoAlmacenRepository, NotaIngresoAlmacenRepository>();

            services.AddTransient<INotaSalidaService, NotaSalidaService>();
            services.AddTransient<INotaSalidaRepository, NotaSalidaRepository>();

            services.AddMvc(setupAction => { setupAction.EnableEndpointRouting = false; })
                    .AddJsonOptions(jsonOptions => { jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null; })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
