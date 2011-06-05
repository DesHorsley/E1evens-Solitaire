using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E1evens
{
    public class Table
    {
        private Deck deck;
        private List<Card>[] positions;

        public Table()
        {
            NewGame();
        }

        public void NewGame() 
        {
            deck = new Deck();
            deck.Shuffle();
            positions = new List<Card>[9];

            for (int i = 0; i < 9; i++)
            {
                positions[i] = new List<Card>();
            }
        }

        public void PlaceCard(int firstPos)
        {
            if (firstPos < 0 || firstPos > 8)
            {
                throw new ArgumentOutOfRangeException("Position out of range.");
            }

            if (HasWon)
            {
                throw new InvalidOperationException("Game is over");
            }

            if (positions[firstPos].Count != 0)
            {
                throw new InvalidOperationException("Invalid Move");
            }

            positions[firstPos].Add(deck.GetNextCard());

        }

        public void PlaceCard(int firstPos, int secondPos)
        {
            if (firstPos < 0 || firstPos > 8 ||
                secondPos < 0 || secondPos > 8)
            {
                throw new ArgumentOutOfRangeException("Position out of range.");
            }

            if (HasWon)
            {
                throw new InvalidOperationException("Game is over");
            }

            // Can't place 2 cards if one or both is blank
            if (positions[firstPos].Count == 0 || positions[secondPos].Count == 0)
            {
                throw new InvalidOperationException("Invalid Move");
            }

            if (positions[firstPos].Last().IsFaceCard || positions[secondPos].Last().IsFaceCard) 
            {
                throw new InvalidOperationException("Invalid Move");
            }

            // Check the 2 card placement is a valid move
            if (positions[firstPos].Last().Value + positions[secondPos].Last().Value != 11)
            {
                throw new InvalidOperationException("Invalid Move");
            }

            positions[firstPos].Add(deck.GetNextCard());
            positions[secondPos].Add(deck.GetNextCard());
        }

        public void PlaceCard(int firstPos, int secondPos, int thirdPos)
        {
            if (firstPos < 0 ||  firstPos > 8 ||
               secondPos < 0 || secondPos > 8 || 
                thirdPos < 0 ||  thirdPos > 8)
            {
                throw new ArgumentOutOfRangeException("Position out of range.");
            }

            if (HasWon)
            {
                throw new InvalidOperationException("Game is over");
            }

            // Can't place 3 cards if one or both is blank
            if (positions[firstPos].Count == 0 || positions[secondPos].Count == 0 ||
                positions[thirdPos].Count == 0)
            {
                throw new InvalidOperationException("Invalid Move");
            }

            if (! (positions[firstPos].Last().IsFaceCard && positions[secondPos].Last().IsFaceCard &&
                positions[thirdPos].Last().IsFaceCard) )
            {
                throw new InvalidOperationException("Invalid Move");
            }

            bool isValidMove = false;
            if (positions[firstPos].Last().Value == positions[secondPos].Last().Value &&
                positions[firstPos].Last().Value == positions[thirdPos].Last().Value)
            {
                isValidMove = true;
            }

            if (positions[firstPos].Last().Value + positions[secondPos].Last().Value +
                positions[thirdPos].Last().Value == 36)
            {
                isValidMove = true;
            }

            if (!isValidMove)
            {
                throw new InvalidOperationException("Invalid Move");
            }

            positions[firstPos].Add(deck.GetNextCard());
            positions[secondPos].Add(deck.GetNextCard());
            positions[thirdPos].Add(deck.GetNextCard());

        }

        public bool HasWon
        {
            get 
            { 
                return deck.Count == 0; 
            }
        }

        public bool IsStuck
        {
            get
            {
                return false;
            }
        }

        public int CardsRemaining
        {
            get
            {
                return deck.Count;
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (List<Card> position in positions)
            {
                if (position.Count > 0)
                {
                    s.Append(position.Last().ToString());
                }
                else
                {
                    s.Append("--");
                }

                s.Append(" ");
            }

            s.Append("Cards remaining: " + CardsRemaining);
            return s.ToString();
        }
    }
}
