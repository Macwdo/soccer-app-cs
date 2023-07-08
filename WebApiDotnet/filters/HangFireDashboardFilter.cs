using Hangfire.Dashboard;

namespace WebApiDotnet.filters;

public class HangfireDashboardFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        // Allow all authenticated users to see the Dashboard (potentially dangerous).
        return true;
    }
}