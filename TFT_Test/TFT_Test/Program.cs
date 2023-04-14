using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DirectorListContext>(opt =>
{
	opt.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
/*
 * THIS WHOLE BLOCK OF COMMENTED TEXT WAS MY PATH FROM WHAT THE LINK I WAS FOLLOWING SUGGESTED
 * TO REALIZING THE SIMPLEST THINGH I HAD TO DO, AFTER FAILING TO DEBUG THROUGH GOOGLING THE PROBLEM 
 * I FINALLY DECIDED TO DEBUG IT THROUGH READING CODE LINE BY LINE "ADD SERVICES TO THE CONTAINER" ... WELL BETTER LATE THEN NEVER I GUESS
 * 
public class Program
{
	public static void Main(string[] args)
		=> CreateHostBuilder(args).Build().Run();

	// EF Core uses this method at design time to access the DbContext
	public static IHostBuilder CreateHostBuilder(string[] args)
		=> Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(
				webBuilder => webBuilder.UseStartup<Startup>());
}
*/

/*
public class Startup
{
	//Accessing the Database NOTE: the instrunction link is using public void getting error "the modifier 'public' is not valid for this item"
	//public//
	public void ConfigureServices(IServiceCollection services)
		=> services.AddDbContext<ActorListContext>(opt =>
		{
			opt.UseNpgsql(@"Server=localhost;Port=5432;Database=TFT_TestBase;
                User ID=postgres;Password=pMajaolinkas88");
		});
	/*{
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
	}*/
//}
