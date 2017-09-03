# SharpBot (Update In Progress....)
Just Another One Telegram Bot.

See dev branch

## Demo

```C#
static void Main()
{
    var api = new ApiClient("YOURBOTKEY");
    var bot = new BotImpl(api, new UpdateProvider(api));
    Task.WaitAll(bot.Start());
}
```
