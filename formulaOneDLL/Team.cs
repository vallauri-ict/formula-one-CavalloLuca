using System;
using System.Drawing;

namespace FormulaOneDLL
{
    public class Team
    {
        public Team(int id, string teamName, byte[] teamLogo, 
            string _base, string teamChief, string technicalChief, string powerUnit, 
            byte[] carImage, string countryId, int worldChampionships, int polePositions)
        {
            Id = id;
            TeamName = teamName;
            TeamLogo = teamLogo;
            Base = _base;
            TeamChief = teamChief;
            TechnicalChief = technicalChief;
            PowerUnit = powerUnit;
            CarImage = carImage;
            CountryID = countryId;
            WorldChampionships = worldChampionships;
            PolePositions = polePositions;
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public byte[] TeamLogo { get; set; }
        public string Base { get; set; }
        public string TeamChief { get; set; }
        public string TechnicalChief { get; set; }
        public string PowerUnit { get; set; }
        public byte[] CarImage { get; set; }
        public string CountryID { get; set; }
        public int WorldChampionships { get; set; }
        public int PolePositions { get; set; }
    }
}


