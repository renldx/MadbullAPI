namespace MadbullAPI.Models
{
    public interface IMadbullDatabaseSettings
    {
        string ExercisesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class MadbullDatabaseSettings : IMadbullDatabaseSettings
    {
        public string ExercisesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
