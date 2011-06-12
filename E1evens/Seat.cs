using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E1evens
{
    public class Seat
    {
        private CardList deck;
        private CardList[] positions;

        public Seat()
        {
            deck = CardList.CreateStandardDeck();
            positions = new CardList[9];
            for (int i = 0; i < 9; i++)
            {
                positions[i] = new CardList();
            }
        }

        public Seat(CardList deck, CardList[] positions)
        {
            this.Deck = deck;
            this.Positions = positions;
        }

        public CardList Deck
        {
            get { return deck; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                deck = value;
            }
        }

        public CardList[] Positions
        {
            get { return positions; }
            set
            {
                if (value == null || value.Length != 9)
                {
                    throw new ArgumentException();
                }
                positions = value;
            }
        }

        public void NewGame() 
        {
            deck = CardList.CreateStandardDeck();
            deck.Shuffle();

            for (int i = 0; i < 9; i++)
            {
                positions[i].Clear();
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
                throw new InvalidMoveException("Invalid Move");
            }

            positions[firstPos].Add(deck.Pop());

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
                throw new InvalidMoveException("Invalid Move");
            }

            if (positions[firstPos].Last().IsFaceCard || positions[secondPos].Last().IsFaceCard) 
            {
                throw new InvalidMoveException("Invalid Move");
            }

            // Check the 2 card placement is a valid move
            if (positions[firstPos].Last().Value + positions[secondPos].Last().Value != 11)
            {
                throw new InvalidMoveException("Invalid Move");
            }

            positions[firstPos].Add(deck.Pop());
            positions[secondPos].Add(deck.Pop());
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
                throw new InvalidMoveException("Invalid Move");
            }

            if (! (positions[firstPos].Last().IsFaceCard && positions[secondPos].Last().IsFaceCard &&
                positions[thirdPos].Last().IsFaceCard) )
            {
                throw new InvalidMoveException("Invalid Move");
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
                throw new InvalidMoveException("Invalid Move");
            }

            positions[firstPos].Add(deck.Pop());
            positions[secondPos].Add(deck.Pop());
            positions[thirdPos].Add(deck.Pop());

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
                //Checks for an available card space.
                foreach (CardList p in Positions)
                {
                    if (p.Count == 0)
                    {
                        return false;
                    }

                }
             
                Card[] cardsInSeat = new Card[9];
                for (int i = 0; i < Positions.Length; i++)
                {
                    if (!positions[i].Top.IsFaceCard)
                    {
                        cardsInSeat[i] = positions[i].Top;
                    }
                }

                for (int i = 0; i < cardsInSeat.Length - 1; i++)
                {
                    for (int j = i + 1; j < cardsInSeat.Length; j++)
                    {
                        if (cardsInSeat[i] != null && cardsInSeat[j] != null)
                        {
                            if (cardsInSeat[i].Value + cardsInSeat[j].Value == 11)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
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

            s.Append("Cards remaining: " + Deck.Count);
            return s.ToString();
        }
    }
}
