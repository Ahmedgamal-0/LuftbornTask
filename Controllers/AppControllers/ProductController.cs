using Luftborn.Application.Featuers.Product.Command.Models;
using LuftbornTask.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace LuftbornTask.Controllers.AppControllers
{
    public class ProductController:BaseController
    {
        #region Vars / Props
        #endregion

        #region Constructor(s)
        public ProductController()
        {
        }
        #endregion

        #region Actions

        [HttpPost]
        //[Authorize(Policy = Permissions.BookingEngine.Product.Write)]
        public async Task<IActionResult> Register(RegisterProductCommand command)
        {
            var mediatorResponse = await Mediator.Send(command);
            //if (mediatorResponse.Succeeded)
            //{
            //    await _logActivityService.InsertAsync(LastUpdatedBy, LoggingConstants.BookingEngine.ADD_NEW_Product, mediatorResponse.EntityId, "used command", "Booking Number Select Step", "", "Booking Engine", command);
            //}

            return Ok(mediatorResponse);
        }
        #endregion
    }
}
