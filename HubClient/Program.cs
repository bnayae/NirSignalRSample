using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7235/my-hub")
                .Build();


connection.Closed += async (error) =>
{
    await Task.Delay(1000);
    await connection.StartAsync();
};

connection.On<string>("CountNotification", (data) =>
{
    Console.WriteLine(data);
});

await connection.StartAsync();

Console.WriteLine("Write a number");

while (true)
{
    string? text = Console.ReadLine();
    if (int.TryParse(text, out var val))
    {
        await connection.InvokeAsync("Send", val );
    }
    else
    {
        Console.WriteLine("Not a number");
    }
}