﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Atc.Rest.Results;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.181.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Results for operation request.
    /// Description: Update user by id.
    /// Operation: UpdateUserById.
    /// Area: Users.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.181.0")]
    public class UpdateUserByIdResult : ResultBase
    {
        private UpdateUserByIdResult(ActionResult result) : base(result) { }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static UpdateUserByIdResult Ok(string? message = null) => new UpdateUserByIdResult(ResultFactory.CreateContentResult(HttpStatusCode.OK, message));

        /// <summary>
        /// 400 - BadRequest response.
        /// </summary>
        public static UpdateUserByIdResult BadRequest(string message) => new UpdateUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.BadRequest, message));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static UpdateUserByIdResult NotFound(string? message = null) => new UpdateUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// 409 - Conflict response.
        /// </summary>
        public static UpdateUserByIdResult Conflict(string? error = null) => new UpdateUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.Conflict, error));

        /// <summary>
        /// Performs an implicit conversion from UpdateUserByIdResult to ActionResult.
        /// </summary>
        public static implicit operator UpdateUserByIdResult(string x) => Ok(x);
    }
}