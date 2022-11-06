using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Monitor.Models
{
    [ComplexType]
    public class Temperature
    {
        public double Kelvin { get; set; }
        public double Celsius { get; set; }
        public double Fahrenheit { get; set; }

        public void CalculateDefaultKelvin(double K)
        {
            this.Kelvin = K;
            Celsius = K - 273.15;
            Fahrenheit = K * 1.8 - 459.67;
        }
        public void CalculateDefaultCelsius(double C)
        {
            this.Celsius = C;
            Kelvin = C + 273.15;
            Fahrenheit = Kelvin * 1.8 - 459.67;
        }
        public void CalculateDefaultFahrenheit(double F)
        {
            this.Fahrenheit = F;
            Kelvin = (F + 459.67) / 1.8;
            Celsius = Kelvin - 273.15;
        }
    }
}
