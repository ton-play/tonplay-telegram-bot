using System;
using System.Security.Cryptography;
using System.Text;
using efzgamebot.Controllers.API;
using Telegram.Bot.Types;

namespace efzgamebot.Controllers.API {
    public class APITonPlayTelegramLogin {

        private string _postTelegramUserLoginUrl = "/x/auth/v2/login/tg";
        private string _tonPlayServer;

        public APITonPlayTelegramLogin() {
            _tonPlayServer = DotNetEnv.Env.GetString("TON_PLAY_URL");
        }

        public async Task<string> PostTelegramUserLogin(long id, string username, string firstName, string lastName, string botKey, string botToken, string headerXAuthTonplay) {

            List<string> paramsList = new List<string>
            {
                $"first_name={firstName}",
                $"id={id}",
                $"last_name={lastName}",
                $"username={username}"
            };

            paramsList.Sort((a, b) => a.CompareTo(b));

            string hash = GetParamsHash(paramsList, botToken);

            string requestBody = $@"
            {{
                ""id"": ""{id}"",
                ""username"": ""{username}"",
                ""first_name"": ""{firstName}"",
                ""last_name"": ""{lastName}"",
                ""hash"": ""{hash}"",
                ""bot_key"":""{botKey}""
            }}
            ";

            Console.WriteLine($"_tonPlayServer: {_tonPlayServer}");
            Console.WriteLine($"_postTelegramUserLoginUrl: {_postTelegramUserLoginUrl}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"username: {username}");
            Console.WriteLine($"first_name: {firstName}");
            Console.WriteLine($"last_name: {lastName}");
            Console.WriteLine($"hash: {hash}");
            Console.WriteLine($"bot_key: {botKey}");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_tonPlayServer);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _postTelegramUserLoginUrl);
            request.Content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");//CONTENT-TYPE header
            request.Headers.Add("X-Auth-Tonplay", headerXAuthTonplay);

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public static string GetParamsHash(List<string> paramsList, string botToken) {
            string hash;

            byte[] secret_key_in_bytes;

            string data_check_string = string.Join("\n", paramsList);

            byte[] data_check_in_bytes = Encoding.UTF8.GetBytes(data_check_string);

            using (SHA256 mySHA256 = SHA256.Create()) {
                byte[] bot_token_bytes = Encoding.ASCII.GetBytes(botToken);
                secret_key_in_bytes = mySHA256.ComputeHash(bot_token_bytes);

            }

            using (HMACSHA256 hmac = new HMACSHA256(secret_key_in_bytes)) {
                byte[] HMACSHA256_data_check = hmac.ComputeHash(data_check_in_bytes);

                hash = Convert.ToHexString(HMACSHA256_data_check);
            }

            return hash.ToLower();
        }
    }
}

