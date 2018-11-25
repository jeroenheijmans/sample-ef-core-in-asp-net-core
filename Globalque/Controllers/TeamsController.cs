using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Globalque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly PeopleDbContext db;

        public TeamsController(PeopleDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            var Teams = db.Set<Team>().OrderBy(p => p.Id).Take(10).ToList();
            return Ok(Teams);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var Team = db.Set<Team>().Find(id);

            if (Team == null)
            {
                return NotFound();
            }

            return Ok(Team);
        }

        [HttpPost]
        public IActionResult Post(Team Team)
        {
            if (Team.Id != default(int))
            {
                return BadRequest("Can't supply the Id with POST");
            }

            db.Set<Team>().Add(Team);
            db.SaveChanges();

            return Created(new Uri($"/{Team.Id}", UriKind.Relative), Team);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Team Team)
        {
            if (Team.Id != default(int) && Team.Id != id)
            {
                return BadRequest("Id on Team had unexpected value");
            }

            Team.Id = id;
            db.Set<Team>().Update(Team);
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Team = db.Set<Team>().Find(id);

            if (Team == null)
            {
                return NotFound();
            }

            db.Set<Team>().Remove(Team);
            db.SaveChanges();

            return NoContent();
        }
    }
}
