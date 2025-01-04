using SorveSoftApi.Data;
using SorveSoftApi.Utils;

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
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
});
builder.Services.AddDbContext<SorveSoftDbContext>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
