using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Repositories;
using LeaderboardService.Models;
using Microsoft.AspNetCore.Hosting;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class TestController : Controller
	{
		IHostingEnvironment Env { get; set; }
		IUserRepository  Users  { get; set; }
		IGameRepository  Games  { get; set; }
		IScoreRepository Scores { get; set; }

		public TestController(IHostingEnvironment env, IUserRepository users, IGameRepository games, IScoreRepository scores) 
		{
			Env = env;
			Users = users;
			Games = games;
			Scores = scores;
		}

		[HttpPost("cleanup")]
		public IActionResult CleanUp()
		{
			if( Env.IsProduction() )
			{
				return NotFound("Not supported");
			}
			var users = Users.GetAll().ToArray();
			foreach(var user in users)
			{
				Users.Remove(user.Name);
			}
			var games = Games.GetAll().ToArray();
			foreach(var game in games)
			{
				Games.Remove(game.Name);
			}
			var scores = Scores.GetHistory().ToArray();
			foreach(var score in scores)
			{
				Scores.Remove(score.Key);
			}
			return Json("Cleaned");
		}

		[HttpPost("prepare")]
		public IActionResult Prepare()
		{
			if ( Env.IsProduction() )
			{
				return NotFound("Not supported");
			}
			PrepareUsers();
			PrepareGames();
			PrepareScores();
			return Json("Prepared");
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		void PrepareUsers()
		{
			// user:user with default rights for Game
			Users.Add(new User {
				Name = "user",
				Password = "user",
				Roles = new List<UserRole>(new UserRole[] {
					new UserRole() {
						Permissions = UserPermission.PostScores | UserPermission.ReadScores,
						Game = "Game"
					}
				})
			});

			// admin:admin with full rights
			Users.Add(new User {
				Name = "admin",
				Password = "admin",
				Roles = new List<UserRole>(new UserRole[] {
					new UserRole() {
						Permissions =
							UserPermission.PostScores |
							UserPermission.ReadScores |
							UserPermission.UpdateScores |
							UserPermission.ReadGames |
							UserPermission.PostGames |
							UserPermission.UpdateGames |
							UserPermission.ReadUsers |
							UserPermission.PostUsers |
							UserPermission.UpdateUsers
					}
				})
			});
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		void PrepareGames()
		{
			Games.Add(new Game { Name = "Game" });
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		void PrepareScores()
		{
			Scores.Add(new ScoreItem { Game = "Game", Version = "1.0.0", Param = "level1", Score = 20 });
			Scores.Add(new ScoreItem { Game = "Game", Version = "1.0.1", Param = "level1", Score = 10 });
			Scores.Add(new ScoreItem { Game = "Game", Version = "1.0.0", Param = "level2", Score = 30 });
		}
	}
}