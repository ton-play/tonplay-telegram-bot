# TonPlayTelegramBot

This is a simple example of a Telegram bot to run your game.

In this example, you can run the game as a Telegram Web App and exactly as a game in a web view.

## Quick start

### Get all the necessary data to run the bot

1. Register and log in to the admin panel on the platform [Console TON Play](https://console.tonplay.io/).

2. Create a game in [Console TON Play](https://console.tonplay.io/) and get a Game API Key.

<img width="901" alt="Create new Game" src="https://user-images.githubusercontent.com/111277652/235601861-fcd0f1e9-896e-4a07-afa0-97d0851c63cc.png">

3. Go to Telegram [BotFather](https://t.me/botfather) to create your new bot. As a result, you will get a bot token.
You need to choose a username for your bot.

`/newbot`

<img width="792" alt="create your new bot" src="https://user-images.githubusercontent.com/111277652/235601985-258ada6c-fedb-4a44-9dc4-9fe1c20ec4d1.png">

4. Next, inside [BotFather](https://t.me/botfather), you need to enable Inline mode. Choose your bot and write any phrase (you can always change it). 

`/setinline`

<img width="814" alt="Add inline bot" src="https://user-images.githubusercontent.com/111277652/235602012-e63c7cf5-e689-4ac5-9c1a-4a6d5e8e5e87.png">

5. Add a game to Telegram in [BotFather](https://t.me/botfather) (this step is needed if you choose the option to run the game as a Telegram Game, not just a Web App. For this example, we recommend doing this step.

`/newgame`

<img width="1062" alt="Short name" src="https://user-images.githubusercontent.com/111277652/235602041-5a657c7f-9f35-44dd-ba40-52c42ae969cb.png">

You will need an image with a resolution of 640x360 pixels. You can use an [example image](https://github.com/ton-play/tonplay-telegram-bot/blob/main/GameImageExample640x360.png) provided in the repository, but you can change the image at any time in Telegram.
After this, you will have a game short name.

6. Now let's go back to [Console TON Play](https://console.tonplay.io/) and get the bot_key.

<img width="770" alt="CreateBotKey" src="https://user-images.githubusercontent.com/111277652/235602379-479f7e51-7fcb-41df-b2a5-b730beb9203f.png">

7. Upload your game to a server and place it under a domain with `https`. If you don't have https, you can switch [Telegram to test mode](https://core.telegram.org/bots/webapps#using-bots-in-the-test-environment) 
or use, for example, our Unity SDK demo link: https://tonplay.demosdk.fantasylabsgames.dev .

### Let's start the bot
We have all the necessary information. 
1. Copy all the necessary data from [BotFather](https://t.me/botfather) and [Console TON Play](https://console.tonplay.io/) to the .env file.
> **Note** GAME_SHORT_NAME it is not game name. Look at step 5 in [Get all the necessary data to run the bot](https://github.com/ton-play/tonplay-telegram-bot#get-all-the-necessary-data-to-run-the-bot)

<img width="1014" alt="Copy info in telegram bot" src="https://user-images.githubusercontent.com/111277652/235602436-1be9eb72-21d8-457a-8e1c-154b7b6f02c0.png">

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

<img width="566" alt="Add docker support" src="https://user-images.githubusercontent.com/111277652/235603319-ee7d41f1-7035-432f-8038-e26f732faa45.png">

3. Run Docker on you PC or Mar 
4. Run your project in Visual Studio

## How can you start your game in Telegram 

In Telegram games can be launched in two ways.   
> **Note** The version of the built-in API in Web API and Web View may differ, which may cause some functions to not work.
More about telegram game

### Telegram Game

One of them is in the web view and it will be recognized by Telegram as a game. 

<img width="918" alt="web view example" src="https://user-images.githubusercontent.com/111277652/235602538-525bf13b-2b2e-4305-a242-8d270513762d.png">

https://core.telegram.org/bots/games    
https://core.telegram.org/bots/api#games

### Telegram Web App

Another option is to run the game in the web app, and in this case for telegram it's just opening the site.

<img width="795" alt="web app example" src="https://user-images.githubusercontent.com/111277652/235602523-8aa93c16-5ef7-4ab7-92a0-1e8cb1571b96.png">

https://core.telegram.org/bots/webapps
