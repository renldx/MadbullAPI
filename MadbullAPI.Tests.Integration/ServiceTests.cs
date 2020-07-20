using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MadbullAPI.Models;
using MadbullAPI.Services;

namespace MadbullAPI.Tests.Integration
{
    public class ServiceTests : IClassFixture<DbFixture>
    {
        private readonly DbFixture Fixture;

        public ServiceTests(DbFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task ExerciseServicesCRUD()
        {
            var exerciseService = new ExerciseService(Fixture.DbSettings);

            // Create

            var name = "Squat";
            var type = Enums.ResistanceType.Dynamic;
            var unit = 20;

            var exercise = exerciseService.Create(new Exercise(name, type, unit));

            Assert.True(exercise is Exercise);
            Assert.True(exercise.Name == name);
            Assert.True(exercise.ResistanceType == type);
            Assert.True(exercise.ResistanceUnit == unit);

            // Read

            var exercises = exerciseService.Get();

            Assert.True(exercises.Any());
            Assert.True(exercises.All(e => e is Exercise));

            exercise = exerciseService.Get(exercises.First().Id);

            Assert.True(exercise is Exercise);
            Assert.True(exercise.Id == exercises.First().Id);

            // Update

            var newName = "Deadlift";

            exercise.Name = newName;

            exerciseService.Update(exercise.Id, exercise);

            exercise = exerciseService.Get(exercise.Id);

            Assert.True(exercise is Exercise);
            Assert.True(exercise.Name == newName);

            // Delete

            exerciseService.Remove(exercise.Id);

            exercise = exerciseService.Get(exercise.Id);

            Assert.True(exercise is null);
        }

        [Fact]
        public async Task WorkoutServicesCRUD()
        {
            Assert.True(false);
        }
    }
}
