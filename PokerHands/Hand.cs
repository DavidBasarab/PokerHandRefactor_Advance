using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class Hand
    {
        private List<CardGroup> _cardGroup;
        private IEnumerable<Card> _cards;

        public bool IsFlush
        {
            get
            {
                var firstSuit = _cards.Select(i => i.Suit).FirstOrDefault();

                return _cards.All(i => i.Suit == firstSuit);
            }
        }

        public bool IsPair
        {
            get { return _cardGroup.Any(i => i.Count == 2); }
        }

        public bool IsStraight { get; private set; }

        private bool IsACardAnAce
        {
            get { return HandContainValue(CardValue.Ace); }
        }

        private bool IsLowestCardATwo
        {
            get { return LowestCardValue == CardValue.Two; }
        }

        private CardValue LowestCardValue
        {
            get { return _cardGroup.OrderBy(i => (int)i.Value).Select(i => i.Value).FirstOrDefault(); }
        }

        public void Deal(IEnumerable<Card> cards)
        {
            _cards = cards;

            CreateCardGroup(cards);

            DetermineIfCardsAreStraight();
        }

        private void CreateCardGroup(IEnumerable<Card> cards)
        {
            _cardGroup = cards.GroupBy(i => i.CardValue).Select(g => new CardGroup
                                                                     {
                                                                             Value = g.Key,
                                                                             Count = g.Select(v => (int)v.CardValue).Count()
                                                                     }).ToList();
        }

        private void DetermineIfAceLowStraight()
        {
            for (var i = 0; i < 4; i++)
                if (HandDoesNotContainValue((CardValue)i))
                {
                    IsStraight = false;

                    break;
                }
        }

        private void DetermineIfCardsAreConsective()
        {
            var currentCheckValue = (int)LowestCardValue;

            for (var i = 0; i < _cardGroup.Count; i++)
                if (HandContainValue((CardValue)currentCheckValue)) currentCheckValue = currentCheckValue + 1;
                else
                {
                    IsStraight = false;

                    break;
                }
        }

        private void DetermineIfCardsAreStraight()
        {
            IsStraight = _cardGroup.Count == 5;

            if (IsACardAnAce && IsLowestCardATwo) DetermineIfAceLowStraight();
            else DetermineIfCardsAreConsective();
        }

        private bool HandContainValue(CardValue cardValue)
        {
            return _cardGroup.Any(i => i.Value == cardValue);
        }

        private bool HandDoesNotContainValue(CardValue value)
        {
            return !HandContainValue(value);
        }

        private class CardGroup
        {
            public int Count { get; set; }
            public CardValue Value { get; set; }
        }
    }
}