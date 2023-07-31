using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers;

public class BaseCrudController<TEntity, TEntityRequest, TEntityResponse> : Controller
{
    //TODO -> How we can use IEntityRepository instead of IBaseRepository<TEntity>
    
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public virtual async Task<ActionResult> Post([FromBody] TEntityRequest entityRequest)
    {
        try
        {
            var entityRequestMap = _mapper.Map<TEntity>(entityRequest);
            var entity = await _entityRepository.Add(entityRequestMap);
            var entityResponse = _mapper.Map<TEntityResponse>(entity);

            return Created("GetById", entityResponse);
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public virtual async Task<IActionResult> Get()
    {
        var entities = await _entityRepository.GetAll();
        var entitiesResponses = _mapper.Map<IEnumerable<TEntityResponse>>(entities);
        
        return Ok(entitiesResponses);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public virtual async Task<IActionResult> Get(int id)
    {
        var entity = await _entityRepository.GetById(id);
        var entityResponse = _mapper.Map<TEntityResponse>(entity);
        
        if (entity == null)
            return NotFound();
        
        return Ok(entityResponse);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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