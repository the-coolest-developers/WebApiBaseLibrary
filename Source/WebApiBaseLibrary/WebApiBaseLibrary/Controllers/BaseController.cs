﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBaseLibrary.Enums;
using WebApiBaseLibrary.Responses;

namespace WebApiBaseLibrary.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Task<ActionResult<TResult>> ExecuteActionAsync<TResult>(IResponse<TResult> response)
        {
            return ExecuteActionAsync(Task.FromResult(response));
        }

        protected async Task<ActionResult<TResult>> ExecuteActionAsync<TResult>(Task<IResponse<TResult>> responseTask)
        {
            var response = await responseTask;

            var result = response.Result;
            ActionResult<TResult> actionResult = response.Status switch
            {
                ResponseStatus.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, result),
                ResponseStatus.Success => Ok(result),
                ResponseStatus.BadRequest => BadRequest(result),
                ResponseStatus.Conflict => Conflict(result),
                ResponseStatus.NoContent => StatusCode(StatusCodes.Status204NoContent, result),
                ResponseStatus.NotFound => NotFound(result),
                ResponseStatus.Unauthorized => Unauthorized(result),
                ResponseStatus.Accepted => Accepted(result),
                ResponseStatus.PartialContent => StatusCode(StatusCodes.Status206PartialContent, result),
                ResponseStatus.Forbidden => StatusCode(StatusCodes.Status403Forbidden, result),
                ResponseStatus.Created => StatusCode(StatusCodes.Status201Created, result),
                ResponseStatus.TooManyRequests => StatusCode(StatusCodes.Status429TooManyRequests),
                _ => throw new ArgumentOutOfRangeException(
                    $"{response.Status}",
                    "Should be a valid HTTP Status Code")
            };

            return actionResult;
        }
    }
}