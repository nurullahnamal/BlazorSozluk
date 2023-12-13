using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common.ViewModels;
using MediatR;

namespace BlazorSozluk.Common.Models.RequestModels
{
    public class CreateEntryCommentVoteCommand:IRequest<bool>
    {
        public CreateEntryCommentVoteCommand(Guid entryCommandId, VoteType voteType, Guid createdBy)
        {
            EntryCommentId = entryCommandId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }

      public  CreateEntryCommentVoteCommand()
        {

        }
        public Guid EntryCommentId { get; set; }
        public VoteType VoteType { get; set;}
        public Guid CreatedBy{ get; set;}
    }
}
