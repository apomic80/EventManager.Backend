namespace EventManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Application;
    using Models.Dtos;

    [Route("api/[controller]", Name = "AgendaRoute")]
    public class AgendaController : Controller
    {
        private readonly IAgendaApplication application;

        public AgendaController(
            IAgendaApplication application)
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
        public IActionResult Post([FromBody]AgendaItemDto dto)
        {
            if (dto == null) return BadRequest();
            this.application.Create(dto);
            return Created(Url.Link("SpeakersRoute", new { id = dto.Id }), dto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AgendaItemDto dto)
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
