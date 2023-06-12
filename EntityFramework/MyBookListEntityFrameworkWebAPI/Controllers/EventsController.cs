using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookListEntityFrameworkBLL.DTO;
using MyBookListEntityFrameworkBLL.Interfaces;
using MyBookListEntityFrameworkBLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookListEntityFrameworkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EventsDTO>>> GetAllEventsAsync()
        {
            try
            {
                var events = await eventsService.GetAllAsync();
                return Ok(events);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventsDTO>> GetEventByIdAsync(int id)
        {
            try
            {
                var events = await eventsService.GetByIdAsync(id);
                if (events == null)
                    return NotFound();

                return Ok(events);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateEventAsync([FromBody] EventsDTO eventDto)
        {
            try
            {
                await eventsService.AddAsync(eventDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] EventsDTO eventDto)
        {
            try
            {
                if (eventDto.IDEvent != id)
                    return BadRequest();

                await eventsService.UpdateAsync(eventDto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteEventAsync(int id)
        {
            try
            {
                await eventsService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
