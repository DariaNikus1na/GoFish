using GoFish.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.player
{
    internal class Protagonist : Player
    {
        private List<Card> ProtagonistCards;

        public Protagonist(List<Card> cards)
        {
            this.ProtagonistCards = cards;
        }

        void Player.CountFours()
        {
            throw new NotImplementedException();
        }

        void Player.GetCard(Player Asker, Value value)
        {
            throw new NotImplementedException();
        }

        void Player.GoFish(Card card)
        {
            throw new NotImplementedException();
        }

        internal void ShowProtagonistCards() 
        { 
            foreach (var card in ProtagonistCards)
                Console.Write($"|{card}| ");
            Console.WriteLine();
        }

        Value Player.ChooseCard()
        {
            Console.WriteLine("Enter number of card: ");
            int index = Convert.ToInt32(Console.ReadLine());
            index--;

            return ProtagonistCards[index].GetValue();
        }

        bool Player.CheckForCard(Value value)
        {
            foreach (var card in ProtagonistCards)
                if (card.GetValue() == value) return true;
            return false;
        }
    }
}
