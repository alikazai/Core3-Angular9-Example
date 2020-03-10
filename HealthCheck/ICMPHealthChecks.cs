using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck
{
  public class ICMPHealthChecks : IHealthCheck
  {
    private string Host { get; set; }
    private int Timeout { get; set; }

    public ICMPHealthChecks(string host, int timeout)
    {
      Host = host;
      Timeout = timeout;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
      try
      {
        using (var ping = new Ping())
        {
          var reply = await ping.SendPingAsync(Host);

          switch (reply.Status)
          {
            case IPStatus.Success:
              var msg = $"ICMP to {Host} took {reply.RoundtripTime} ms.";
              return (reply.RoundtripTime > Timeout) ? HealthCheckResult.Degraded(msg) : HealthCheckResult.Healthy(msg);
            default:
              var defaultMsg = $"ICMP to {Host} failed: {reply.Status}";
              return HealthCheckResult.Unhealthy(defaultMsg);
          }
        }
      }
      catch (Exception e)
      {
        var err = $"ICMP to {Host} failed: {e.Message}";
        return HealthCheckResult.Unhealthy(err);
      }
    }
  }
}