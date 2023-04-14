using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//Accessing the Database NOTE: the instrunction link is using public void getting error "the modifier 'public' is not valid for this item"
//public//
 void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ActorListContext>(
        opts =>
        {
            opts.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
        });
	services.AddDbContext<DirectorListContext>(
		opts =>
		{
			opts.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
		});
	services.AddDbContext<FilmListContext>(
		opts =>
		{
			opts.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
		});
	services.AddDbContext<GenreListContext>(
		opts =>
		{
			opts.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
		});
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
