using System;
using System.Windows;
using System.Drawing;

namespace FormulaOneDLL
{
    public class TeamDtO
    {
        public TeamDtO(string name, byte[] teamLogo, string[] drivers, byte[] carImage)
        {
            Name = name;
            TeamLogo = teamLogo;
            Drivers = drivers;
            CarImage = carImage;
        }

        public string Name { get; set; }
        public byte[] TeamLogo { get; set; }
        public string[] Drivers { get; set; }
        public byte[] CarImage { get; set; }
    }
}
