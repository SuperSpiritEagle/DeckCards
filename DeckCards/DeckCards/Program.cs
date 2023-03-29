using System;
using System.Collections.Generic;

namespace DeckCards
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ComandYes = "да";
            const string ComandNo = "нет";

            string userInput;

            int number = 0;

            bool isWork = true;

            Deck deck = new Deck();
            Player player = new Player();

            while (isWork)
            {
                Console.WriteLine("Введите количество карт в колоде: ");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out number);
                Console.Clear();

                if (number <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid value!!!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    deck.CreateDeck(number);
                    isWork = false;
                }
            }

            isWork = true;

            int count = 0;

            while (isWork)
            {
                Console.WriteLine($"Хотите взять карту? {ComandYes} или {ComandNo}");
                userInput = Console.ReadLine();

                if (userInput == ComandYes)
                {
                    Card card = deck.GetCard();

                    player.AddCard(card);
                }

                else if (userInput == ComandNo)
                {
                    isWork = false;
                    Console.Clear();
                }

                count++;

                if (number == count)
                {
                    isWork = false;
                    Console.Clear();
                }
            }

            player.ShowCards();
        }

        enum CardValue
        {
            Два,
            Три,
            Четыре,
            Пять,
            Шесть,
            Семь,
            Восемь,
            Девять,
            Десять,
            Валет,
            Королева,
            Король,
            Туз,
            Joker
        }

        class Player
        {
            private List<Card> _cards = new List<Card>();

            public void AddCard(Card card)
            {
                _cards.Add(card);
            }

            public void ShowCards()
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    _cards[i].ShowInfo();
                }
            }
        }

        class Deck
        {
            private Queue<Card> _cards = new Queue<Card>();
            public void CreateDeck(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    _cards.Enqueue(new Card());
                }
            }

            public Card GetCard()
            {
                return _cards.Dequeue();
            }
        }

        class Card
        {
            private CardValue _cardValue;
            private Random random = new Random();

            public Card()
            {
                var numberCard = Enum.GetNames(typeof(CardValue)).Length;
                _cardValue = (CardValue)random.Next(0, numberCard);
            }

            public string GetSuit()
            {
                string[] Suits = new string[] { "♣", "♠", "♥", "♦" };
                int count = random.Next(0, Suits.Length);

                return Suits[count];
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Масть : {GetSuit()} , Карта : {_cardValue}");
                Console.WriteLine();
            }
        }
    }
}
