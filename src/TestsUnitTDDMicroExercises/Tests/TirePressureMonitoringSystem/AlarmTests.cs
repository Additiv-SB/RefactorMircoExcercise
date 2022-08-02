using System;
using System.Linq;
using System.Reflection;
using AutoFixture.NUnit3;
using FluentAssertions;
using FsCheck;
using Microsoft.FSharp.Collections;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TestsUnitTDDMicroExercises.Common.Fixtures;
using TestsUnitTDDMicroExercises.Common.Generators;
using Random = System.Random;

namespace TestsUnitTDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    [TestFixture]
    internal sealed class PressureAlarmTests : AlarmTests { }

    [TestFixture]
    internal abstract class AlarmTests
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        [Test]
        [AutoData]
        public void WhenPressureValueIsWithinAlarmTriggeringPressureRangeAlarmIsEnabled() =>
            Prop.ForAll(
                PressureGenerator.OutsideOfRange(LowPressureThreshold, HighPressureThreshold),
                pressureValue =>
                {
                    // TODO: Provide pressure value to pressure alarm via mocked pressure sensor.
                    Alarm alarm = PressureAlarmFixture.WithPressureBoundary(LowPressureThreshold, HighPressureThreshold);

                    alarm.Check();

                    return alarm.AlarmOn;
                });

        [Test]
        public void WhenPressureValueIsOutsideOfAlarmTriggeringPressureRangeAlarmIsNotEnabled() =>
            Prop.ForAll(
                PressureGenerator.WithinRange(LowPressureThreshold, HighPressureThreshold),
                pressureValue =>
                {
                    // TODO: Provide pressure value to pressure alarm via mocked pressure sensor.
                    Alarm alarm = PressureAlarmFixture.WithPressureBoundary(LowPressureThreshold, HighPressureThreshold);

                    alarm.Check();

                    return !alarm.AlarmOn;
                });

        [TestCase(LowPressureThreshold)]
        [TestCase(HighPressureThreshold)]
        public void WhenPressureValueIsOnLowerOrUpperAlarmTriggeringPressureValueAlarmIsNotEnabled(double edgePressureValue)
        {
            Alarm alarm = PressureAlarmFixture.WithPressureBoundary(LowPressureThreshold, HighPressureThreshold);

            alarm.Check();

            alarm.AlarmOn.Should().BeFalse();
        }

        [Test]
        [AutoData]
        public void AlarmIsNotEnabledByDefault(Alarm alarm) => alarm.AlarmOn.Should().BeFalse();
    }
}