using System;
using CommonObjects;

namespace Electrical
{
    public sealed class ElectricalWire : Wire
    {
        public Double Resistance { get; private set; }

        public Double CurrentRating { get; private set; }

        public Double VoltageRating { get; private set; }

        public override WireCategory Category => WireCategory.Electrical;

        public void SetResistance(Double value) => Resistance = EnsureNonNegative(value, nameof(value));

        public void SetCurrentRating(Double value) => CurrentRating = EnsureNonNegative(value, nameof(value));

        public void SetVoltageRating(Double value) => VoltageRating = EnsureNonNegative(value, nameof(value));

        public Double CalculateVoltageDrop(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return current * Resistance;
        }

        public Double CalculatePowerLoss(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return Math.Pow(current, 2) * Resistance;
        }

        public Boolean SupportsCurrent(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return CurrentRating <= 0 || current <= CurrentRating;
        }

        public Boolean SupportsVoltage(Double voltage)
        {
            EnsureNonNegative(voltage, nameof(voltage));
            return VoltageRating <= 0 || voltage <= VoltageRating;
        }

        public Double Conductance => Resistance <= 0 ? Double.PositiveInfinity : 1d / Resistance;
    }
}
