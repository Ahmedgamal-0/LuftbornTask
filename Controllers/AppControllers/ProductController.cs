using Luftborn.Application.Featuers.Product.Command.Models;
using Luftborn.Application.Featuers.Product.Queries.Models;
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
        public async Task<IActionResult> Register(RegisterProductCommand command)
        {
            var mediatorResponse = await Mediator.Send(command);
            return Ok(mediatorResponse);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var mediatorResponse = await Mediator.Send(command);
            return Ok(mediatorResponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mediatorResponse = await Mediator.Send(new DeleteProductCommand(id));
            return Ok(mediatorResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQuery command)
        {
            var mediatorResponse = await Mediator.Send(command);
            return Ok(mediatorResponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mediatorResponse = await Mediator.Send(new GetProductByIdQuery(id));
            return Ok(mediatorResponse);
        }
        #endregion
    }
}
