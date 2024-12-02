using Reveal.Sdk;

namespace RevealSdk.Server.Reveal
{
    public class UserContextProvider : IRVUserContextProvider
    {
        IRVUserContext IRVUserContextProvider.GetUserContext(HttpContext aspnetContext)
        {
            var userId = aspnetContext.Request.Headers["x-header-one"];
            var orderId = aspnetContext.Request.Headers["x-header-two"];
            var employeeId = aspnetContext.Request.Headers["x-header-three"];

            string role = "User";
            if (userId == "AROUT" || userId == "BLONP")
            {
                role = "Admin";
            }

            var props = new Dictionary<string, object>() {
                    { "OrderId", orderId },
                    { "EmployeeId", employeeId },
                    { "Role", role } };

            Console.WriteLine("UserContextProvider: " + userId + " " + orderId + " " + employeeId);

            return new RVUserContext(userId, props);
        }
    }
}
