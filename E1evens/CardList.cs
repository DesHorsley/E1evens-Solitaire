using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E1evens
{
    public class CardList : List<Card>
    {
        public static CardList CreateStandardDeck()
        {
            CardList cardList = new CardList();

            for (int value = 1; value < 14; value++)
            {
                cardList.Add(new Card(value, Suit.Clubs));
                cardList.Add(new Card(value, Suit.Diamonds));
                cardList.Add(new Card(value, Suit.Hearts));
                cardList.Add(new Card(value, Suit.Spades));
            }

            return cardList;
        }

        public CardList() { }

        /// <summary>
        /// Returns the top card, and removes it from this card list.
        /// </summary>
        /// <returns>Card</returns>
        public Card Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CardList is empty.");
            }

            int lastIndex = Count - 1;
            Card lastCard = this[lastIndex];
            RemoveAt(lastIndex);
            return lastCard;
        }

        public Card Top
        {
            get 
            {
                if (Count > 0)
                {
                    return this[Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }


        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = Count; i > 1; i--)
            {
                int pos = rnd.Next(i);
                var x = this[i - 1];
                this[i - 1] = this[pos];
                this[pos] = x;
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (Card c in this)
            {
                s.Append(c.ToString());
                s.Append(" ");
            }
            return s.ToString().TrimEnd();
        }
    }
}
