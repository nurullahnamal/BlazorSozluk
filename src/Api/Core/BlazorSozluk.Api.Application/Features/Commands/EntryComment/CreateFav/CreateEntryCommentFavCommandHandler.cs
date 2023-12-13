using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common;
using BlazorSozluk.Common.Events.EntryCommand;
using BlazorSozluk.Common.Infrastructure;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public  class CreateEntryCommentFavCommandHandler:IRequestHandler<CreateEntryCommentFavCommand,bool>
    {
        public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName:SozlukConstants.FavExchangeName,
                                                exchangeType:SozlukConstants.DefaultExchangeType,
                                                queueName:SozlukConstants.CreateEntryCommentFavQueueName,
                                                 obj:new CreateEntryCommentFavEvent()

                {
                    EntryCommandId = request.EntryCommandId,
                    CreatedBy = request.UserId
                });

            return await Task.FromResult(true);
        }
    }
}
