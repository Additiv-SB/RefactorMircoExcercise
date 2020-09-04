using System;
using TDDMicroExercises.Infrastructure;

namespace TDDMicroExercises.Base
{
    /// <summary>
    /// Purpose of the class to provide ServiceProvider to all the logic(service) classes, to be able to retrieve dependencies without injecting it via ctor
    /// When external dependencies will stop using default ctor, class can be removed
    /// Or class may be used to store other common dependencies, like audit/loggin services or etc.
    /// </summary>
    public abstract class LogicBase
    {
        /// <summary>
        /// Service Provider
        /// Currently Test project will be able to access internals
        /// Ideally dependencies should be injected via constructor
        /// </summary>
        internal IServiceProvider ServiceProvider => AppServiceProvider.ServiceProvider;
    }
}
