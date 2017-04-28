using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LeaderboardService.Models;
using LeaderboardService.Repositories;
using LeaderboardService.Managers;

namespace LeaderboardService.Controllers
{
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		public IUserRepository Users { get; set; }
		public IAuthManager Auth { get; set; }

		public UserController(IUserRepository users, IAuthManager auth)
		{
			Users = users;
			Auth = auth;
		}

		[HttpGet]
		public IEnumerable<User> GetAll([FromBasicAuth] string auth)
		{
			if (!Auth.IsAllowed(auth, UserPermission.ReadUsers))
			{
				Response.StatusCode = Auth.StatusCode;
				return null;
			}
			return Users.GetAll();
		}

		[HttpGet("{name}", Name = "GetUser")]
		[ProducesResponseType(typeof(User), 200)]
		public IActionResult GetByName([FromBasicAuth] string auth, string name)
		{
			if (!Auth.IsAllowed(auth, UserPermission.ReadUsers))
			{
				return Auth.Result;
			}
			var item = Users.Find(name);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		[ProducesResponseType(typeof(User), 201)]
		public IActionResult Create([FromBasicAuth] string auth, [FromBody] User item)
		{
			if (!Auth.IsAllowed(auth, UserPermission.PostUsers))
			{
				return Auth.Result;
			}
			if ( (item == null) || (Users.Find(item.Name) != null) )
			{
				return BadRequest();
			}
			Users.Add(item);
			return CreatedAtRoute("GetUser", new { name = item.Name }, item);
		}

		[HttpPatch("{name}")]
		public IActionResult Update([FromBasicAuth] string auth, [FromBody] User item, string name)
		{
			if (!Auth.IsAllowed(auth, UserPermission.UpdateUsers))
			{
				return Auth.Result;
			}
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
		public IActionResult Delete([FromBasicAuth] string auth, string name)
		{
			if (!Auth.IsAllowed(auth, UserPermission.UpdateUsers))
			{
				return Auth.Result;
			}
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