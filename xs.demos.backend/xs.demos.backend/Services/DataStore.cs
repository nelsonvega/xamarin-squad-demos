using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xs.demos.backend.models;
using xs.demos.backend.Models;

namespace xs.demos.backend.Services
{
    public class DataStore:IDataStore<Person>
    {
        public async Task<Person> GetAsync(string id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
            var json = await client.GetStringAsync($"api/Person/"+id);

            return await Task.Run(() => JsonConvert.DeserializeObject<Person>(json));
        }

        public async Task<IEnumerable<Person>> GetAsync(bool forceRefresh = false)
        {
            var client = new HttpClient();
            client.BaseAddress=new Uri($"{App.AzureBackendUrl}/");
            var json = await client.GetStringAsync($"api/Person");

            return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Person>>(json));
        }

        public async Task<Boolean> AddAsync(Person person) {

            if (person == null)
                return false;
            var serializedItem = JsonConvert.SerializeObject(person);
            var client = new HttpClient();
            var response = await client.PostAsync($"api/person", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<Boolean> UpdateAsync(Person person)
        {

            if (person == null)
                return false;
            var serializedItem = JsonConvert.SerializeObject(person);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var client = new HttpClient();
            var response = await client.PutAsync($"api/person", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;
            var client = new HttpClient();
            var response = await client.DeleteAsync($"api/Person/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
