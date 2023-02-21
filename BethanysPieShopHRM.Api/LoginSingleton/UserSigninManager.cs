using BethanysPieShopHRM.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.LoginSingleton
{

    public sealed class UserSigninManager
    {
        private static int counter = 0;
        private static readonly object Instancelock = new object();
        private readonly HttpClient _httpClient;

        private UserSigninManager()
        {        
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44340/");
        }

        private static UserSigninManager instance = null;

        public static UserSigninManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new UserSigninManager();
                        }

                    }
                }
                return instance;
            }
        }

        public Employee CurrentUser { get; set; }

        public bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public async Task<Employee> Login(int employeeId)
        {
            CurrentUser = await JsonSerializer.DeserializeAsync<Employee>(await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return CurrentUser;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}

