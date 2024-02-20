using EventManager.API.Data;
using EventManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly DataContext context;

    public EventsController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<List<Event>> Get()
    {
        List<Event>? events = context.Events.ToList();

        if(events.Count <= 0) {
            return NotFound();
        }

        return events;
    }

    [HttpGet("{id}")]
    public ActionResult<Event> GetById(string id)
    {
        Event? currentEvent = context.Events.Where(evt => evt.Id.ToString().ToUpper() == id.ToUpper()).FirstOrDefault();

        if (currentEvent == null)
        {
            return NotFound();
        }

        return currentEvent;
    }

    [HttpPost(Name = "Create")]
    public IActionResult Create(Event newEvent)
    {
        Event? currentEvent = context.Events.Where(evt => evt.Id == newEvent.Id).FirstOrDefault();

        if(currentEvent != null) {
            return BadRequest(error: "O evento informado já existe.");
        }

        context.Events.Add(newEvent);
        context.SaveChanges();

        return Created();
    }

    [HttpPut(Name = "Update")]
    public IActionResult Update(Event updatedEvent)
    {
        Event? currentEvent = context.Events.Where(evt => evt.Id == updatedEvent.Id).FirstOrDefault();

        if (currentEvent == null)
        {
            return NotFound();
        }

        currentEvent.Title = updatedEvent.Title;
        currentEvent.ImageURL = updatedEvent.ImageURL;
        currentEvent.Location = updatedEvent.Location;
        currentEvent.Date = updatedEvent.Date;
        currentEvent.Allotment = updatedEvent.Allotment;
        currentEvent.Slots = updatedEvent.Slots;

        context.SaveChanges();

        return Accepted();
    }

    [HttpDelete(Name = "Delete")]
    public IActionResult Delete(string id)
    {
        Event? currentEvent = context.Events.Where(evt => evt.Id.ToString().ToUpper() == id.ToUpper()).FirstOrDefault();

        if (currentEvent == null)
        {
            return NotFound();
        }

        context.Events.Remove(currentEvent);
        context.SaveChanges();

        return Accepted();
    }
}
