using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.Page
{
    public class PagedViewModal<T> where T : class
    {
        public PagedViewModal() : this(new List<T>(),new Page())
        {

        }
        public PagedViewModal(IList<T> results, Page pageInfo)
        {
            Results = results;
            PageInfo = pageInfo;
        }

        public IList<T> Results{ get; set; }
        public Page PageInfo{ get; set; }
    }
}
