using System;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;

namespace FormulaOneDLL
{
    public class TeamDtO
    {
        public TeamDtO(string tName, byte[] tLogo, string[] dNames, List<byte[]> dImages, byte[] tImage)
        {
            this.TeamName = tName;
            this.TeamLogo = tLogo;
            this.driversName = dNames;
            this.driversImage = dImages;
            this.carImage = tImage;
        }

        public string TeamName { get; set; }
        public byte[] TeamLogo { get; set; }
        public string[] driversName { get; set; }
        public List<byte[]> driversImage { get; set; }
        public byte[] carImage { get; set; }
    }
}




