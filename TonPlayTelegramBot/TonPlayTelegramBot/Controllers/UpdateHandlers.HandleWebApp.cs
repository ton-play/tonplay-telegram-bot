using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using efzgamebot.Models;
using System.Text.Json;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {

    //request in main menu after btn Game clicked
    private async Task HandleWebApp(ITelegramBotClient botClient, Message message) {
    string username = message.From.Username;
    long userId = message.From.Id;

    await _APITonPlayTelegramLogin.PostTelegramUserLogin(
        message.From.Id,
        message.From.Username,
        message.From.FirstName,
        message.From.LastName,
        _botKey,
        _botToken,
        headerXAuthTonplay: _XAuthTonplay).ContinueWith(async (result) => {

            string tokenString = "";
            TokenJSON token = JsonSerializer.Deserialize<TokenJSON>(result.Result);

            tokenString = $"token={token.token}";

            if (!result.IsFaulted && token != null && !string.IsNullOrWhiteSpace(token.token)) {
                tokenString = $"token={token.token}";
                Console.WriteLine(tokenString);
            } else if (result.IsFaulted) {
                Console.WriteLine($"Error receive token {message.From.Username}: {result.Exception.Message}");
            }

            WebAppInfo webAppInfo = new WebAppInfo();
            webAppInfo.Url = $"{_gameAddress}/?{tokenString}";

            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] {
                new KeyboardButton[] {
                    KeyboardButton.WithWebApp("Start game", webAppInfo)
                }
            });

            replyKeyboardMarkup.OneTimeKeyboard = true;

            await botClient.SendTextMessageAsync(message.Chat.Id, "Click Start Game please", replyMarkup: replyKeyboardMarkup);
        });
    }

    #region inline
    //simple example for web app
    //request after click inline game btn
    private async Task WebAppBotOnInlineQueryReceived(ITelegramBotClient botClient, InlineQuery inlineQuery) {

        InputMessageContent inputMessageContent = new InputTextMessageContent($"Let's play {_botName}");

        InlineQueryResult inlineQueryResult = new InlineQueryResultArticle(
             id: "1",
             title: "Ton Play game",
             inputMessageContent: inputMessageContent
        );

        InlineQueryResult[] results = {
                inlineQueryResult
            };

        await botClient.AnswerInlineQueryAsync(inlineQuery.Id,
                                               results,
                                               isPersonal: true,
                                               cacheTime: 0);

    }
    #endregion
}