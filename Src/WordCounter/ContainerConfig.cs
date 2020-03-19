using Autofac;
using WordCounter.Application;
using WordCounter.Infrastructure;
using WordCounter.Infrastructure.Settings.Processing;
using WordCounter.Infrastructure.Settings.Provider;
using WordCounter.Infrastructure.Settings.Saver;

namespace WordCounter
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<App>().As<IApp>();
            builder.RegisterType<ConsoleProviderSettingsProvider>().As<IProviderSettingsProvider>();
            builder.RegisterType<ConsoleSaverSettingsProvider>().As<ISaverSettingsProvider>();
            builder.RegisterType<ConsoleProcessingSettingsProvider>().As<IProcessingSettingsProvider>();

            return builder.Build();
        }
    }
}