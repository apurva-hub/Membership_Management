
using Microsoft.EntityFrameworkCore;
using mm_lib;
using mm_lib.Interface;
using mm_lib.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IRegister, RegisterServices>();
builder.Services.AddScoped<IMembers, MembersServices>();
builder.Services.AddScoped<IMembership, MembershipServices>();
builder.Services.AddDbContext<members_managementContext>(option => option.UseSqlServer("Data Source=DESKTOP-LK2QAA8\\SQLEXPRESS;Initial Catalog=members_management;Integrated Security=True"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Map("/map", appMap => {
    appMap.Run(async context =>
    {
        await context.Response.WriteAsync("Map middleware is executed");

    });
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("First Middleware\n");
    await next();
    await context.Response.WriteAsync("First Middleware second response after next function\n");
});


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Second Middleware\n");
    await next();
    await context.Response.WriteAsync("Second Middleware second response after next function\n");
});


app.Run(async (context) =>
{
    await context.Response.WriteAsync("Run is executed\n");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
