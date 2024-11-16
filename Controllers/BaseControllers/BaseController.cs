using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace LuftbornTask.Controllers.BaseControllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    [ApiVersion("1.0")]
    public abstract class BaseController : ControllerBase
    {
        #region Vars / Props
        protected internal const string BasePath = "api/luftborn";
        private IMediator _mediatorInstance;
        protected string LastUpdatedBy;
        protected IMediator Mediator
        {
            get
            {

                var mediator = _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
                InitiateOnMediatorRequest();
                return mediator;
            }
        }
        protected IMediator UnAuthorizedMediator
        {
            get
            {

                var mediator = _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
                return mediator;
            }
        }
        #endregion

        #region Constructor(s)
        public BaseController()
        {

        }

        #endregion

        #region Actions
        void InitiateOnMediatorRequest()
        {
            //Microsoft.Extensions.Primitives.StringValues token;
            //Request.Headers.TryGetValue("Authorization", out token);
            //LastUpdatedBy = JwtTokenHelper.ExtractUserIdFromToken(token);
        }
        #endregion
    }
}