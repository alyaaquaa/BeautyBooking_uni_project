using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.WebAPI.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Wystąpił nieoczekiwany błąd.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Wystąpił błąd systemu.");
            }
        }
    }
}
