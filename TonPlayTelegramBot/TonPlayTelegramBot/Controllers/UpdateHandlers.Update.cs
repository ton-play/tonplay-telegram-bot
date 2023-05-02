using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) {

        Console.WriteLine($"Receive update type: {update.Type}");

        var handler = update.Type switch {
            //This is the processing of any messages in a chat with a bot
            UpdateType.Message => BotOnMessageReceived(botClient, update.Message!),
            //This is what we use to handle when the user clicked on the play button.
            UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),

            //This handles the event when the user has typed @botusername in the input field and should see popup
            //UpdateType.InlineQuery => GameBotOnInlineQueryReceived(botClient, update.InlineQuery!),
            //or you can use WebAppBotOnInlineQueryReceived instead of GameBotOnInlineQueryReceived
            UpdateType.InlineQuery => WebAppBotOnInlineQueryReceived(botClient, update.InlineQuery!),

            //There are other types of data in the telegram, but for example, we will process all of them in the same way
            _ => UnknownUpdateHandlerAsync(botClient, update)
        };

        try {
            await handler;
        }
#pragma warning disable CA1031
        catch (Exception exception)
#pragma warning restore CA1031
        {
            await PollingErrorHandler(botClient, exception, cancellationToken);
        }
    }

    public Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) {
        var ErrorMessage = exception switch {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

    private Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update) {
        Console.WriteLine($"Unknown update type: {update.Type}");
        return Task.CompletedTask;
    }
}