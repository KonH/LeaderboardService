# LeaderboardService

Leaderboards service is a simple API for receive, store and retrieve user scores for games.

## Overview

Service is based on ASP.NET Core, written on C# and uses MySQL as data storage.

**Features:**

- Flexible user rights system with games separation
- Automatic filter best scores and return its top
- Save scores history
- API to manage users and games

## Example

You can look at example [here](https://konhit.xyz/lbservice/swagger/ui/index.html). Test service contains:

- HTTPS support using nginx
- Test game **testGame** which ready to use
- Test user **testUser** with post and read scores permissions for test game (password: **mGPRudr8**, auth header: **Basic dGVzdFVzZXI6bUdQUnVkcjg=**)


## Installation

Install and setup using Docker is pretty simple, but you can do it manually.

### Docker

Configure and start [MySQL container](https://hub.docker.com/_/mysql/).

Get latest version of LeaderboardService using DockerHub:

```
docker pull konh/lbservice:latest
```

And start it:

```
docker run --name lbservice --net isolated -p 8080:8080 -e LS_MYSQL="server=mysql;userid=root;password=root;database=leaderboards;" konh/lbservice:latest
```

### Manually

Install, configure and start [MySQL](https://www.mysql.com/).

Install [dotnet 1.0.3](https://www.microsoft.com/net/download/core).

Then, install and start service:

```
git clone https://github.com/KonH/LeaderboardService.git
cd LeaderboardService/Service
dotnet restore
dotnet build
dotnet run -MySQL "server=mysql;userid=root;password=root;database=leaderboards;"
```

### MySQL preparation

You don't need to create database and tables manually, but master user setup is required:

```
INSERT INTO leaderboards.User (Name, Password) VALUES ("admin", "admin_password");
INSERT INTO leaderboards.UserRole (User, Game, Permissions) VALUES ("admin", "", 511);
```

After it you get access to all API calls.

### Games and users setup

Every user have permissions, which is game separated (or, if game is not specified, apply to all games). If you need to add new game, add new user with minimal permissions to it.

## Service Settings

You can specify parameters for service launch using command line arguments like -Port or docker env variables like LS_PORT.

- **-Port (LS_PORT)** - service port to listen

- **-Env (LS_ENV)** - service environment

- **-MySQL (LS_MYSQL)** - MySQL connection string

- **-Swagger_Base (LS\_S\_BASE)** - relative path to service, if you use reverse proxy and service placed not in /, you need to specify it

- **-Swagger_Url (LS\_S\_URL)** - swagger.json url, you need to specify it if is reverse proxy used

## Service Environments

### Development

Without authentication, in-memory database, test methods is allowed.

### Stage

With authentication, MySQL database, test methods is allowed.

### Production

With authentication, MySQL database, test methods is disabled.

## Client Usage

Full API docs you can view [here](https://konhit.xyz/lbservice/swagger/ui/index.html).

### Retrive scores

```
GET /api/Score/top/{game}?max={max}&param={param}&version={version}
```

**Parameters:**

- **game** - game name (required)
- **max** - max results
- **param** - parameter to filter results (like leaderboard type, level index or something else)
- **version** - version to filter results

### Post scores

```
POST /api/Score/
```
```
{
  "game": "gameName",
  "version": "1.0.0",
  "param": "level1",
  "score": 100,
  "user": "userName",
}
```


## Recommendations

Service use [basic authentication] (https://en.wikipedia.org/wiki/Basic_access_authentication), so client name/password is not encrypted and you need to use https reverse proxy like [nginx] (https://nginx.ru/en/) for security reasons. 
