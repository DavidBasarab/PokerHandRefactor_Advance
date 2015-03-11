namespace PokerHands
{
    public class C
    {
        public CardValue CardValue { get; set; }
        public Suit Suit { get; set; }

        public C(Suit suit, CardValue cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
        }
    }
}