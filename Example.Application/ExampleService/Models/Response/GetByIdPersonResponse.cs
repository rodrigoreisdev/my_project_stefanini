using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public PersonDto person { get; set; }
    }
}
