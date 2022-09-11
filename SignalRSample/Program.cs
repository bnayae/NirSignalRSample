using SignalRSample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<MyHub>("/my-hub");

app.MapGet("/", () => "Hello World!");

app.Run();
