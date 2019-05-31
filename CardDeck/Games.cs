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
        public static bool IsAce(Card card)
        {
            if (card != null)
            {
                bool value;
                value = (card.Value == 1) ? true : false;
                return value;
            }
            else
            {
                return false;
            }
        }
        public BlackJack(string name, int players, string[] names) : base(name)
        {
            Players = players;
            MakeHands(names);
        }
        public int players;
        public BlackJack Deal(IDeck deck)
        {
            for (int i = 0; i <= (Players - 1); i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    this.Hands[i].Cards.Add(deck.Draw(1));
                }
            }
            return this;
        }
        public void SplitPair(List<BlackJackHand> hand, IDeck deck, int index)
        {
            BlackJackHand handnew = new BlackJackHand($"{hand[index].Playername} split", 2);
            Card card = new Card("","",0);
            card = hand[index].Cards[1];
            hand[index].Cards[1] = deck.Draw(1);
            handnew.Cards.Add(card);
            handnew.Cards.Add(deck.Draw(1));
            hand.Add(handnew);

        }
        public void MakeHands(string[] names)
        {
            //List<Hand> Hands = new List<Hand>();
            
            for (int i = 0; i <= (Players - 1); i++)
            {
                BlackJackHand hand = new BlackJackHand(names[i], 2);
                this.Hands.Add(hand);
            }
        }
        public class BlackJackHand : Hand
        {
            public BlackJackHand(string name, int count) : base(name, count)
            {
                //implement the BJH stuff
                //sum cards
                //determine ace high/low
                //split pair
                Playername = Name;
                this.Cards = new List<Card>();// new Card[count];
            }
            public bool IsPair()
            {
                if ((this != null) && (this.Cards[0].Value == this.Cards[1].Value) && (this.Cards.Count == 2))
                {
                    return true;
                }
                return false;
            }

            public int GetValue()
            {
                int value = 0;
                if ((this != null) && (this.Cards !=null))
                {
                    int index = this.Cards.Count;
                    foreach (Card card in Cards)
                    {
                        if (IsAce(card) && (value <= 10))
                        {
                            value = (value <= 10) ? value + 11 : 21;
                        }
                        else
                        {
                            value += (card.Value <= 10) ? card.Value : 10;
                        }
                    }
                    if (value == 21)
                    {
                        Winning(this.Playername);
                        return value;
                    }
                    else
                    {
                        return value;
                    }
                }
                return value;
            }
            public void Winning(string winner)
            {
                Console.WriteLine($"{winner} has Blackjack!");
                Console.ReadLine();
                //System.Environment.Exit(0);
            }
            public string Playername
            {
                get;
            }
            public int Value = 0;

        }

        public List<BlackJackHand>Hands = new List<BlackJackHand>();
        const int maxPlayers = 5;
        public int Players;
        public IDeck deck = new StandardDeck("BlackJack");
        public string[] Names;
    }
}
