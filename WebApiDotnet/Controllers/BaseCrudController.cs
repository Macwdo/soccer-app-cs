using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers;

public class BaseCrudController<TEntity, TEntityRequest, TEntityResponse> : Controller
{
    private readonly IBaseRepository<TEntity> _entityRepository;
    private readonly IMapper _mapper;

    public BaseCrudController(
        IBaseRepository<TEntity> entityRepository,
        IMapper mapper
        )
    {
        _mapper = mapper;
        _entityRepository = entityRepository;
    }

    [HttpPost]
    public virtual async Task<ActionResult> Post([FromBody] TEntityRequest entityRequest)
    {
        var entityRequestMap = _mapper.Map<TEntity>(entityRequest);

        try
        {
            var entity = await _entityRepository.Add(entityRequestMap);
            var entityResponse = _mapper.Map<TEntityResponse>(entity);

            return Ok(entityResponse);
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
    
    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var entities = await _entityRepository.GetAll();
        var entitiesResponses = _mapper.Map<IEnumerable<TEntityResponse>>(entities);
        
        return Ok(entitiesResponses);
    }
    
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(int id)
    {
        var entity = await _entityRepository.GetById(id);
        var entityResponse = _mapper.Map<TEntityResponse>(entity);
        
        if (entity == null)
            return NotFound();
        
        return Ok(entityResponse);
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Put(int id, TEntityRequest entityRequest)
    {
        var entity = await _entityRepository.GetById(id);
        
        if (entity == null)
            return NotFound();

        try
        {
            var entityRequestMap = _mapper.Map(entityRequest, entity);
            var updatedEntity = _entityRepository.Update(entityRequestMap);
            
            return Ok(updatedEntity);
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }

        
    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var entity = await _entityRepository.GetById(id);
        if (entity == null)
            return NotFound();
        try
        {
            _entityRepository.Remove(entity);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}