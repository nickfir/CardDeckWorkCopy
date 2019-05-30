using System;

namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardDeck deck = new StandardDeck("Standard");
            IDeck deck2 = deck.DealerDeck();
            Console.WriteLine($"{deck.Name}");
            foreach (Card card in deck2.Cards)
            {
                Console.WriteLine($"{card.Name}, {card.Suit}, {card.Value}");
            }
            Console.ReadLine();
            Console.WriteLine($"{deck2.Name}");
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine($"{card.Name}, {card.Suit}, {card.Value}");
            }
            Console.WriteLine($"{deck.Cards.Count} cards total.");
            string[] names = { "Alice", "Bob", "Charles", "Dan", "Elizabeth" };
            BlackJack game = new BlackJack("BlackJack", 5, names);
            game.Deal(deck2 as Deck);
            for (int i = 0; i < (4); i++)
            {
                for (int j = 0; j <=1; j++)
                {
                    Console.WriteLine($"{game.Hands[i].cards[j].Name} is Player {i + 1}'s card {j+1}");
                }
            }
        }
    }
}
