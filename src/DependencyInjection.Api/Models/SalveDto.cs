using System.Collections.Generic;

namespace DependencyInjection.Api.Models
{
    public record SalveDto(string SalveMessage, IList<string> RequestTrackerList);
}