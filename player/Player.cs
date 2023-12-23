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
        internal Value ChooseCard();
        internal Boolean CheckForCard(Value value);
        internal void GoFish(Card card);
        internal void CountFours();
        internal void GetCard(Player Asker, Value value);
        
    }
}
