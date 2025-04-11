using Chat.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueDevClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:8080") // origem exata do seu front-end
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // isso é essencial
    });
});

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowVueDevClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<HubProvider>("/Hub");

app.Run();
