using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class GameController : Controller
	{
		public IGameRepository Games { get; set; }

		public GameController(IGameRepository games)
		{
			Games = games;
		}

		[HttpGet]
		public IEnumerable<Game> GetAll()
		{
			return Games.GetAll();
		}

		[HttpGet("{name}", Name = "GetGame")]
		public IActionResult GetByName(string name)
		{
			var item = Games.Find(name);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Game item)
		{
			if ( (item == null) || (Games.Find(item.Name) != null) )
			{
				return BadRequest();
			}
			Games.Add(item);
			return CreatedAtRoute("GetGame", new { name = item.Name }, item);
		}

		[HttpPut("{name}")]
		public IActionResult Update(string name, [FromBody] Game item)
		{
			if (item == null || item.Name != name)
			{
				return BadRequest();
			}

			var game = Games.Find(name);
			if (game == null)
			{
				return NotFound();
			}

			Games.Update(item);
			return new NoContentResult();
		}

		[HttpPatch("{name}")]
		public IActionResult Update([FromBody] Game item, string name)
		{
			if (item == null)
			{
				return BadRequest();
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
		public IActionResult Delete(string name)
		{
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