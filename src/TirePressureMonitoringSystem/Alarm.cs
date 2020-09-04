using System;
using Microsoft.Extensions.DependencyInjection;
using TDDMicroExercises.Base;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    //Ensure all external dependencies uses interface instead of instantiating class via constructor

    public class Alarm : LogicBase, IAlarm
    {
        //Dependencies
        private readonly ISensor _sensor;

        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        [Obsolete("Use DI to inject TDDMicroExercises.TirePressureMonitoringSystem.IAlarm")]
        public Alarm()
        {
            //While exposing default parameterless constructor is required
            //injecting dependencies via ServiceProvider (gives an ability to easily mock class dependencies)
            _sensor = ServiceProvider.GetService<ISensor>();
        }

        public void Check()
        {
            if (_sensor == null)
            {
                throw new ArgumentNullException(nameof(_sensor), "Ensure default ctor being called");
            }

            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
