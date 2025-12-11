using DataAccess; 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccess(); 
var app = builder.Build();
app.Run();
