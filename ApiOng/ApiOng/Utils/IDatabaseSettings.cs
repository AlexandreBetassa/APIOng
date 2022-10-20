namespace ApiOng.Utils
{
    public interface IDatabaseSettings
    {
        string PersonCollectionName { get; set; }
        string AnimalsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
