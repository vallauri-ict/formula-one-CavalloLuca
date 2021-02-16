using System;
using System.Windows;
using System.Drawing;

namespace FormulaOneDLL
{
    public class Driver
    {
        public Driver(int id, int number,string name, DateTime dob, byte[] heltImage, byte[] image, int teamId, int podius)
        {
            Id = id;
            Number = number;
            Name = name;
            Dob = dob;
            HeltImage = heltImage;
            Image = image;
            TeamId = teamId;
            Podius = podius;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public byte[] HeltImage { get; set; }
        public byte[] Image { get; set; }
        public int TeamId { get; set; }
        public int Podius { get; set; }
    }
}
