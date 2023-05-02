# TonPlayTelegramBot

This is a simple example of a telegram bot for run your game.

In this example, you can run the game as a telegram Web App and exactly as a game in the web view.

## Quick start

### Get all the necessary data to run the bot

1. Register and log in to the admin panel on the platform [Console TON Play](https://console.tonplay.io/).

2. In the tonplay admin panel, create a game and get a Game API Key.

3. Go to Telegram [BotFather](https://t.me/botfather) to create your new bot. As a result, you should get a bot token.
You need to call.

`/newbot`

4. Next inside [BotFather](https://t.me/botfather) you need to enable Inline. Choose your bot and write any phrase (you can always change it). 

`/setinline`

5. Add a game to telegram in [BotFather](https://t.me/botfather) (this step is needed if you choose the option to run the game as a Telegram Game, not just a Web App. For this example, we recommend doing this step.

`/newgame`

You will need a 640x360 pixels image, you can take it from the repository as an example (it can be replaced).
After this you will have Game short name

6. Now let's go back to [Console TON Play](https://console.tonplay.io/) and get the bot_key.

7. Upload your game on server and place it under a domain with https. If you can't have https, you can switch [telegram to test mode](https://core.telegram.org/bots/webapps#using-bots-in-the-test-environment) 
or use for example our Unity SDK demo link: https://tonplay.demosdk.fantasylabsgames.dev .

### Let's start the bot
We have all the necessary information. 
1. Copy all the necessary data from [BotFather](https://t.me/botfather) and [Console TON Play](https://console.tonplay.io/) to the .env file.

2. Launch your bot.

## Project structure

`Program.cs` — launches a container with a bot.  

`UpdateHandlers.Init.cs` — initializes the necessary variables from the .env file and launches the bot via the Telegram library.   
`UpdateHandlers.Update.cs` — listens to events from Telegram.  

`UpdateHandlers.MessageReceived.cs` — triggers different actions depending on the message.  

`UpdateHandlers.HandleGame.cs` — launches the game in web view.  
`UpdateHandlers.HandleWebApp.cs` — launches the game in web app.  

`APITonPlayTelegramLogin.cs` — gets the user's token. It also implements hash calculation. Learn more TON Play API https://docs.tonplay.io/digital-assets-api/auth-api. 

## Add Docker

1. Download docker https://www.docker.com/get-started/ 
2. In Visual Studio Click on your project Add -> Docker Support 

3. Run Docker on you PC or Mar 
4. Run your project in Visual Studio

## How can you start your game in Telegram 

In Telegram games can be launched in two ways.   
_The version of the built-in API in Web API and Web View may differ, which may cause some functions to not work.
More about telegram game_

### Telegram Game

One of them is in the web view and it will be recognized by Telegram as a game. 

https://core.telegram.org/bots/games    
https://core.telegram.org/bots/api#games

### Telegram Web App

Another option is to run the game in the web app, and in this case for telegram it's just opening the site.

https://core.telegram.org/bots/webapps
