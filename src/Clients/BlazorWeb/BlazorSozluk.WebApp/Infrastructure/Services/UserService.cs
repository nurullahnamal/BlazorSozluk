using System.Net.Http.Json;
using System.Text.Json;
using BlazorSozluk.Common.Events.User;
using BlazorSozluk.Common.Infrastructure.Exceptions;
using BlazorSozluk.Common.Infrastructure.Results;
using BlazorSozluk.Common.Models.Queries;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly HttpClient Client;

        public UserService(HttpClient client)
        {
            this.Client=client;
        }


        public async Task<UserDetailViewModel> GetUserDetail(Guid id)
        {
            var userDetail = await Client.GetFromJsonAsync<UserDetailViewModel>($"/api/User/{id}");
            return userDetail;
        }

        public async Task<UserDetailViewModel> GetUserDetail(string userName)
        {
            var userDetail = await Client.GetFromJsonAsync<UserDetailViewModel>($"/api/User/UserName/{userName}");
            return userDetail;
        }

        public async Task<bool> UpdateUser(UserDetailViewModel user)
        {
            var res = await Client.PostAsJsonAsync($"/api/User/Update", user);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
        {
            var command = new ChangeUserPasswordCommand(null, oldPassword, newPassword);
            var httpResponse = await Client.PostAsJsonAsync($"/api/User/ChangePassword", command);

            if (httpResponse!= null && !httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode==System.Net.HttpStatusCode.BadRequest)
                {
                    var responseStr=await httpResponse.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
                    responseStr = validation.FlattenErrors;
                    throw new DatabaseValidationException(responseStr);

                }

                return false;
            }

            return httpResponse.IsSuccessStatusCode;

        }
    }
}
