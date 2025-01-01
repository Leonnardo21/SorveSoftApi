using SorveSoftApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<SorveSoftDbContext>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
