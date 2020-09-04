using System;
using Microsoft.Extensions.DependencyInjection;

namespace TDDMicroExercises.Infrastructure
{
    public static class AppServiceProvider
    {
        /// <summary>
        /// Registering dependencies and building ServiceProvider to ensure external assemblies won't brake
        /// In other cases app pipelines could be responsible for that
        /// </summary>
        public static readonly IServiceProvider ServiceProvider = Run();

        private static IServiceProvider Run()
        {
            //Register dependencies and init static ServiceProvider
            return new ServiceCollection()
                .AddAppDependencies()
                .BuildServiceProvider();


        }
    }
}
