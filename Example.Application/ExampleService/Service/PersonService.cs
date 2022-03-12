using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly PersonContext _db;

        public PersonService(ILogger<PersonService> logger, Infra.Data.PersonContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.Include(i => i.city).ToListAsync();
            return new GetAllPersonResponse()
            {
                Persons = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.Include(i => i.city).FirstOrDefaultAsync(item => item.id == id);

            if (entity != null) response.person = (PersonDto)entity;

            return response;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPerson = Domain.ExampleAggregate.Person.Create(request.name_person, request.age, request.cpf);
            var newCity = Domain.ExampleAggregate.City.Create(request.city.name_city, request.city.uf);

            newPerson.city = newCity;
            _db.Person.Add(newPerson);

            await _db.SaveChangesAsync();
            
            return new CreatePersonResponse() { Id = newPerson.id };
        }

        public async Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Person.Include(o => o.city).FirstOrDefaultAsync(item => item.id == id);

            if (entity != null)
            {
                entity.city.Update(request.city.name_city, request.city.uf);
                entity.Update(request.name_person, request.age, request.cpf);
                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }

        public async Task<DeletePersonResponse> DeleteAsync(int id)
        {

            var entity = await _db.Person.Include(o => o.city).FirstOrDefaultAsync(item => item.id == id);

            if (entity != null)
            {
                _db.Remove(entity.city);
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }
    }
}
