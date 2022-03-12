using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Service
{
    public interface IPersonService
    {
        Task<GetAllPersonResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(int id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request);
        Task<DeletePersonResponse> DeleteAsync(int id);
    }
}
