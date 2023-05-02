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

    private ReplyKeyboardMarkup GetMainMenuBtns() {

        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { BTN_GAME, BTN_WEB_APP}
            ,
        }) {
            ResizeKeyboard = true
        };

        return replyKeyboardMarkup;
    }
}