namespace MadbullAPI.Models
{
    public interface IMadbullDatabaseSettings
    {
        string ExercisesCollectionName { get; set; }
        string CyclesCollectionName { get; set; }
        string WorkoutsCollectionName { get; set; }
        string SessionsCollectionName { get; set; }
        string SetsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class MadbullDatabaseSettings : IMadbullDatabaseSettings
    {
        public string ExercisesCollectionName { get; set; } = null!;
        public string CyclesCollectionName { get; set; } = null!;
        public string WorkoutsCollectionName { get; set; } = null!;
        public string SessionsCollectionName { get; set; } = null!;
        public string SetsCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
