using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.ExampleAggregate
{
    public sealed class City
    {
        private City(string name_city, string uf)
        {
            this.name_city = name_city;
            this.uf = uf;
        }

        public int id { get; set; }
        public string name_city { get; set; }
        public string uf { get; set; }
        
      

        public static City Create(string name_city, string uf)
        {
            if (name_city == null)
                throw new ArgumentException("Invalid " + nameof(name_city));

            if (uf == null)
                throw new ArgumentException("Invalid " + nameof(uf));

            return new City(name_city, uf);
        }

        public void Update(string name_city, string uf)
        {
            if (name_city != null)
                this.name_city = name_city;

            if (uf != null)
                this.uf = uf;

        }
    }
}
