using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Slobodianiuk.University.Example.Core;
using Slobodianuik.University.Example.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterDatabaseDependencies(builder.Configuration);
//builder.Services.RegisterIdentityDependencies();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FlowersShopDbContext>(options =>

    options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("ZhukUniversityTachkaWebContext") ?? throw new InvalidOperationException("Connection string 'ZhukUniversityTachkaWebContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FlowersShopDbContext>().AddDefaultTokenProviders();


builder.Services.AddAuthentication()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    googleOptions.Events = new OAuthEvents()
    {
        OnRemoteFailure = (context) =>
                {
                    context.Response.Redirect(context?.Properties?.GetString("returnUrl"));
                    context.HandleResponse();
                    return Task.CompletedTask;
                }
    };
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
});

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.Run();