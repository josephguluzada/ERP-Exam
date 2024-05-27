using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.AuthViewModels;
using RestSharp;

namespace ExamProgram.UI.Services.Implementations
{
    public class ApiService : IApiService
    {
        protected readonly IConfiguration Configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly RestClient _client;

        public ApiService(IConfiguration _configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = _configuration;
            _httpContextAccessor = httpContextAccessor;
            _client = new RestClient(_configuration["Api:Url"]);

            var token = _httpContextAccessor.HttpContext.Request.Cookies["token"];
            if (!string.IsNullOrEmpty(token))
                _client.AddDefaultHeader("Authorization", "Bearer " + token);
        }
        public async Task<AuthViewModel> Login(LoginViewModel model)
        {
            var request = new RestRequest("/auth/login", Method.Post);

            request.AddJsonBody(model);
            var response = await _client.ExecuteAsync<AuthViewModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ApiException(response.StatusCode, response.Content);

            return response.Data;
        }

        public async Task Logout()
        {
            var request = new RestRequest("/auth/logout", Method.Get);
            var response = await _client.ExecuteAsync<AuthViewModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ApiException(response.StatusCode, response.Content);
            if (_httpContextAccessor.HttpContext?.Request.Cookies["token"] is not null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("token");
            }
        }
    }
}
