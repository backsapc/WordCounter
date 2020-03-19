using System.Collections.Generic;
using System.Linq;

namespace WordCounter.Infrastructure.Settings
{
    public abstract class SettingsProviderBase
    {
        protected T MatchOptions<T>(string question, IReadOnlyCollection<Option<T>> options)
        {
            System.Console.WriteLine(question);
            foreach (var option in options)
            {
                System.Console.WriteLine($"{option.Index}. {option.Title}");
            }

            while (true)
            {
                var inputOption = System.Console.ReadLine();
                if (!int.TryParse(inputOption, out var inputOptionInt))
                {
                    System.Console.WriteLine("Invalid input value. Try again.");
                    continue;
                }

                if (!options.Select(x => x.Index).Contains(inputOptionInt))
                {
                    System.Console.WriteLine("Invalid input value. Try again.");
                    continue;
                }

                return options.First(x => x.Index == inputOptionInt)
                              .Value;
            }
        }
    }
}