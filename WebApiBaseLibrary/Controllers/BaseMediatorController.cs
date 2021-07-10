using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiBaseLibrary.Responses;

namespace WebApiBaseLibrary.Controllers
{
    public class BaseMediatorController : BaseController
    {
        protected IMediator Mediator { get; }

        public BaseMediatorController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public Task<ActionResult<TResult>> SendToMediatorAsync<TResult>(IRequest<IResponse<TResult>> request)
        {
            return ExecuteActionAsync(Mediator.Send(request));
        }
    }
}