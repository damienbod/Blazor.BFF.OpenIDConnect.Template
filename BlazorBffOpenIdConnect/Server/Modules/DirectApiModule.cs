namespace BlazorBffOpenIDConnect.Server.Modules;

public class DirectApiModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/DirectApi");

        group.MapGet("/", Get)
             .RequireAuthorization()
             .ValidateAntiforgery();
    }

    public IEnumerable<string> Get() => new List<string> { "some data", "more data", "loads of data" };
}
