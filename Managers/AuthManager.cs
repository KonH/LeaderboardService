using System;
using System.Text;
using System.Linq;
using LeaderboardService.Models;
using LeaderboardService.Repositories;

namespace LeaderboardService.Managers
{
	// TODO: Impletement auth
    public class AuthManager : IAuthManager
    {
		class Credentials {
			public string Name { get; set; }
			public string Password { get; set; }

			public Credentials(string name, string password)
			{
				Name = name;
				Password = password;
			}
		}

		public IUserRepository Users { get; set; }
		public int StatusCode { get; private set; }

		public AuthManager(IUserRepository users) 
		{
			Users = users;
		}

		public bool IsAllowed(string header, UserPermission permission) 
		{
			return IsAllowed(header, null, permission);
		}

		bool NeedAuth() 
		{
			StatusCode = 401;
			return false;
		}

		bool Forbidden()
		{
			StatusCode = 403;
			return false;
		}

		bool Normal() 
		{
			StatusCode = 200;
			return true;
		}

		public bool IsAllowed(string header, string game, UserPermission permission) 
		{
			var credentials = ExtractCredentials(header);
			if ( credentials != null )
			{
				var user = FindUser(credentials);
				if ( user != null )
				{
					var role = FindRole(user, game);
					if ( (role != null) && (HasPermission(role, permission)) )
					{
						return Normal();
					} else {
						return Forbidden();
					}
				}
			} 
			return NeedAuth();
		}

		User FindUser(Credentials credentials)
		{
			var users = Users.GetAll();
			if ( users != null )
			{
				var user = users.FirstOrDefault(u => u.Name == credentials.Name);
				if ( (user != null) && (user.Password == credentials.Password) )
				{
					return user;
				}
			}
			return null;
		}

		UserRole FindRole(User user, string game) 
		{
			return user.Roles.FirstOrDefault(role => role.Game == game);
		}

		bool HasPermission(UserRole role, UserPermission permission) 
		{
			return (role.Permissions & permission) == permission;
		}

		Credentials ExtractCredentials(string header) 
		{
			// Authorization: Basic QWxhZGRpbjpPcGVuU2VzYW1l
			if ( (header != null) && header.StartsWith("basic", StringComparison.OrdinalIgnoreCase) )
    		{
        		var token = header.Substring("Basic ".Length).Trim();
				try {
					var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
					var credentials = credentialString.Split(':');
					if ( (credentials != null) && (credentials.Length == 2) )
					{
						return new Credentials(credentials[0], credentials[1]);
					}
				} catch
				{
				}
    		}
			return null;
		}
    }
}