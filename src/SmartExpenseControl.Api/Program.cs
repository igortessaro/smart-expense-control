using SmartExpenseControl.Infrastructure.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
_ = builder.Services.AddControllers();
_ = builder.Services.AddServices();
_ = builder.Services.AddCqrs();
_ = builder.Services.AddRepositories(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen();
_ = builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
    _ = app.UseDeveloperExceptionPage();
}

_ = app.UseHttpsRedirection();
_ = app.UseRouting();
_ = app.MapControllers();

await app.RunAsync();
