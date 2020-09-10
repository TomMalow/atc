﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Endpoints
{
    /// <summary>
    /// Endpoint definitions.
    /// Area: Orders.
    /// </summary>
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Description: Get orders.
        /// Operation: GetOrders.
        /// Area: Orders.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Pagination<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public Task<ActionResult> GetOrdersAsync(GetOrdersParameters parameters, [FromServices] IGetOrdersHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return GetOrdersHelperAsync(parameters, handler, cancellationToken);
        }

        /// <summary>
        /// Description: Get order by id.
        /// Operation: GetOrderById.
        /// Area: Orders.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public Task<ActionResult> GetOrderByIdAsync(GetOrderByIdParameters parameters, [FromServices] IGetOrderByIdHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return GetOrderByIdHelperAsync(parameters, handler, cancellationToken);
        }

        /// <summary>
        /// Description: Update part of order by id.
        /// Operation: PatchOrdersId.
        /// Area: Orders.
        /// </summary>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status502BadGateway)]
        public Task<ActionResult> PatchOrdersIdAsync(PatchOrdersIdParameters parameters, [FromServices] IPatchOrdersIdHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return PatchOrdersIdHelperAsync(parameters, handler, cancellationToken);
        }

        private static async Task<ActionResult> GetOrdersHelperAsync(GetOrdersParameters parameters, IGetOrdersHandler handler, CancellationToken cancellationToken)
        {
            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        private static async Task<ActionResult> GetOrderByIdHelperAsync(GetOrderByIdParameters parameters, IGetOrderByIdHandler handler, CancellationToken cancellationToken)
        {
            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        private static async Task<ActionResult> PatchOrdersIdHelperAsync(PatchOrdersIdParameters parameters, IPatchOrdersIdHandler handler, CancellationToken cancellationToken)
        {
            return await handler.ExecuteAsync(parameters, cancellationToken);
        }
    }
}