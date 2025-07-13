var builder = WebApplication.CreateBuilder(args);

// ✅ إعداد CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ProductionCorsPolicy", policy =>
    {
        policy.WithOrigins("https://altawbahvoyages.com") // ضع الدومين الصحيح هنا
              .AllowAnyHeader()
              .AllowAnyMethod();
              // .AllowCredentials(); ← فقط إذا كنت تحتاجها
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ CORS
app.UseCors("ProductionCorsPolicy");

// ✅ HSTS و HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();

// ✅ Swagger فقط أثناء التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
