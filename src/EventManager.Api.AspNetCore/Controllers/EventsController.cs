namespace EventManager.Api.AspNetCore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Application;
    using Models.Dtos;

    [Route("api/[controller]", Name = "EventsRoute")]
    public class EventsController : Controller
    {
        private readonly IEventsApplication application;

        public EventsController(
            IEventsApplication application)
        {
            this.application = application;
        }

        // GET api/values
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Get()
        {
            return Ok(this.application.GetList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Get(int id)
        {
            var dto = this.application.GetById(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]EventDto dto)
        {
            if (dto == null) return BadRequest();
            this.application.Create(dto);
            return Created(Url.Link("EventsRoute", new { id = dto.Id }), dto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EventDto dto)
        {
            if (dto == null) return BadRequest();
            dto.Id = id;
            this.application.Update(dto);
            return Ok(dto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dto = this.application.GetById(id);
            if (dto == null) return NotFound();
            this.application.Delete(dto);
            return NoContent();
        }
    }
}
