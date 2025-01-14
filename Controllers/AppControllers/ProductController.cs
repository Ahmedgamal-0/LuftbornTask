﻿using Luftborn.Application.Featuers.Product.Command.Models;
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
            try
            {
                var mediatorResponse = await Mediator.Send(command);
                return Ok(mediatorResponse);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(command);
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new DeleteProductCommand(id));
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQuery command)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(command);
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new GetProductByIdQuery(id));
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        #endregion
    }
}
