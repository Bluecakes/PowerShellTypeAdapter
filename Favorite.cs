namespace PowerShellTypeAdapter
{
    using System.Collections.Generic;

    public class Favorite
    {
        public Dictionary<string,object> Properties { get; set; }

        public Favorite(Dictionary<string,object> properties)
        {
            this.Properties = properties;
        }
    }
}