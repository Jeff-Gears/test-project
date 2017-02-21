using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno1
{
    class Card
    {
        private int value;
        private string suit;
        private string displayValue;
        private List<string> suitList = new List<string> { "clubs", "spades", "diamonds", "hearts" };
        public Card(int Value, string Suit)
        {
            if (Value > 1 && Value <= 14)
            {
                value = Value;
                displayValue = value.ToString();
                if (value == 11)
                {
                    displayValue = "J";
                }
                else if (value == 12)
                {
                    displayValue = "Q";
                }
                else if (value == 13)
                {
                    displayValue = "K";
                }
                else if (value == 14)
                {
                    displayValue = "A";
                }
            }
            else
            {
                value = 0;
            }

            if (suitList.Contains(Suit.ToLower()))
            {
                suit = Suit.ToLower();
            }
            else
            {
                suit = null;
            }
        }

        public int GetValue()
        {
            return value;
        }
        public string GetDisplayValue()
        {
            return displayValue;
        }
        public string GetSuit()
        {
            return suit;
        }
        public string GetCardName()
        {
            return displayValue+suit;
        }
    }
}
