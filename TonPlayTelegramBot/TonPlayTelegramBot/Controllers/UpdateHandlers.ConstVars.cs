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

    public enum State {
        Default,
        WaitingWallet
    }

    private static APITonPlayTelegramLogin _APITonPlayTelegramLogin = new APITonPlayTelegramLogin();

    private const string BTN_GAME = "🎮 Game";
    private const string BTN_WEB_APP = "Web App";
    private const string MSG_START = "/start";

    private const string TEST_ENV_PATH = "test.env";
    private const string ENV_PATH = ".env";
}