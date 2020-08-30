# ayb-api

The official Javascript AYB api wrapper. Looking for another language? [Java](https://github.com/AdvertiseYourBot/ayb-api.java), [Python](https://github.com/AdvertiseYourBot/ayb-api.py), [JavaScript](https://github.com/AdvertiseYourBot/ayb-api). If you would like a specific language added feel free to tell us in our [Discord server](https://discord.gg/bDsTZ29)

## Classes

### Client

###### Methods

- GetStats(Action<Exception, Stats> callback)
  - Fetch overall site statistics for ayblisting.com

- GetBot(string id, Action<Exception, Bot> callback)
  - Fetch a bot from the site using its id

- GetCategory(string id, Action<Exception, Category> callback)
  - Fetch a category by id

---

### Bot

###### Methods

- GetCategory(Action<Exception, Category> callback)
  - Fetch the category of that bot

###### Properties

- **String: OwnerId** `The user property for the owner of this bot (if a Discord.js v12+ client was passed when initializing the Manager). If no client was passed or no user was found then it will default to the owner's id`

- **String: Id** `The id of this bot`

- **String: Username** `This bot's username`

- **String: AvatarUrl** `The direct url for this bot's avatar`

- **Number: Score** `The amount of votes this bot has on ayblisting.com`

- **String: Category** `The id of this bot's category`

- **Boolean: Approved** `Whether this bot is approved or not`

- **Boolean: Certified** `This bot's certification status`

- **Boolean: Premium** `This bot's premium status`

- **String: Prefix** `The prefix of this bot`

- **String: Permissions** `The permissions integer for this bot`

- **String: Library** `The library used to create this bot`

- **String: WebsiteUrl** `The url to this bot's website (empty if none)`

- **String: GitHubUrl** `The url to this bot's GitHub repository (empty if none)`

- **String: SupportServerInvite** `The invite url for this bot's support server`

---

### Category

###### Properties

- **String: Id** `The id of this category`

- **String: Name** `The name of this category`

- **String: Slug** `The slug of this category`

---

### Stats

###### Properties

- **int: Bots** `The total number of bots on the site`

- **int: PendingApprovals** `(BETA) The number of bots pending approval from bot verifiers`

- **int: UnreadReports** `The number of unread reports on the site`