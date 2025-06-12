using Core.Models.GlobalModels;
using Core.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class BaseController : ControllerBase
    {

        protected async Task<BaseResonse<T>> HandleRequestAsync<T>(Task<BaseResonseModel<T>> action)
        {
            try
            {
                BaseResonseModel<T> response = await action;

                HttpContext.Response.StatusCode = response.Succeed == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError;
                return new BaseResonse<T>
                {
                    Succeed = response.Succeed,
                    Message = response.Message,
                    Data = response.Data,
                    TraceId = "213",
                    ErrorInfo = response.ErrorInfo,
                };
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new BaseResonse<T>
                {
                    Succeed = false,
                    Message = "Server error!!",
                    TraceId = "213",
                };
            }
        }

    }
}
