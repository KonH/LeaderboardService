using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;
using LeaderboardService.Managers;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class GameController : Controller
	{
		public IGameRepository Games { get; set; }
		public IAuthManager Auth { get; set; }

		public GameController(IGameRepository games, IAuthManager auth)
		{
			Games = games;
			Auth = auth;
		}

		[HttpGet]
		public IEnumerable<Game> GetAll([FromBasicAuth] string auth)
		{
			if (!Auth.IsAllowed(auth, UserPermission.ReadGames))
			{
				Response.StatusCode = Auth.StatusCode;
				return null;
			}
			return Games.GetAll();
		}

		[HttpGet("{name}", Name = "GetGame")]
		[ProducesResponseType(typeof(User), 200)]
		public IActionResult GetByName([FromBasicAuth] string auth, string name)
		{
			if (!Auth.IsAllowed(auth, name, UserPermission.ReadGames))
			{
				return Auth.Result;
			}
			var item = Games.Find(name);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		[ProducesResponseType(typeof(User), 201)]
		public IActionResult Create([FromBasicAuth] string auth, [FromBody] Game item)
		{
			if ( item == null )
			{
				return BadRequest();
			}
			if (!Auth.IsAllowed(auth, item.Name, UserPermission.PostGames))
			{
				return Auth.Result;
			}
			if ( Games.Find(item.Name) != null ) 
			{
				return BadRequest();
			}

			Games.Add(item);
			return CreatedAtRoute("GetGame", new { name = item.Name }, item);
		}

		[HttpPatch("{name}")]
		public IActionResult Update([FromBasicAuth] string auth, [FromBody] Game item, string name)
		{
			if (item == null)
			{
				return BadRequest();
			}
			if (!Auth.IsAllowed(auth, name, UserPermission.UpdateGames))
			{
				return Auth.Result;
			}

			var game = Games.Find(name);
			if (game == null)
			{
				return NotFound();
			}

			item.Name = game.Name;

			Games.Update(item);
			return new NoContentResult();
		}

		[HttpDelete("{name}")]
		public IActionResult Delete([FromBasicAuth] string auth, string name)
		{
			if (!Auth.IsAllowed(auth, name, UserPermission.UpdateGames))
			{
				return Auth.Result;
			}
			var game = Games.Find(name);
			if (game == null)
			{
				return NotFound();
			}

			Games.Remove(name);
			return new NoContentResult();
		}
	}
}