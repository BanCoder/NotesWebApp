using DataAccess;
using BusinessLogic; 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.WithOrigins("http://localhost:3000");
		policy.AllowAnyHeader();
		policy.AllowAnyMethod(); 
	});
}); 

var app = builder.Build();
app.UseCors(); 
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
