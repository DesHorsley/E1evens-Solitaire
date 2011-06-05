using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E1evens
{
    public class Deck
    {
        private List<Card> deckOfCards;

        public Deck()
        {
            deckOfCards = new List<Card>();
            for (int value = 1; value < 14; value++)
            {
                deckOfCards.Add(new Card(Suit.Clubs, value));
                deckOfCards.Add(new Card(Suit.Diamonds, value));
                deckOfCards.Add(new Card(Suit.Hearts, value));
                deckOfCards.Add(new Card(Suit.Spades, value));
            }
        }

        public IList<Card> Cards
        {
            get { return deckOfCards.AsReadOnly(); }
        }

        public Card GetNextCard()
        {
            int lastIndex = deckOfCards.Count - 1;
            Card lastCard = deckOfCards[lastIndex];
            deckOfCards.RemoveAt(lastIndex);
            return lastCard;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = deckOfCards.Count; i > 1; i--)
            {
                int pos = rnd.Next(i);
                var x = deckOfCards[i - 1];
                deckOfCards[i - 1] = deckOfCards[pos];
                deckOfCards[pos] = x;
            }

        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (Card c in deckOfCards)
            {
                s.Append(c.ToString());
                s.Append(" ");
            }
            return s.ToString().TrimEnd();
        }
    }
}
