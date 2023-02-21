using BethanysPieShopHRM.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.LoginSingleton
{

    public sealed class UserSigninManager
    {
        private static readonly object Instancelock = new object();
        private readonly HttpClient _httpClient;

        public Employee CurrentUser { get; set; }

        public event Action? UserChange;

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

        public async Task<Employee> Login(int employeeId)
        {
            CurrentUser = await JsonSerializer.DeserializeAsync<Employee>(await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            OnUserChange();
            return CurrentUser;
        }

        public void Logout()
        {
            CurrentUser = null;
            OnUserChange();
        }

        public void OnUserChange()
        {
            UserChange?.Invoke();
        }
    }
}

