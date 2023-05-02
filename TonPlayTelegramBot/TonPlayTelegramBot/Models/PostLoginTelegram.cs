using System;
namespace efzgamebot.Models {
    [Serializable]
    public class PostLoginTelegram {

        public long id;
        public string username;
        public string first_name;
        public string last_name;
        public string locale;
        public string hash;
        public string bot_key;

        public PostLoginTelegram() {
        }
    }
}

