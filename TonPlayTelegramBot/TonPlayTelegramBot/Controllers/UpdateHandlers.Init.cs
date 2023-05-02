using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {

    private string _botToken;
    private string _gameShortName;

    private string _tonPlayURL;
    private string _XAuthTonplay;
    private string _gameKey;
    private string _botKey;

    private string _gameAddress;

    TelegramBotClient _botClient;
    private string _botName;

    public UpdateHandlers() { }

    //init bot client
    public async Task StartAsync(CancellationToken cancellationToken) {
        InitVariables();

        _botClient = new TelegramBotClient(_botToken);
        var receiverOptions = new ReceiverOptions {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: PollingErrorHandler,
            receiverOptions: receiverOptions,
            cancellationToken: cancellationToken
        );

        var me = await _botClient.GetMeAsync();
        _botName = $"@{me.Username}";
        Console.WriteLine($"Start listening for @{me.Username} id:@{me.Id}");
    }

    //on stop bot client
    public Task StopAsync(CancellationToken cancellationToken) {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.CompletedTask;
    }

    private void InitVariables()
    {
        string workingDirectory = Environment.CurrentDirectory;

        string projectDirectory = Directory.GetParent(workingDirectory).FullName;
        DotNetEnv.Env.LoadMulti(new[] { $"{projectDirectory}/{ENV_PATH}", ENV_PATH });

        //value from telegram BotFather
        _botToken = DotNetEnv.Env.GetString("BOT_TOKEN");
        Console.WriteLine($"_botToken:{_botToken}");
        _gameShortName = DotNetEnv.Env.GetString("GAME_SHORT_NAME");
        //value from TON Play
        _tonPlayURL = DotNetEnv.Env.GetString("TON_PLAY_URL");
        _XAuthTonplay = DotNetEnv.Env.GetString("X_AUTH_TONPLAY");
        _gameKey = DotNetEnv.Env.GetString("GAME_KEY");
        _botKey = DotNetEnv.Env.GetString("BOT_KEY");
        //your game
        _gameAddress = DotNetEnv.Env.GetString("GAME_ADDRESS");
    }
}