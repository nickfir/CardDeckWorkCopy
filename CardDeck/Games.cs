using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    public class CardGame : NamedObject
    {
        public CardGame(string name, string[] players, Deck deck) : base(name)
        {
            Deck = deck;
        }
        public IDeck Deck;


    }
    public class BlackJack : NamedObject
    {
        public BlackJack(string name, int players, string[] names) : base(name)
        {
            CardGame game = new CardGame(name, names, deck as StandardDeck);
            //Hand[] this.Hands = new Hand[players];
            for (int i = 0; i <= (players - 1); i++)
            {
                this.Hands[i] = new Hand(names[i], 2);
            }

        }
        public int players;
        public BlackJack Deal(IDeck deck)
        {
            //BlackJack game = new BlackJack(this.Name, players, Names);

            for (int i = 0; i < (players - 1); i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    this.Hands[i].cards[j] = deck.Draw(1);
                }
            }
            return this;
        }
        public Hand[] Hands = new Hand[maxPlayers];
        const int maxPlayers = 5;
        public IDeck deck = new StandardDeck("BlackJack");
        public string[] Names;
    }
}
