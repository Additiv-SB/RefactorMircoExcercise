namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check();
    }
}
