using Probabilidade.Calculo.Binomial.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel();
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.WebHost.CaptureStartupErrors(true);
builder.WebHost.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculoBinomialService, CalculoBinomialService>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseDeveloperExceptionPage();
app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hub2b.magazineluiza.auth.api v1"));
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Probabilidade.Calculo.Binomial v1"));
}*/

app.Run();
