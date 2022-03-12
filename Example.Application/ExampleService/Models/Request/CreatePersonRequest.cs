using Example.Domain.ExampleAggregate;

namespace Example.Application.ExampleService.Models.Request
{
    public class CreatePersonRequest
    {
        public string name_person { get; set; }
        public int age { get; set; }
        public string cpf { get; set; }
        public CityRequest city { get; set; }
    }

    public class CityRequest 
    {
        public string name_city { get; set; }
        public string uf { get; set; }
    }
}
