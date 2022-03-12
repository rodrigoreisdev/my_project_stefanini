using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Application.ExampleService.Models.Dtos
{
    public class PersonDto
    {
        public int id { get; set; }
        public string name_person { get; set; }
        public string cpf { get; set; }
        public int age { get; set; }
        public CityDto city { get; set; }

        public static explicit operator PersonDto(Domain.ExampleAggregate.Person v)
        {
            return new PersonDto()
            {
                id = v.id,
                name_person = v.name_person,
                cpf = v.cpf,
                age = v.age,
                city = (CityDto)v.city
            };
        }

    }
}
