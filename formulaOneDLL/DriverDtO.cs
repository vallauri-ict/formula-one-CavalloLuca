using System;
using System.Windows;
using System.Drawing;

namespace FormulaOneDLL
{
    public class DriverDtO
    {
        public DriverDtO(int number, string name, byte[] image, string teamName, string countryCode)
        {
            Number = number;
            Name = name;
            Image = image;
            TeamName = teamName;
            CountryCode = countryCode;
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string TeamName { get; set; }
        public string CountryCode { get; set; }
    }
}
