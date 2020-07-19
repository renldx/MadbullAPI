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
        public string ExercisesCollectionName { get; set; }
        public string CyclesCollectionName { get; set; }
        public string WorkoutsCollectionName { get; set; }
        public string SessionsCollectionName { get; set; }
        public string SetsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
