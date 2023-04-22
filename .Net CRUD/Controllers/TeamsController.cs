using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Data;
using PostgresDb.Models;

namespace PostgresDb.Controllers;

[ApiController]

[Route("api/[controller]")]
public class TeamsController : ControllerBase
{

private static AppDbContext _context;
public TeamsController(AppDbContext context)
{
    _context = context;
}


    [HttpGet]
    // [Route("GetBestTeam")]
    public async Task<IActionResult> Get()
    {

        var teams = await _context.Teams.ToListAsync();

        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (team == null)
            return BadRequest("Invalid Id");

        return Ok(team);
    }

    [HttpPost]

    public async Task<IActionResult> Post(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", team.Id, team);

    }

    [HttpPatch]

    public async Task<IActionResult> Patch(int id, int year)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (team == null)
            return BadRequest("Invalid Id");

        team.Year = year;
        await _context.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete]

    public async Task<IActionResult> Delete(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (team == null)
            return BadRequest("Invalid Id");

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        
        return NoContent();

    }


}
