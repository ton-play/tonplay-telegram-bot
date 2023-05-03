using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using efzgamebot.Models;
using System.Text.Json;

namespace efzgamebot.Controllers;

public partial class UpdateHandlers : Microsoft.Extensions.Hosting.IHostedService {

    //send game button
    private async Task HandleGame(ITelegramBotClient botClient, Message message) {
        long chatId = message.Chat.Id;
        await botClient.SendGameAsync(chatId, _gameShortName);
    }

    //respond when the user clicked on the game button
    private async Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery) {
        string username = callbackQuery.From.Username;
        long userId = callbackQuery.From.Id;

        await _APITonPlayTelegramLogin.PostTelegramUserLogin(
            callbackQuery.From.Id,
            callbackQuery.From.Username,
            callbackQuery.From.FirstName,
            callbackQuery.From.LastName,
            _botKey,
            _botToken,
            headerXAuthTonplay: _XAuthTonplay).ContinueWith(async (result) => {
                string tokenString = "";
                TokenJSON token = JsonSerializer.Deserialize<TokenJSON>(result.Result);

                if (result.IsFaulted) {
                    Console.WriteLine($"Error receive token {callbackQuery.From.Username}: {result.Exception.Message}");
                    return;
                }

                tokenString = $"token={token.token}";
                string url = $"{_gameAddress}?{tokenString}";
                Console.WriteLine("url: " + url);
                await botClient.AnswerCallbackQueryAsync(
                    callbackQueryId: callbackQuery.Id,
                    url: url);

            });
    }

    #region inline
    //simple example for game
    //request after click inline game btn
    private async Task GameBotOnInlineQueryReceived(ITelegramBotClient botClient, InlineQuery inlineQuery) {
        InlineQueryResultGame inlineQueryResultGame = new InlineQueryResultGame(
             id: "1",
             gameShortName: _gameShortName
        );

        InlineQueryResult[] results = {
            inlineQueryResultGame
        };

        await botClient.AnswerInlineQueryAsync(inlineQueryId: inlineQuery.Id,
                                               results: results,
                                               isPersonal: true,
                                               cacheTime: 0);

    }

    #endregion
}