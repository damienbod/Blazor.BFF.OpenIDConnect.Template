namespace BlazorBffOpenIDConnect.Server.Services;

public static class AntiForgeryExtensions
{
    public static TBuilder ValidateAntiforgery<TBuilder>(this TBuilder builder) 
        where TBuilder : IEndpointConventionBuilder
    {
        return builder.AddEndpointFilter(routeHandlerFilter: async (context, next) =>
        {
            try
            {
                var antiForgeryService = context.HttpContext.RequestServices.GetRequiredService<IAntiforgery>();
                await antiForgeryService.ValidateRequestAsync(context.HttpContext);
            }
            catch(AntiforgeryValidationException)
            {
                return Results.BadRequest("Antiforgery token validation failed.");
            }

            return await next(context);
        });
    }
}