using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FourBlog_Lucas.Areas.Identity.Data;
using FourBlog_Lucas.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FourBlog_LucasContextConnection") ?? throw new InvalidOperationException("Connection string 'FourBlog_LucasContextConnection' not found.");

builder.Services.AddDbContext<FourBlog_LucasContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FourBlog_LucasContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Isso aqui serve para configurar a injeção de dependência nos Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages(); //Adicionado

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
