using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        public PlayerController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerEntity>>> GetPlayers()
        {
            throw new();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerEntity>> GetPlayerEntity(int id)
        {
            throw new();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerEntity(int id, PlayerEntity playerEntity)
        {
            throw new();
        }

        [HttpPost]
        public async Task<ActionResult<PlayerEntity>> PostPlayerEntity(PlayerEntity playerEntity)
        {
            throw new();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerEntity(int id)
        {
            throw new();
        }

    }
}
