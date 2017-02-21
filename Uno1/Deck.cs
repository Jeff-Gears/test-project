using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno1
{
    class Deck
    {
        private List<Card> remainingCards;
        private List<Card> discardPile;
        Random rand;
        /// <summary>
        /// Creates a New Deck this deck will not be shuffled
        /// </summary>
        public Deck()
        {
            rand = new Random();
            remainingCards = new List<Card>();
            discardPile = new List<Card>();
            InitialzeDeck();

        }
        /// <summary>
        /// returns number of cards remaing on the deck
        /// </summary>
        /// <returns></returns>
        public int GetNumCardsDeck()
        {
            return remainingCards.Count;
        }
        /// <summary>
        /// return number of cards total in the deck and discard pile
        /// </summary>
        /// <returns></returns>
        public int GetNumCardsTotal()
        {
            return remainingCards.Count + discardPile.Count;
        }
        /// <summary>
        /// removes the top card from the deck and return that card if the deck is empty it will shuffle
        /// the discard pile into the deck then return the top card, If no cards are present it will return
        /// a card with value 0 and a null suit value
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            Card topCard = new Card(0, "null");// pass in invalid values to make sure that can detect if deck is empty
            if (remainingCards.Count != 0)
            {
                topCard = remainingCards[0];
                remainingCards.RemoveAt(0);
            }
            else if (discardPile.Count > 1)
            {
                ShuffleAll();
				topCard = remainingCards[0];
                remainingCards.RemoveAt(0);
            }
            return topCard;
        }

        /// <summary>
        /// adds the card to the discard pile
        /// </summary>
        /// <param name="card"></param>
        public void DiscardCard(Card card)
        {
            discardPile.Add(card);
        }

        /// <summary>
        /// returns the value of the top card of the discard pile
        /// </summary>
        /// <returns></returns>
        public Card ReadDiscardPile()
        {
            return discardPile[discardPile.Count - 1];
        }


        /// <summary>
        /// Adds the card to the bottom of the deck
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToDeck(Card card)
        {
            remainingCards.Add(card);
        }

        /// <summary>
        /// Shuffles all of the remaining cards in the deck
        /// </summary>
        public void ShuffleRemaining()
        {
            //this works by going through each card in the list and chosing another card at random to swap places with
            int shuffleNumber = remainingCards.Count;
            while (shuffleNumber > 1)
            {
                int randNum = rand.Next(0, shuffleNumber);
                shuffleNumber--;
                Card shuffledCard = remainingCards[randNum];
                remainingCards[randNum] = remainingCards[shuffleNumber];
                remainingCards[shuffleNumber] = shuffledCard;
            }
        }

        /// <summary>
        /// Puts all but the top card in the discardPile back into the deck and shuffles.
        /// </summary>
        public void ShuffleAll()
        {
            for (int i = 0; i < discardPile.Count-1; i++)
            {
                remainingCards.Add(discardPile[i]);
                discardPile.RemoveAt(i);
            }
            ShuffleRemaining();
        }

        /// <summary>
        /// Resets the deck to a new shuffled deck
        /// </summary>
        public void ResetAndShuffle()
        {
            ClearDeck();
            InitialzeDeck();
            ShuffleRemaining();
        }

        /// <summary>
        /// this will remove all cards from the deck and discard Pile
        /// </summary>
        public void ClearDeck()
        {
            remainingCards.Clear();
            discardPile.Clear();
        }

        /// <summary>
        /// used to set all of the cards in a deck
        /// </summary>
        private void InitialzeDeck()
        {
            //create  an array to hold the 4 suit strings
            string[] suitArray = new string[4] { "spades", "hearts", "clubs", "diamonds" };
            //use nested for loops to add all of the cards to the list
            for (int suitCount = 0; suitCount < 4; suitCount++)
            {
                for (int value = 2; value < 15; value++)
                {
                    remainingCards.Add(new Card(value, suitArray[suitCount]));
                }
            }
        }
    }
}
