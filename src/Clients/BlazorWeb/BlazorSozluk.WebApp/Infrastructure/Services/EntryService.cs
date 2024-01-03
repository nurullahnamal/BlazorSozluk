using System.Net.Http.Json;
using System.Reflection;
using BlazorSozluk.Common.Models.Page;
using BlazorSozluk.Common.Models.Queries;
using BlazorSozluk.Common.Models.RequestModels;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient client;

        public EntryService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<GetEntriesViewModel>> GetEntries()
        {
            var result =
                await client.GetFromJsonAsync<List<GetEntriesViewModel>>("/api/Entry?todaysEnties=false&count=30");
            return result;
        }

        public async Task<GetEntryDetailViewModel> GetEntryDetail(Guid entryId)
        {
            var result = await client.GetFromJsonAsync<GetEntryDetailViewModel>($"/api/Entry/{entryId}");
            return result;
        }

        public async Task<PagedViewModal<GetEntryDetailViewModel>> GetMainPageEntries(int page, int pageSize)
        {
            var result =
                await client.GetFromJsonAsync<PagedViewModal<GetEntryDetailViewModel>>(
                    $"/api/Entry/MainPageEntries?page={page}&pageSize={pageSize}");
            return result;
        }

        public async Task<PagedViewModal<GetEntryDetailViewModel>> GetProfilePageEntries(int page, int pageSize, string userName = null)
        {
            var result =
                await client.GetFromJsonAsync<PagedViewModal<GetEntryDetailViewModel>>(
                    $"/api/Entry/UserEntries?userName={userName}&page{page}&pageSize={pageSize}");
            return result;
        }

        public async Task<PagedViewModal<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize)
        {
            var result =
                await client.GetFromJsonAsync<PagedViewModal<GetEntryCommentsViewModel>>(
                    $"/api/Entry/Comments/{entryId}?page={page}&pageSize={pageSize}");
            return result;
        }

        public async Task<Guid> CreateEntry(CreateEntryCommand command)
        {
            var res = await client.PostAsJsonAsync("/api/Entry/CreateEntry", command);

            if (!res.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await res.Content.ReadAsStringAsync();

            return new Guid(guidStr.Trim('"'));
        }

        public async Task<Guid> CreateEntryComment(CreateEntryCommentCommand command)
        {
            var res = await client.PostAsJsonAsync("/api/Entry/CreateCommentEntry", command);

            if (!res.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await res.Content.ReadAsStringAsync();

            return new Guid(guidStr.Trim('"'));
        }

        public async Task<List<SearchEntryViewModel>> SearchBySubject(string searchText)
        {
            var result =
                await client.GetFromJsonAsync<List<SearchEntryViewModel>>($"/api/Entry/Search?searchText={searchText}");
            return result;
        }
    }
}
