namespace Example.Application.ExampleService.Models.Response
{
public class UpdatePersonRequest
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
