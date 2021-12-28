namespace TDDMicroExercises.TirePressureMonitoringSystem.Interfaces
{
    public interface IAlarm
    {
        void Check();
        bool AlarmOn { get; }
    }
}
