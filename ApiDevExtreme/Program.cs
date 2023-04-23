using ApiDevExtreme.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "vueFrontend";


builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=DashboardDb;")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:8080", "https://localhost:8080", "http://localhost:8080/*", "https://localhost:8080/*",
            "http://172.20.27.251:8080", "https://172.20.27.251:8080", "http://172.20.27.251:8080/*", "https://172.20.27.251:8080/*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles();
app.MapRazorPages();
app.MapControllers();

app.Run();
