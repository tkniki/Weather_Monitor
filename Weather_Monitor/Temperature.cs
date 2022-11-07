using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Monitor
{
    public static class Temperature
    {
        #region Kelvin to...
        public static double Calculate_KelvinToCelsius(double K)
        {
            return K - 273.15;
        }
        public static double Calculate_KelvinToFahrenheit(double K)
        {
            return K * 1.8 - 459.67;
        }
        #endregion

        #region Celsius to...
        public static double Calculate_CelsiusToKelvin(double C)
        {
            return C + 273.15;
        }

        public static double Calculate_CelsiusToFahrenheit(double C)
        {
            return C * 1.8 + 32;
        }
        #endregion

        #region Fahrenheit to...
        public static double Calculate_FahrenheitToKelvin(double F)
        {
            return (F + 459.67) / 1.8;
        }
        public static double Calculate_FahrenheitToCelsius(double F)
        {
            return (F - 32) * 5 / 9;
        }
        #endregion
    }
}
