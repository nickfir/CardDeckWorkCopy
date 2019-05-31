/* Card is a class of Name, Suit, and Value
	All three properties are settable from Deck

Deck is a class of Name, Card list
	Deck exposes Draw returning a card
	Deck exposes ShuffleDeck randomizing the 
	
StandardDeck implements Deck as a 52 card 4 suited deck Ace through King

BlackJack is a game, game takes a string[] of playernames, and count of players
	Game implements a Hand per player with playername and count of cards in card[]
	Game.Hand.Cards as card[] of card count

CardGame is a class with gameName, string[] of players, deck

BlackJack is a class with CardGame, 5 max players, standard deck
*/

using System;

namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardDeck deck = new StandardDeck("Standard");
            IDeck deck2 = deck.DealerDeck();
            /*Console.WriteLine($"{deck.Name}");
            foreach (Card card in deck2.Cards)
            {
                Console.WriteLine($"{card.Name}, {card.Suit}, {card.Value}");
            }
            Console.ReadLine();
            Console.WriteLine($"{deck2.Name}");
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine($"{card.Name}, {card.Suit}, {card.Value}");
            }*/
            Console.WriteLine($"{deck.Cards.Count} cards total.");
            string[] names = { "Alice", "Bob", "Charles", "Dan", "Elizabeth" };
            string quit = "";
            do
            {
                BlackJack game = new BlackJack("BlackJack", 5, names);
                game.Deal(deck2 as Deck);
                for (int i = 0; i <= (game.Hands.Count - 1); i++)
                {
                    int j = 1;
                    readout:
                    foreach (Card card in game.Hands[i].Cards)
                    //                for (int j = 0; j <=1; j++)
                    {
                        Console.WriteLine($"{game.Hands[i].PlayerName}'s {j} card: {card.Name} of {card.Suit}");
                        j++;
                    }
                    if (game.Hands[i].IsPair())
                    {
                        Console.WriteLine($"A Pair of {game.Hands[i].Cards[0].Name}'s, Split? (y/n)");
                        string x = Console.ReadLine();
                        if (x == "y")
                        {
                            game.SplitPair(game.Hands, deck2, i);
                            j = 1;
                            goto readout;
                        }
                    }
                    Console.WriteLine($"Value of hand: {game.Hands[i].GetValue()}");
                }
                Console.WriteLine("Quit? (y/n)");
                quit = Console.ReadLine();
            } while (quit != "y");
        }
    }
}
