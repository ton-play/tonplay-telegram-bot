using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {
    
    private async Task HandleStart(ITelegramBotClient botClient, Message message, bool withHello = false) {
        var chatId = message.Chat.Id;
        var username = message.From.Username;

        ReplyKeyboardMarkup replyKeyboardMarkup = GetMainMenuBtns();

        string msg = $"This is your game!";
        msg = withHello ? $"Hi, @{username}!\n" + msg : msg;

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: msg,
                replyMarkup: replyKeyboardMarkup);
    }
}