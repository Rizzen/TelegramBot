# SharpBot (Update In Progress....)
Just Another One Telegram Bot.

See dev branch

## Demo

```C#
static void Main()
    {
        var api = new ApiClient("437367398:AAEE6VZNK7LOEBcyJiKpR2_o6LMGGUSTyV8");
        var bot = new BotImpl(api, new UpdateProvider(api));
        Task.WaitAll(bot.Start());
    }
```
