# SharpBot (Update In Progress....)
Just Another One Telegram Bot.

See dev branch

## Demo

```C#
static void Main()
{
    Demo();
    while (Console.ReadLine != "stop") { }
}

static async void Demo()
{
    var bot = new NyaBot("ApiToken");
    var me = await bot.GetMeAsync();
    Console.WriteLine($"FirstName: {me.FirstName}");
}
```
