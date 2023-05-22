var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUsersDataService, EFCUserDataService>();
builder.Services.AddSingleton<IProjectDataService, EFCProjectDataService>();
builder.Services.AddSingleton<IRoofTypeDataService, EFCRoofTypeDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
