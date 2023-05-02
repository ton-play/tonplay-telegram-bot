using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {
    
    private async Task HandleOtherMsgs(ITelegramBotClient botClient, Message message, bool withHello = false) {
        var chatId = message.Chat.Id;

        ReplyKeyboardMarkup replyKeyboardMarkup = GetMainMenuBtns();

        string msg = $"🚀 Play right inside the bot!";

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: msg,
                replyMarkup: replyKeyboardMarkup);
    }

}