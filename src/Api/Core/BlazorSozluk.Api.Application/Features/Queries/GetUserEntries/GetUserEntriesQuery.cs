﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common.Models.Page;
using BlazorSozluk.Common.Models.Queries;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Queries.GetUserEntries
{
    public class GetUserEntriesQuery:BasePagedQuery,IRequest<PagedViewModal<GetUserEntriesDetailViewModel>>
    {

        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public GetUserEntriesQuery( Guid? userId, string userName=null,int page= 1, int pageSize=10) : base(page, pageSize)
        {
            UserId = userId;
            UserName = userName;
        }

     
       
    }
}
