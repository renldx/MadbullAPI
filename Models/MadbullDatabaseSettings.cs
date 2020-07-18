namespace MadbullAPI.Models
{
    public interface IMadbullDatabaseSettings
    {
        string CyclesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class MadbullDatabaseSettings : IMadbullDatabaseSettings
    {
        public string CyclesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
