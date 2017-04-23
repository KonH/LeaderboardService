using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		public IUserRepository Users { get; set; }

		public UserController(IUserRepository users)
		{
			Users = users;
		}

		[HttpGet]
		public IEnumerable<User> GetAll()
		{
			return Users.GetAll();
		}

		[HttpGet("{name}", Name = "GetUser")]
		public IActionResult GetByName(string name)
		{
			var item = Users.Find(name);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] User item)
		{
			if ( (item == null) || (Users.Find(item.Name) != null) )
			{
				return BadRequest();
			}
			Users.Add(item);
			return CreatedAtRoute("GetUser", new { name = item.Name }, item);
		}

		[HttpPut("{name}")]
		public IActionResult Update(string name, [FromBody] User item)
		{
			if (item == null || item.Name != name)
			{
				return BadRequest();
			}

			var user = Users.Find(name);
			if (user == null)
			{
				return NotFound();
			}

			Users.Update(item);
			return new NoContentResult();
		}

		[HttpPatch("{name}")]
		public IActionResult Update([FromBody] User item, string name)
		{
			if (item == null)
			{
				return BadRequest();
			}

			var user = Users.Find(name);
			if (user == null)
			{
				return NotFound();
			}

			item.Name = user.Name;

			Users.Update(item);
			return new NoContentResult();
		}

		[HttpDelete("{name}")]
		public IActionResult Delete(string name)
		{
			var user = Users.Find(name);
			if (user == null)
			{
				return NotFound();
			}

			Users.Remove(name);
			return new NoContentResult();
		}
	}
}