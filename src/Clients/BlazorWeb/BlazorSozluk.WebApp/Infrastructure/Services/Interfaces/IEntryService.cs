using BlazorSozluk.Common.Models.Page;
using BlazorSozluk.Common.Models.Queries;
using BlazorSozluk.Common.Models.RequestModels;

namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IEntryService
    {

        Task<List<GetEntriesViewModel>> GetEntries();
        Task<GetEntryDetailViewModel> GetEntryDetail(Guid entryId);
        Task<PagedViewModal<GetEntryDetailViewModel>> GetMainPageEntries(int page, int pageSize);

        Task<PagedViewModal<GetEntryDetailViewModel>> GetProfilePageEntries(int page, int pageSize,
            string userName = null);

        Task<PagedViewModal<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize);

        Task<Guid> CreateEntry(CreateEntryCommand command);
        Task<Guid> CreateEntryComment(CreateEntryCommentCommand command);
        Task<List<SearchEntryViewModel>> SearchBySubject(string searchText);
    }
}
