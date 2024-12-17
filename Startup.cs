using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Text;
using Assessment.Models;
using Assessment.ViewModels;
using ViewModels;
using Assessment.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Hangfire;
using Functions;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Assessment
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{



			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			configuration = builder.Build();

			Configuration = configuration;

		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddHttpClient();

			//Show UI or API......

			var viewApp = Configuration["Security:ViewAPP"];

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "My API",
					Version = "v1",
					Description = "API for my application"
				});
			});

			services.AddEndpointsApiExplorer();

			services.AddControllers();

			services.AddMemoryCache();

			services.AddDistributedMemoryCache();

			services.AddDbContext<AppDBContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));

			services.AddHangfireServer();

			services.Configure<SecurityOptions>(Configuration.GetSection("Security"));


			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpContextAccessor();

			services.AddSessionLocalization();

			services.AddSession();



		}

		private SigningCredentials GetJwtSigningCredentials()
		{
			var secSettings = Configuration.GetSection("Security");

			var secretKey = Configuration["Security:SecretKey"];



			SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

			return new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDBContext dbcontext, IOptions<SecurityOptions> securityOptions)
		{
			dbcontext.Database.Migrate();



     		app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();


			app.UseSession();


		

				// Enable middleware to serve generated Swagger as a JSON endpoint.
				app.UseSwagger();
				// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
				// specifying the Swagger JSON endpoint.
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				});



				InitializingDatabase.Initialize(dbcontext, securityOptions.Value);
			


		}

	}

}
