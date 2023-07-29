using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player;
using WebApiDotnet.Repositories;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerController(
            IPlayerRepository playerRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerEntity>>> Get()
        {
            var players = await _playerRepository.GetAll();
            return Ok(players);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PlayerEntity playerEntity)
        {
            throw new();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlayerRequest playerRequest)
        {
            var playerEntity = _mapper.Map<PlayerEntity>(playerRequest);
            await _playerRepository.Add(playerEntity);
            return Ok(playerEntity);
        }
            
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new();
        }

    }
}
