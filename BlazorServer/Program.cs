using BlazorServer;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

BuildApp(
	WebApplication.CreateBuilder(
		args
	)
);

static void BuildApp(
	WebApplicationBuilder builder
)
{
	var services = builder.Services;
    var configuration = new ConfigurationBuilder()
		.AddJsonFile(
			"appsettings.json"
		)
		.Build();

	// Add services to the container.
	ConfigureServices(
		services,
		configuration
	);

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler(
			"/Error"
		);
	}

	app.UseStaticFiles();
	app.UseRouting();

	app.MapBlazorHub();
	app.MapFallbackToPage(
		"/_Host"
	);

	app.Run();
}

static void ConfigureServices(
    IServiceCollection services,
	IConfiguration configuration
)
{
	services.AddDbContext<MemberDbContext>(
		options => options.UseSqlServer(
			configuration.GetConnectionString(
				"ConnectionStrings:ConnectionString"	
			)
		)
	);
    services.AddRazorPages();
	services.AddServerSideBlazor();
    services.AddSingleton<IContactService, ContactService>();
}