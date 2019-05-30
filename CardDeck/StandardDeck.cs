using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    class StandardDeck : Deck, IDeck
    {
        public StandardDeck(string name) : base(name)
        {

            string[] suits = { "Diamonds", "Clubs", "Hearts", "Spades"};
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
            string[] names = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

            var count = 0;
            foreach (string suit in suits)
            {
                foreach (int value in values)
                {
                    this.AddCard($"{names[count]} of {suit}", suit, value);
                    count++;
                }
                count = 0;
            }
        }

        

    }
}
