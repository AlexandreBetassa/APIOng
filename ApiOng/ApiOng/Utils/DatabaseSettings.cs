﻿namespace ApiOng.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string AnimalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
