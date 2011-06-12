using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E1evens
{
    public class Card
    {
        public int Value { get; private set; }
        public Suit Suit { get; private set; }

        public Card(int value, Suit suit)
        {
            if (value >= 14 || value < 1)
            {
                throw new ArgumentException("Wrong value");
            }

            this.Value = value;
            this.Suit = suit;
        }

        public bool IsFaceCard
        {
            get { return Value > 10; }
        }

        public override string ToString()
        {
            string card;
            switch (Value)
            {
                case 1:
                    card = "A";
                    break;
                case 11:
                    card = "J";
                    break;
                case 12:
                    card = "Q";
                    break;
                case 13:
                    card = "K";
                    break;
                default:
                    card = Value.ToString();
                    break;
            }

            return card + Suit.ToString()[0];
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;

            if (other == null)
            {
                return false;
            }

            return (other.Suit == this.Suit && other.Value == this.Value);
        }

        public override int GetHashCode()
        {
            return ((int)Suit) + 31 * Value;
        }
    }
}
