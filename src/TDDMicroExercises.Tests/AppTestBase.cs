using Microsoft.Extensions.DependencyInjection;
using TDDMicroExercises.Infrastructure;

namespace TDDMicroExercises.Tests
{
    public abstract class AppTestBase
    {
        protected readonly IServiceCollection ServiceCollection;

        protected AppTestBase()
        {
            //Register common internal dependencies
            ServiceCollection = new ServiceCollection()
                .AddAppDependencies();
        }
    }
}
