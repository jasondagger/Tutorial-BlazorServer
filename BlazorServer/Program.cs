using BlazorServer;

BuildApp(
	WebApplication.CreateBuilder(
		args
	)
);

static void BuildApp(
	WebApplicationBuilder builder
)
{
	// Add services to the container.
	ConfigureServices(
		builder.Services
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
    IServiceCollection services
)
{
    services.AddRazorPages();
	services.AddServerSideBlazor();
    services.AddSingleton<IContactService, ContactService>();
}