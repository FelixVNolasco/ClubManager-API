using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagerAPI.Dtos;

namespace ManagerAPI.Clients
{
    public class StudentClient
    {
        private readonly HttpClient httpClient;

        public StudentClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<IReadOnlyCollection<StudentDto>> GetCatalogItemsAsync()
        {
            var students = await httpClient.GetFromJsonAsync<IReadOnlyCollection<StudentDto>>("/students");
            return students;
        }
    }
}
