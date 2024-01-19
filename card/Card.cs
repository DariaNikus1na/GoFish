using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.card
{
    internal class Card
    {
        private readonly Suit suit;
        private readonly Value value;

        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        //internal Suit GetSuit()
        //{
        //    return suit;
        //}

        internal char GetSuitSymb()
        {
            return Convert.ToChar(suit);
        }
        internal string GetValueSymb()
        {
            if (value == Value.Tens)
                return "10";
            else return Convert.ToString(Convert.ToChar(value));
        }

        internal Value GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return suit + " " + value;
        }
    }
}
