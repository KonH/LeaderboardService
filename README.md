# LeaderboardService

TODO

## Overview

TODO

## Example

You can look at example [here](https://konhit.xyz/lbservice/swagger/ui/index.html). Test service contains:

- HTTPS support using nginx
- Test game **testGame** which ready to use
- Test user **testUser** with post and read scores permissions for test game (password: **mGPRudr8**, auth header: **Basic dGVzdFVzZXI6bUdQUnVkcjg=**)


## Installation

### Docker

TODO

```
docker pull konh/lbservice:latest
```

```
docker run --name lbservice --net isolated -p 8080:8080 -e LS_MYSQL="server=mysql;userid=root;password=root;database=leaderboards;" konh/lbservice:latest
```

### Manually

TODO

### MySQL preparation

TODO

```
INSERT INTO leaderboards.User (Name, Password) VALUES ("admin", "admin_password");
INSERT INTO leaderboards.UserRole (User, Game, Permissions) VALUES ("admin", "", 511);
```

### Games and users setup

TODO

## Service Settings

TODO

- LS_PORT

- LS_ENV

- LS_MYSQL

## Client Usage

TODO

## Recommendations

TODO
