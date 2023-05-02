using System;
namespace efzgamebot.Models {
    [Serializable]
    public class UserJWTJSON {

        public string sub { get; set; }
        public string wallet { get; set; }

        public UserJWTJSON() {
        }
    }
}

