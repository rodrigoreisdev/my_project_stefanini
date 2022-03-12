using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response
{
    public class GetAllPersonResponse: BaseResponse
    {
        public List<PersonDto> Persons { get; set; }
    }
}
