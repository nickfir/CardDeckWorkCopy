using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    public static class MyExt
    {
        public static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
    public class NamedObject
    { 
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public class Card : NamedObject
    {
        public Card(string name, string suit, int value) : base(name)
        {
            Suit = suit;
            Value = value;
        }
        public string Suit
        {
            get;
        }
        public int Value
        {
            get;
        }
    }
    public class Hand : NamedObject
    {
        public Hand(string name, int count) : base(name)
        {
            PlayerName = Name;
            this.Cards= new List<Card>();
        }
        public string PlayerName
        {
            get;
        }
        public List<Card> Cards;
    }
    public class Deck : NamedObject, IDeck
    {
        public Deck(string name) : base(name)
        {
            Cards = new List<Card>();
            Index = 0;
        }
        public List<Card> Cards
        {
            get;
        }
        public virtual Deck DealerDeck()
        {
            Deck deck = new Deck("");
            deck = this.ShuffleDeck();
            return deck;
        }
        public void AddCard(string name, string suit, int value)
        {
            Card card = new Card(name, suit, value);
            Cards.Add(card);
        }
        public virtual Card Draw(int count)
        {
            Card card = new Card("","",0);
            if (Index < this.Cards.Count)
            {
                card = this.Cards[Index];
                Index++;
                return card;
            }
            else
            {
                Console.WriteLine("Out of Cards!");
                Console.WriteLine("Shuffling!");
                this.Index = 0;
                this.ShuffleDeck();
                Console.ReadLine();
                card = this.Cards[Index];
                Index++;
                return card;
            }
        }
        public virtual Deck ShuffleDeck()
        {
            Deck deck = new Deck("temp");
            deck = this;
            deck.Cards.Shuffle<Card>();
            return deck;
        }
        public int Index
        {
            get; set;
        }

    }
    public interface IDeck
    {
        void AddCard(string name, string suit, int value);
        string Name { get; }
        Card Draw(int count);
        Deck ShuffleDeck();

        List<Card> Cards { get; }


    }
}
