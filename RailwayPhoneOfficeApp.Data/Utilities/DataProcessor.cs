
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RailwayPhoneOfficeApp.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace RailwayPhoneOfficeApp.Data.Utilities
{
    public static class DataProcessor
    {
        public static async Task ImportTelephoneExchangesFromJson(RailwayPhoneOfficeDbContext context)
        {
            string path = Path.Combine(AppContext.BaseDirectory,"Files", "exchanges.json");

            string exchangesStr = await File.ReadAllTextAsync(path);

            var exchanges = JsonSerializer.Deserialize<List<TelephoneExchange>>(exchangesStr);

            if (exchanges != null && exchanges.Count > 0)
            {
                List<Guid> exchangesIds = exchanges.Select(e => e.Id).ToList();

                if (await context.TelephoneExchanges.AnyAsync(e => exchangesIds.Contains(e.Id)) == false)
                {
                    await context.TelephoneExchanges.AddRangeAsync(exchanges);
                    await context.SaveChangesAsync();
                }
            }
            

        }

    }
}
