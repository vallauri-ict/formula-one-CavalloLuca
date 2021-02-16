namespace FormulaOneDLL
{
    public class Country
    {
        public Country(string isoCode, string descr)
        {
            IsoCode = isoCode;
            Descr = descr;
        }

        public string IsoCode { get; set; }
        public string Descr { get; set; }
    }
}
