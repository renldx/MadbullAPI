using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MadbullAPI.Models;
using MadbullAPI.Services;

namespace MadbullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkoutService workoutService;

        public WorkoutsController(WorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [HttpGet]
        public ActionResult<List<Workout>> Get() =>
            workoutService.Get();

        [HttpGet("{id:length(24)}", Name = "GetWorkout")]
        public ActionResult<Workout> Get(string id)
        {
            var workout = workoutService.Get(id);

            if (workout is Workout) { return workout; }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Workout> Create(Workout workout)
        {
            try
            {
                workoutService.Create(workout);
            }
            catch (MongoWriteException e)
            {
                Console.Write($"{e} {e.Message}");
            }

            return CreatedAtRoute("GetWorkout", new { id = workout.Id }, workout);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Workout workoutIn)
        {
            var workout = workoutService.Get(id);

            if (workout is Workout)
            {
                workoutService.Update(id, workoutIn);
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
            var workout = workoutService.Get(id);

            if (workout is Workout)
            {
                workoutService.Remove(workout.Id);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
