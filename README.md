# SharpBot
Just Another One Telegram Bot.

See dev branch

## Demo

```C#
static void Main(string[] args)
{
    var bot = Kernel.Get<IBot>();
    Task.WaitAll(bot.Start());
}

```