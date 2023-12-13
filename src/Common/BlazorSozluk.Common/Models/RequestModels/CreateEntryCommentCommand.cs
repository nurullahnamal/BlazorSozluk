using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazorSozluk.Common.Models.RequestModels
{
    public class CreateEntryCommentCommand:IRequest<Guid>
    {
        public CreateEntryCommentCommand(Guid entryId, string content, Guid createdById)
        {
            EntryId = entryId;
            Content = content;
            CreatedById = createdById;
        }

        public CreateEntryCommentCommand()
        {

        }

        public Guid? EntryId { get; set; }
        public string Content { get; set; }
        public Guid? CreatedById { get; set; }
        
    }
}
