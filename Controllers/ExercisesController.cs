using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MadbullAPI.Models;
using MadbullAPI.Services;

namespace MadbullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseService exerciseService;

        public ExercisesController(ExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public ActionResult<List<Exercise>> Get() =>
            exerciseService.Get();

        [HttpGet("{id:length(24)}", Name = "GetExercise")]
        public ActionResult<Exercise> Get(string id)
        {
            var exercise = exerciseService.Get(id);

            if (exercise is Exercise) { return exercise; }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Exercise> Create(Exercise exercise)
        {
            exerciseService.Create(exercise);

            return CreatedAtRoute("GetExercise", new { id = exercise.Id.ToString() }, exercise);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Exercise exerciseIn)
        {
            var exercise = exerciseService.Get(id);

            if (exercise is Exercise)
            {
                exerciseService.Update(id, exerciseIn);
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
            var exercise = exerciseService.Get(id);

            if (exercise is Exercise)
            {
                exerciseService.Remove(exercise.Id);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
