using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Application.ExampleService.Models.Dtos
{
    public class CityDto
    {
        public int id { get; set; }

        public string name_city { get; set; }

        public string uf { get; set; }

        public static explicit operator CityDto(Domain.ExampleAggregate.City v)
        {
            return new CityDto()
            {
                id = v.id,
                name_city = v.name_city,
                uf = v.uf
        };
    }
}
}