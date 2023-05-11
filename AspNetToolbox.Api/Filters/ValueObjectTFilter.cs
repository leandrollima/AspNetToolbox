using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto;

namespace AspNetToolbox.Api.Filters
{
    public class ValueObjectTFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result != null)
            {
                if (result.StatusCode == 200 || result.StatusCode == 201)
                {
                    result.Value = VO(result.Value);
                }
                else if (result.StatusCode == 400)
                {
                    if (result.Value.GetType() == typeof(ValidationProblemDetails))
                    {
                        var obj = result.Value as ValidationProblemDetails;
                        var res = string.Join("; ", obj.Errors.SelectMany(el => el.Value.Select(el => el)));
                        result.Value = VOError(res);
                    }
                    else
                    {
                        result.Value = VOError(result.Value?.ToString());
                    }
                }
            }

            await next();
        }
        private ValueObject<object> VO(object data)
        {
            if (data.GetType() != typeof(string))
            {
                return new ValueObject<object>
                {
                    Data = data,
                    Success = true,
                    Message = ""
                };
            }
            else
            {
                return new ValueObject<object>
                {
                    Data = null,
                    Success = true,
                    Message = data.ToString()
                };
            }
        }

        private ValueObject<object> VOError(object data)
        {
            if (data.GetType() != typeof(string))
            {
                return new ValueObject<object>
                {
                    Data = data,
                    Success = false,
                    Message = ""
                };
            }
            else
            {
                return new ValueObject<object>
                {
                    Data = null,
                    Success = false,
                    Message = data.ToString()
                };
            }
        }

    }
}
