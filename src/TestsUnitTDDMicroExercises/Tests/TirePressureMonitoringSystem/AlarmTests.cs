using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using FsCheck;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TestsUnitTDDMicroExercises.Common.Fixtures;
using TestsUnitTDDMicroExercises.Common.Generators;

namespace TestsUnitTDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    [TestFixture]
    [Parallelizable]
    internal sealed class AlarmTests
    {
        private readonly IFixture _fixture;
        private readonly double _lowPressureThreshold;
        private readonly double _highPressureThreshold;

        public AlarmTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            (_lowPressureThreshold, _highPressureThreshold) = GeneratePressureThresholds();
        }

        private static (double lowPressureThreshold, double highPressureThreshold) GeneratePressureThresholds()
        {
            double lowPressureThreshold = new System.Random().NextDouble();
            double highPressureThreshold = lowPressureThreshold * 2;

            return (lowPressureThreshold, highPressureThreshold);
        }

        [Test]
        public void WhenPressureValueIsWithinAlarmTriggeringPressureRangeAlarmIsEnabled() =>
            Prop.ForAll(
                PressureGenerator.OutsideOfRange(_lowPressureThreshold, _highPressureThreshold),
                pressureValue =>
                {
                    Alarm alarm = PressureAlarmFixture.WithPressureBoundary(
                        _lowPressureThreshold,
                        _highPressureThreshold,
                        PressureSensorFixture.WithFixedPressureValue(pressureValue));

                    alarm.Check();

                    return alarm.AlarmOn;
                }).QuickCheckThrowOnFailure();

        [Test]
        public void WhenPressureValueIsOutsideOfAlarmTriggeringPressureRangeAlarmIsNotEnabled() =>
            Prop.ForAll(
                PressureGenerator.WithinRange(_lowPressureThreshold, _highPressureThreshold),
                pressureValue =>
                {
                    Alarm alarm = PressureAlarmFixture.WithPressureBoundary(
                        _lowPressureThreshold,
                        _highPressureThreshold,
                        PressureSensorFixture.WithFixedPressureValue(pressureValue));

                    alarm.Check();

                    return !alarm.AlarmOn;
                }).QuickCheckThrowOnFailure();

        [TestCase(17, 21, 17)]
        [TestCase(17, 21, 21)]
        public void WhenPressureValueIsOnLowerOrUpperAlarmTriggeringPressureValueAlarmIsNotEnabled(
            double lowPressureThreshold,
            double highPressureThreshold,
            double edgePressureValue)
        {
            Alarm alarm = PressureAlarmFixture.WithPressureBoundary(
                lowPressureThreshold,
                highPressureThreshold,
                PressureSensorFixture.WithFixedPressureValue(edgePressureValue));

            alarm.Check();

            alarm.AlarmOn.Should().BeFalse();
        }

        [Test]
        public void AlarmIsNotEnabledByDefault() =>
            _fixture.Create<Alarm>().AlarmOn.Should().BeFalse();
    }
}