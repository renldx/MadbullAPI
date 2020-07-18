using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MadbullAPI.Models;
using MadbullAPI.Services;

namespace MadbullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CyclesController : ControllerBase
    {
        private readonly CycleService cycleService;

        public CyclesController(CycleService cycleService)
        {
            this.cycleService = cycleService;
        }

        [HttpGet]
        public ActionResult<List<Cycle>> Get() =>
            cycleService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCycle")]
        public ActionResult<Cycle> Get(string id)
        {
            var cycle = cycleService.Get(id);

            if (cycle is Cycle) { return cycle; }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Cycle> Create(Cycle cycle)
        {
            cycleService.Create(cycle);

            return CreatedAtRoute("GetCycle", new { id = cycle.Id.ToString() }, cycle);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Cycle cycleIn)
        {
            var cycle = cycleService.Get(id);

            if (cycle is Cycle)
            {
                cycleService.Update(id, cycleIn);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var cycle = cycleService.Get(id);

            if (cycle is Cycle)
            {
                cycleService.Remove(cycle.Id);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
