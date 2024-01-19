using GoFish.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.player
{
    internal interface Player
    {
        internal List<Card> GetPlayersDeck();
        internal void AddScore();
        internal Value ChooseCard();
        internal Boolean CheckForCard(Value value);
        internal void GoFish(List<Card> pool);
        internal List<Card> GiveCardForOpponent(Value value);
        internal void RecieveCardFromOpponent(List<Card> cardsOfSameValue);
        
    }
}
