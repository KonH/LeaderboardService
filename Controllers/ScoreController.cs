using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class ScoreController : Controller
	{
		public IScoreRepository ScoreItems { get; set; }

		public ScoreController(IScoreRepository scoreItems)
		{
			ScoreItems = scoreItems;
		}

		public IEnumerable<ScoreItem> GetAll()
		{
			return ScoreItems.GetAll();
		}

		[HttpGet("{id}", Name = "GetScore")]
		public IActionResult GetById(string id)
		{
			var item = ScoreItems.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] ScoreItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			ScoreItems.Add(item);
			return CreatedAtRoute("GetScore", new { id = item.Key }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(string id, [FromBody] ScoreItem item)
		{
			if (item == null || item.Key != id)
			{
				return BadRequest();
			}

			var score = ScoreItems.Find(id);
			if (score == null)
			{
				return NotFound();
			}

			ScoreItems.Update(item);
			return new NoContentResult();
		}

		[HttpPatch("{id}")]
		public IActionResult Update([FromBody] ScoreItem item, string id)
		{
			if (item == null)
			{
				return BadRequest();
			}

			var score = ScoreItems.Find(id);
			if (score == null)
			{
				return NotFound();
			}

			item.Key = score.Key;

			ScoreItems.Update(item);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			var score = ScoreItems.Find(id);
			if (score == null)
			{
				return NotFound();
			}

			ScoreItems.Remove(id);
			return new NoContentResult();
		}
	}
}