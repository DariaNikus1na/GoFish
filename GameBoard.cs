﻿using GoFish.card;
using GoFish.player;
using System.ComponentModel.Design;

internal class GameBoard
{
    internal static void Main(string[] args)
    {
        List<Card> Pool = new List<Card>();
        List<Card> playerDeck1 = new List<Card>();
        List<Card> playerDeck2 = new List<Card>();
        Pool = CreateNewPool(Pool);
        FillUpDecks(playerDeck1, playerDeck2, Pool);
        Protagonist Igorek = new Protagonist(playerDeck1);
        Bot Elektronik = new Bot(playerDeck2);
        Player ActivePlayer = Igorek;
        Player Opponent = Elektronik;


        // ИГРА
        while (playerDeck1.Count != 0 && playerDeck2.Count != 0 && Pool.Count != 0)
        {
            bool IsTurnContinues = true;
            while(IsTurnContinues)
            {
                Igorek.ShowProtagonistCards();
                Console.WriteLine($"Collected 4-card books: {Igorek.GetScore()}    |   Number of opponent's cards: {playerDeck2.Count}  |   Cards in the pool:{Pool.Count}") ;
                
                CheckForFours(ActivePlayer, ActivePlayer.GetPlayersDeck(), GetSetOfUniqeValues(ActivePlayer.GetPlayersDeck()));
                CheckForFours(Opponent, Opponent.GetPlayersDeck(), GetSetOfUniqeValues(Opponent.GetPlayersDeck()));

                Value value = ActivePlayer.ChooseCard();
                if (Opponent.CheckForCard(value) )
                {
                    ActivePlayer.RecieveCardFromOpponent(Opponent.GiveCardForOpponent(value));
                }
                else
                {
                    ActivePlayer.GoFish(Pool);
                    IsTurnContinues = false;
                   
                }
                Thread.Sleep(1500);
                Console.Clear();
                if (playerDeck1.Count == 0 | playerDeck2.Count == 0 | Pool.Count == 0) break;
            }
            
            Player[] players = NextTurn(ActivePlayer, Opponent);
            ActivePlayer = players[0];
            Opponent = players[1];
        }

        if (Igorek.GetScore() == Elektronik.GetScore())
        { Console.WriteLine("Tie!"); }
        else if (Igorek.GetScore() > Elektronik.GetScore())
        {
            Console.WriteLine("You won!");
        }
        else { Console.WriteLine("Bot won!"); }


    }

       
        public static Player[] NextTurn(Player ActivePlayer, Player Opponent)
        {
        Player TempPlayer = ActivePlayer;
        ActivePlayer = Opponent;
        Opponent = TempPlayer;
        return new Player[] {ActivePlayer, Opponent};
        }
        public static void CheckForFours(Player player, List<Card> Deck, ISet<Value> SetValues)
        {
            foreach (Value value in SetValues)
            {
                int count = 0;
                foreach (Card card in Deck)
                {
                    if (value == card.GetValue()) count++;
                }
                if (count == 4)
                {
                    ClearFours(Deck, value);
                    player.AddScore();
                }
            }
        }
        public static void ClearFours(List<Card> Deck, Value value)
        {
            Deck.RemoveAll(x => x.GetValue() == value);
        }
        public static ISet<Value> GetSetOfUniqeValues(List<Card> Deck)
        {
            ISet<Value> Set = new HashSet<Value>();
            foreach (Card card in Deck)
            {
                Set.Add(card.GetValue());
            }
            return Set;
        }
        public static List<Card> CreateNewPool(List<Card> pool)
        {
            Card Clubs2 = new Card(Suit.Clubs, Value.Twos); pool.Add(Clubs2);
            Card Clubs3 = new Card(Suit.Clubs, Value.Threes); pool.Add(Clubs3);
            Card Clubs4 = new Card(Suit.Clubs, Value.Fours); pool.Add(Clubs4);
            Card Clubs5 = new Card(Suit.Clubs, Value.Fives); pool.Add(Clubs5);
            Card Clubs6 = new Card(Suit.Clubs, Value.Sixes); pool.Add(Clubs6);
            Card Clubs7 = new Card(Suit.Clubs, Value.Sevens); pool.Add(Clubs7);
            Card Clubs8 = new Card(Suit.Clubs, Value.Eights); pool.Add(Clubs8);
            Card Clubs9 = new Card(Suit.Clubs, Value.Nines); pool.Add(Clubs9);
            Card Clubs10 = new Card(Suit.Clubs, Value.Tens); pool.Add(Clubs10);
            Card ClubsJ = new Card(Suit.Clubs, Value.Jacks); pool.Add(ClubsJ);
            Card ClubsQ = new Card(Suit.Clubs, Value.Queens); pool.Add(ClubsQ);
            Card ClubsK = new Card(Suit.Clubs, Value.Kings); pool.Add(ClubsK);
            Card ClubsA = new Card(Suit.Clubs, Value.Aces); pool.Add(ClubsA);

            Card Hearts2 = new Card(Suit.Hearts, Value.Twos); pool.Add(Hearts2);
            Card Hearts3 = new Card(Suit.Hearts, Value.Threes); pool.Add(Hearts3);
            Card Hearts4 = new Card(Suit.Hearts, Value.Fours); pool.Add(Hearts4);
            Card Hearts5 = new Card(Suit.Hearts, Value.Fives); pool.Add(Hearts5);
            Card Hearts6 = new Card(Suit.Hearts, Value.Sixes); pool.Add(Hearts6);
            Card Hearts7 = new Card(Suit.Hearts, Value.Sevens); pool.Add(Hearts7);
            Card Hearts8 = new Card(Suit.Hearts, Value.Eights); pool.Add(Hearts8);
            Card Hearts9 = new Card(Suit.Hearts, Value.Nines); pool.Add(Hearts9);
            Card Hearts10 = new Card(Suit.Hearts, Value.Tens); pool.Add(Hearts10);
            Card HeartsJ = new Card(Suit.Hearts, Value.Jacks); pool.Add(HeartsJ);
            Card HeartsQ = new Card(Suit.Hearts, Value.Queens); pool.Add(HeartsQ);
            Card HeartsK = new Card(Suit.Hearts, Value.Kings); pool.Add(HeartsK);
            Card HeartsA = new Card(Suit.Hearts, Value.Aces); pool.Add(HeartsA);

            Card Spades2 = new Card(Suit.Spades, Value.Twos); pool.Add(Spades2);
            Card Spades3 = new Card(Suit.Spades, Value.Threes); pool.Add(Spades3);
            Card Spades4 = new Card(Suit.Spades, Value.Fours); pool.Add(Spades4);
            Card Spades5 = new Card(Suit.Spades, Value.Fives); pool.Add(Spades5);
            Card Spades6 = new Card(Suit.Spades, Value.Sixes); pool.Add(Spades6);
            Card Spades7 = new Card(Suit.Spades, Value.Sevens); pool.Add(Spades7);
            Card Spades8 = new Card(Suit.Spades, Value.Eights); pool.Add(Spades8);
            Card Spades9 = new Card(Suit.Spades, Value.Nines); pool.Add(Spades9);
            Card Spades10 = new Card(Suit.Spades, Value.Tens); pool.Add(Spades10);
            Card SpadesJ = new Card(Suit.Spades, Value.Jacks); pool.Add(SpadesJ);
            Card SpadesQ = new Card(Suit.Spades, Value.Queens); pool.Add(SpadesQ);
            Card SpadesK = new Card(Suit.Spades, Value.Kings); pool.Add(SpadesK);
            Card SpadesA = new Card(Suit.Spades, Value.Aces); pool.Add(SpadesA);

            Card Diamonds2 = new Card(Suit.Diamonds, Value.Twos); pool.Add(Diamonds2);
            Card Diamonds3 = new Card(Suit.Diamonds, Value.Threes); pool.Add(Diamonds3);
            Card Diamonds4 = new Card(Suit.Diamonds, Value.Fours); pool.Add(Diamonds4);
            Card Diamonds5 = new Card(Suit.Diamonds, Value.Fives); pool.Add(Diamonds5);
            Card Diamonds6 = new Card(Suit.Diamonds, Value.Sixes); pool.Add(Diamonds6);
            Card Diamonds7 = new Card(Suit.Diamonds, Value.Sevens); pool.Add(Diamonds7);
            Card Diamonds8 = new Card(Suit.Diamonds, Value.Eights); pool.Add(Diamonds8);
            Card Diamonds9 = new Card(Suit.Diamonds, Value.Nines); pool.Add(Diamonds9);
            Card Diamonds10 = new Card(Suit.Diamonds, Value.Tens); pool.Add(Diamonds10);
            Card DiamondsJ = new Card(Suit.Diamonds, Value.Jacks); pool.Add(DiamondsJ);
            Card DiamondsQ = new Card(Suit.Diamonds, Value.Queens); pool.Add(DiamondsQ);
            Card DiamondsK = new Card(Suit.Diamonds, Value.Kings); pool.Add(DiamondsK);
            Card DiamondsA = new Card(Suit.Diamonds, Value.Aces); pool.Add(DiamondsA);
            return pool;
        }
        public static void FillUpDecks(List<Card> deck1, List<Card> deck2, List<Card> pool)
        {
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int x = random.Next(0, pool.Count);
                deck1.Add(pool[x]);
                pool.Remove(pool[x]);
            }
            for (int i = 0; i < 7; i++)
            {
                int x = random.Next(0, pool.Count);
                deck2.Add(pool[x]);
                pool.Remove(pool[x]);
            }
        }

    
}

