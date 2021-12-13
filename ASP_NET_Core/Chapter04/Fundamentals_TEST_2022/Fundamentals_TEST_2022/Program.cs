using Fundamentals_TEST_2022.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

Dictionary<string, string> dictEmployees = new Dictionary<string, string>
        {
                {"Asia:employees:1", "Mary"},
                {"Asia:employees:2", "John"},
                {"Asia:employees:3", "Kevin"},
                {"Asia:employees:4", "David"},
                {"Asia:employees:5", "Rose"}
        };

//Set host configuration

builder.Host.ConfigureHostConfiguration(configHost =>
{
    //設定基底路徑
    configHost.SetBasePath(Directory.GetCurrentDirectory());

    //configHost有Properties和Sources兩個屬性,前者是Key(FileProvide)及Value(PhysicalFileProvide),後者是Providers提供者資訊
    //如想看見SetBasePath()設定後路徑,可用下面程式抓取
    string contentRoot = ((Microsoft.Extensions.FileProviders.PhysicalFileProvider)configHost.Properties.Values.FirstOrDefault()).Root;

    configHost.AddJsonFile("hostsettings.json", optional: true);
    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
    configHost.AddCommandLine(args);

});

builder.Host.ConfigureAppConfiguration((hostingContext, configApp) =>
{
    //configApp.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), true, true);

    //設定組能檔完整路徑
    string path = Path.Combine(Directory.GetCurrentDirectory(), "ConfigFiles");
    configApp.AddJsonFile(Path.Combine(path, "FutureCorp.json"), optional: true, reloadOnChange: true);  //載入自訂JSON組態檔
    configApp.AddIniFile(Path.Combine(path, "Mobile.ini"), true, true);      //載入自訂INI組態檔
    configApp.AddXmlFile(Path.Combine(path, "Computer.xml"), true, true);    //載入自訂XML組態檔
    configApp.AddJsonFile(Path.Combine(path, "Device.json"), true, true);   //載入自訂JSON組態檔

    path = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
    configApp.AddJsonFile(Path.Combine(path, "Food.json"), true, true);
    configApp.AddInMemoryCollection(dictEmployees);
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
