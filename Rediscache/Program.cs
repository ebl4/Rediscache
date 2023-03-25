using StackExchange.Redis;

string connectionString = "CONNECTION_STRING";

using (var cache = ConnectionMultiplexer.Connect(connectionString))
{
    IDatabase db = cache.GetDatabase();

    var result = await db.ExecuteAsync("ping");
    Console.WriteLine($"PING = {result.Type} : {result}");

    bool setValue = await db.StringSetAsync("test:key", "100");
    Console.WriteLine($"SET: {setValue}");

    string getValue = await db.StringGetAsync("test:key");
    Console.WriteLine($"GET: {getValue}");
    Console.ReadKey();
}
