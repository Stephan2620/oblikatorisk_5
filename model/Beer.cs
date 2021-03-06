using System;

namespace Beer
{
    public class Beer
    {
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4) { throw new ArgumentException("Navnet skal minimum være 4 bokstaver"); }
                _name = value;
            }
        }

        private int _price;

        public int Price
        {
            get => _price;
            set
            {
                if (value < 1) { throw new ArgumentException("prisen skal være over 0kr"); }
                _price = value;
            }
        }
        private int _abv;
        public int Abv
        {
            get => _abv;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("da det er en % skal den være mellem 0 og 100"); }
                _abv = value;
            }
        }

        public Beer(int Id, string Name, int Price, int Abv)
        {
            _id = Id;
            _name = Name;
            _price = Price;
            _abv = Abv;
        }



    }
}


