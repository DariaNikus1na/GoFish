using GoFish.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.player
{
    internal class Bot : Player
    {
        private List<Card> BotCards;

        public Bot(List<Card> cards)
        {
            this.BotCards = cards;
        }

        bool Player.CheckForCard(Value value)
        {
            Random random = new Random();
            Console.WriteLine($"- Do you have {value}?");
            int timeDelay = random.Next(3, 6);
            foreach (var card in BotCards)
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

        Value Player.ChooseCard()
        {
            Random random = new Random();
            Console.WriteLine("Bot is choosing a card...");
            int timeDelay = random.Next(4, 8);
            Thread.Sleep(timeDelay * 1000);
            int index = random.Next(0, BotCards.Count);
            Console.Clear();
            return BotCards[index].GetValue();
        }

        void Player.CountFours()
        {
            throw new NotImplementedException();
        }

        List<Card> Player.GiveCardForOpponent(Value value)
        {
            List<Card> cardsOfSameValue = new List<Card>();
            foreach (var card in BotCards.ToArray())
            {
                if (card.GetValue() == value)
                {
                    cardsOfSameValue.Add(card);
                    BotCards.Remove(card);
                }
            }
            return cardsOfSameValue;
        }

        void Player.GoFish(List<Card> pool)
        {
            Random random = new Random();
            BotCards.Add(pool[random.Next(0, pool.Count)]);
        }

        void Player.RecieveCardFromOpponent(List<Card> cardsOfSameValue)
        {
            foreach (var card in cardsOfSameValue)
            {
                BotCards.Add(card);
            }

        }
    }
}
