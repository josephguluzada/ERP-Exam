using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.AuthViewModels;
using RestSharp;

namespace ExamProgram.UI.Services.Implementations
{
    public class ApiService : IApiService
    {
        protected readonly IConfiguration Configuration;
        protected readonly RestClient _client;

        public ApiService(IConfiguration _configuration, IHttpContextAccessor _httpContextAccessor)
        {
            Configuration = _configuration;
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
    }
}
