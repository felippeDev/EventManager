using System.Net;
using EventManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    public List<Event> events = [
        new Event(){
            Id = Guid.Parse("8282ecc1-cbec-4690-bb8a-e49251d42cab"),
            Title = "Event1",
            ImageURL = "imageEvent1.png",
            Location = "São Paulo / BRA",
            Date = DateTime.Now.AddDays(15).ToString(),
            Allotment = 1,
            Slots = 500
        },
        new Event(){
            Id = Guid.Parse("1dd5de07-ea3d-49c9-9b21-be4f9aaa7c11"),
            Title = "Event2",
            ImageURL = "imageEvent2.png",
            Location = "Rio de Janeiro / BRA",
            Date = DateTime.Now.AddDays(15).ToString(),
            Allotment = 1,
            Slots = 200
        },
    ];

    public EventsController()
    {
    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return events;
    }

    [HttpGet("{id}")]
    public Event GetById(string id)
    {
        return events.Where(evt => evt.Id == Guid.Parse(id)).First();
    }

    [HttpPost(Name = "Create")]
    public IActionResult Create(Event newEvent)
    {
        events.Add(newEvent);

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut(Name = "Update")]
    public IActionResult Update(Event updatedEvent)
    {
        Event currentEvent = events.Where(evt => evt.Id == updatedEvent.Id).First();

        if (currentEvent != null)
        {
            currentEvent = updatedEvent;
        }

        return StatusCode((int)HttpStatusCode.Accepted);
    }

    [HttpDelete(Name = "Delete")]
    public IActionResult Delete(Guid eventId)
    {
        Event currentEvent = events.Where(evt => evt.Id == eventId).First();

        if (currentEvent != null)
        {
            events.Remove(currentEvent);
        }

        return StatusCode((int)HttpStatusCode.Continue);
    }
}
