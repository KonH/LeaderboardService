using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Repositories;
using LeaderboardService.Models;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class TestController : Controller
	{
		IUserRepository  Users  { get; set; }
		IGameRepository  Games  { get; set; }
		IScoreRepository Scores { get; set; }

		public TestController(IUserRepository users, IGameRepository games, IScoreRepository scores) 
		{
			Users = users;
			Games = games;
			Scores = scores;
		}

		[HttpPost("cleanup")]
		public IActionResult CleanUp()
		{
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
			var scores = Scores.GetAll(int.MaxValue).ToArray();
			foreach(var score in scores)
			{
				Scores.Remove(score.Key);
			}
			return Json("Cleaned");
		}

		[HttpPost("prepare")]
		public IActionResult Prepare()
		{
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