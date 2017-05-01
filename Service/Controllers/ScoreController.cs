using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;
using LeaderboardService.Managers;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class ScoreController : Controller
	{
		public IScoreRepository ScoreItems { get; set; }
		public IGameRepository GameItems { get; set; }
		public IAuthManager Auth { get; set; }

		public ScoreController(IScoreRepository scoreItems, IGameRepository gameItems, IAuthManager auth)
		{
			ScoreItems = scoreItems;
			GameItems = gameItems;
			Auth = auth;
		}
	
		[HttpGet("top/{game}")]
		public IEnumerable<ScoreItem> GetTop([FromBasicAuth] string auth, string game, [FromQuery]int max = int.MaxValue, [FromQuery]string param = null, [FromQuery]string version = null)
		{
			if (!Auth.IsAllowed(auth, game, UserPermission.ReadScores))
			{
				Response.StatusCode = Auth.StatusCode;
				return null;
			}
			return ScoreItems.GetTop(max, game, param, version);
		}

		[HttpGet("history")]
		public IEnumerable<ScoreItem> GetHistory([FromBasicAuth] string auth, [FromQuery]string game = null, [FromQuery]string param = null, [FromQuery]string version = null, [FromQuery]string user = null)
		{
			if (!Auth.IsAllowed(auth, UserPermission.ReadScores))
			{
				Response.StatusCode = Auth.StatusCode;
				return null;
			}
			return ScoreItems.GetHistory(game, param, version, user);
		}

		[HttpGet("{id}", Name = "GetScore")]
		[ProducesResponseType(typeof(ScoreItem), 200)]
		public IActionResult GetById([FromBasicAuth] string auth, string id)
		{
			var item = ScoreItems.Find(id);
			if ( item != null )
			{
				if (!Auth.IsAllowed(auth, item.Game, UserPermission.ReadScores))
				{
					return Auth.Result;
				}
			}
			else
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ScoreItem), 201)]
		public IActionResult Create([FromBasicAuth] string auth, [FromBody] ScoreItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			if (!Auth.IsAllowed(auth, item.Game, UserPermission.PostScores))
			{
				return Auth.Result;
			}
			if (GameItems.Find(item.Game) == null)
			{
				return BadRequest("Game not found");
			}
			item.Date = DateTime.Now;
			ScoreItems.Add(item);
			return CreatedAtRoute("GetScore", new { id = item.Key }, item);
		}

		[HttpPatch("{id}")]
		public IActionResult Update([FromBasicAuth] string auth, [FromBody] ScoreItem item, string id)
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
			if (!Auth.IsAllowed(auth, score.Game, UserPermission.UpdateScores))
			{
				return Auth.Result;
			}

			item.Key = score.Key;

			if (GameItems.Find(item.Game) == null)
			{
				return BadRequest("Game not found");
			}

			ScoreItems.Update(item);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromBasicAuth] string auth, string id)
		{
			var score = ScoreItems.Find(id);
			if (score == null)
			{
				return NotFound();
			}
			if (!Auth.IsAllowed(auth, score.Game, UserPermission.UpdateScores))
			{
				return Auth.Result;
			}

			ScoreItems.Remove(id);
			return new NoContentResult();
		}
	}
}