using Microsoft.AspNetCore.Mvc;

namespace WebGames.API.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult CustomResponse(bool success, object? response = null)
        {
            if (!success)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Failed to process the request."
                });
            }

            if(response != null)
                return Ok(new
                {
                    success = true,
                    message = "Success to process the request.",
                    data = response
                });

            return Ok(new
            {
                success = true,
                message = "Success to process the request."
            });
        }

        protected ActionResult PostResponse(bool success, object? response = null)
        {
            if (!success)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Failed to process the request."
                });
            }

            if (response != null)
                return Created(string.Empty, new
                {
                    success = true,
                    message = "Success to process the request.",
                    data = response
                });

            return Created(string.Empty, new
            {
                success = true,
                message = "Success to process the request.",
            });
        }
    }
}
