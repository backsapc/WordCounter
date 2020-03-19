#nullable enable
using System.Threading.Tasks;
using Autofac;
using WordCounter.Application;

namespace WordCounter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            await using var scope = container.BeginLifetimeScope();
            var app = scope.Resolve<IApp>();

            await app.RunAsync();
        }
    }
}