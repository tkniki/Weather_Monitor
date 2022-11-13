using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Monitor
{
    public static class Temperature
    {
        public static double CelsiusToFahrenheit(double C)
        {
            return C * 1.8 + 32;
        }
        public static double FahrenheitToCelsius(double F)
        {
            return (F - 32) * 5 / 9;
        }

    }
}
