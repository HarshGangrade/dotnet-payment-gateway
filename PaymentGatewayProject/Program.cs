using PaymentGatewayProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // ✅ no OpenApiInfo
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();   // looks for index.html automatically
app.UseStaticFiles();    // enables wwwroot
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
