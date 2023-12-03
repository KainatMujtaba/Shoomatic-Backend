using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoematic.Data;

namespace Shoematic.API.Controller;

public class HealthController : BaseController
{
    [AllowAnonymous]
    [HttpGet("testdb")]
    public async Task<ActionResult<ExpandoObject>> Get([FromServices] ShoematicDbContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        dynamic heartbeatInfo = new ExpandoObject();

        heartbeatInfo.Result = "";
        heartbeatInfo.Took = "";
        heartbeatInfo.IsDbOk = false;

        try
        {
            heartbeatInfo.Result = $"Pong";
            heartbeatInfo.IsDbOk = await context.Database.CanConnectAsync();
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            heartbeatInfo.Took = ("Elapsed Time is " + stopwatch.ElapsedMilliseconds + " ms");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            heartbeatInfo.Took = ("Elapsed Time is " + stopwatch.ElapsedMilliseconds + " ms");
        }

        return heartbeatInfo;
    }
}
