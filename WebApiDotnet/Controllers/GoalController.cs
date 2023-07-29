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
using WebApiDotnet.Model.Goal;
using WebApiDotnet.Repositories;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers
{
    [Route("api/goal")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GoalController(
            IGoalRepository goalRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalEntity>>> Get()
        {
            var goals = await _goalRepository.GetAll();
            return Ok(goals);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAll(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GoalEntity playerEntity)
        {
            throw new();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GoalRequest goalRequest)
        {
            var goalEntity = _mapper.Map<GoalEntity>(goalRequest);
            await _goalRepository.Add(goalEntity);
            return Ok();
        }
            
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new();
        }

    }
}