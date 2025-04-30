
namespace RailwayPhoneOfficeApp.Data.Utilities
{

    using RailwayPhoneOfficeApp.Data.Models;
    using RailwayPhoneOfficeApp.Data.Utilities.Interfaces;
    using static RailwayPhoneOfficeApp.Common.OutputMessages.ErrorMessages;

    using Microsoft.Extensions.Logging;
    using Microsoft.EntityFrameworkCore;

    using System.Text.Json;
    using Task = System.Threading.Tasks.Task;

    public class DataProcessor
    {
        private readonly IValidator entityValidator;
        private readonly ILogger<DataProcessor> logger;

        public DataProcessor(IValidator entityValidator, ILogger<DataProcessor> logger)
        {
            this.entityValidator = entityValidator;
            this.logger = logger;
        }
        public async Task ImportTelephoneExchangesFromJson(RailwayPhoneOfficeDbContext context)
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
