using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Events.EntryCommand
{
    public class CreateEntryCommentFavEvent
    {

        public Guid EntryCommandId { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
