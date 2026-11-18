using DiGi.EPW.Classes;
using System;

namespace DiGi.EPW
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the measured dry bulb temperature, in °C, of the given hourly data record (DiGi-Organization/DiGi.Weather#4).
        /// <para>Returns null when the raw <see cref="DiGi.Weather.Classes.WeatherRecord.DryBulbTemperature"/> equals the EPW missing-value marker <see cref="Constants.MissingValue.DryBulbTemperature"/> (99.9) or is NaN, so a missing reading is distinguishable from a measurement without comparing against a magic number.</para>
        /// </summary>
        /// <param name="dataRecord">The hourly data record to query.</param>
        /// <returns>The measured dry bulb temperature, in °C, or null when the reading is missing.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided data record is null.</exception>
        public static float? DryBulbTemperatureValue(this DataRecord dataRecord)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            float dryBulbTemperature = dataRecord.DryBulbTemperature;
            return dryBulbTemperature == Constants.MissingValue.DryBulbTemperature || float.IsNaN(dryBulbTemperature) ? null : dryBulbTemperature;
        }
    }
}
