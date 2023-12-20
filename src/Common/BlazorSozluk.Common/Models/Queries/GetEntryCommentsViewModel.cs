using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.Queries
{
    public class GetEntryCommentsViewModel : BaseFooterRateViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public bool IsFavorited { get; set; }
        public int FavoritedCount { get; set; }
    }
}
