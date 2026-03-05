using System;
using System.Text.Json;
using CommonObjects;

namespace Electrical
{
    public sealed class ElectricalWire : Wire
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************


        //  ****************************************************************************************
        //  INITIALIZATIONS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALWIRE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricalWire()
        {
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        #region
        public Double Resistance { get; private set; }

        public Double CurrentRating { get; private set; }

        public Double VoltageRating { get; private set; }

        public override WireCategory Category => WireCategory.Electrical;

        public Double Conductance => Resistance <= 0 ? Double.PositiveInfinity : 1d / Resistance;
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Set Resistance
        public void SetResistance(Double value) => Resistance = EnsureNonNegative(value, nameof(value));
        //
        //  Set Current Rating
        public void SetCurrentRating(Double value) => CurrentRating = EnsureNonNegative(value, nameof(value));
        //
        //  Set Voltage Rating
        public void SetVoltageRating(Double value) => VoltageRating = EnsureNonNegative(value, nameof(value));
        //
        //  Calculate Voltage Drop
        public Double CalculateVoltageDrop(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return current * Resistance;
        }
        //
        //  Calculate Power Loss
        public Double CalculatePowerLoss(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return Math.Pow(current, 2) * Resistance;
        }
        //
        //  Supports Current
        public Boolean SupportsCurrent(Double current)
        {
            EnsureNonNegative(current, nameof(current));
            return CurrentRating <= 0 || current <= CurrentRating;
        }
        //
        //  Supports Voltage
        public Boolean SupportsVoltage(Double voltage)
        {
            EnsureNonNegative(voltage, nameof(voltage));
            return VoltageRating <= 0 || voltage <= VoltageRating;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static ElectricalWire? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricalWire>(json);
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  EVENTS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************
    }
}
