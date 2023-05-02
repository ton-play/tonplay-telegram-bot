using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using efzgamebot.Controllers.API;
using System.Text.RegularExpressions;
using efzgamebot.Models;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {
    private async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message) {
        if (message.Text is not { } messageText)
            return;

        switch (messageText) {
            case MSG_START:
                await HandleStart(botClient, message, true);
                return;
            case BTN_GAME:
                await HandleGame(botClient, message);
                return;
            case BTN_WEB_APP:
                await HandleWebApp(botClient, message);
                return;
        }
            await HandleOtherMsgs(botClient, message);
    }
  
}