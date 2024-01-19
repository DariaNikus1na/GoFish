using GoFish.card;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoFish.player
{
    internal class Protagonist : Player
    {
        private List<Card> ProtagonistCards;
        private Int32 Score = 0;

        public Protagonist(List<Card> cards)
        {
            this.ProtagonistCards = cards;
        }

        void Player.GoFish(List<Card> pool)
        {
            Random random = new Random();
            Card tempCard = pool[random.Next(0, pool.Count)];
            ProtagonistCards.Add(tempCard);
            pool.Remove(tempCard);
        }

        public void ShowProtagonistCards() 
        { 
            foreach (var card in ProtagonistCards)
                Console.Write($"|{card.GetSuitSymb()}{card.GetValueSymb()}| ");
            Console.WriteLine();
        }

        Value Player.ChooseCard()
        {
            string number = "q";
            while (number.Equals("") || !number.All(Char.IsDigit) || (Convert.ToInt32(number) > ProtagonistCards.Count) || (Convert.ToInt32(number) == 0))
            {
                Console.WriteLine("Enter the card number from your deck: ");
                number = Console.ReadLine();
            }
            int index = Convert.ToInt32(number);
            index--;
            Console.Clear();
            return ProtagonistCards[index].GetValue();
        }

        bool Player.CheckForCard(Value value)
        {
            Random random = new Random();
            Console.WriteLine($"- Do you have {value}?");
            int timeDelay = random.Next(2, 5);
            foreach (var card in ProtagonistCards)
                if (card.GetValue() == value)
                {
                    Thread.Sleep(timeDelay * 1000);
                    Console.WriteLine($"- Ugh, take it!");
                    return true;
                }
            Thread.Sleep(timeDelay * 1000);
            Console.WriteLine($"- Go fish, pal!!");
            return false;
        }

        List<Card> Player.GiveCardForOpponent(Value value)
        {
            List<Card> cardsOfSameValue = new List<Card>();
            foreach (Card card in ProtagonistCards.ToList())
            {
                if (card.GetValue() == value)
                {
                    cardsOfSameValue.Add(card);
                    ProtagonistCards.Remove(card);
                }
            }
            return cardsOfSameValue;
        }

        void Player.RecieveCardFromOpponent(List<Card> cardsOfSameValue)
        {
            foreach (var card in cardsOfSameValue)
            {
                ProtagonistCards.Add(card);
            }

        }

        void Player.AddScore()
        {
            Score++;
        }

        public int GetScore()
        {
            return Score;
        }

        List<Card> Player.GetPlayersDeck()
        {
            return ProtagonistCards;
        }
    }
}
