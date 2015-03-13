using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace PokerHands.Tests
{
    [TestFixture]
    [Category("PokerHands.Tests")]
    public class HandTests
    {
        private Hand _hand;

        [SetUp]
        public void SetUp()
        {
            CreateHand();
        }

        [Test]
        public void AceCanBeHighForAStraight()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Ten),
                                new Card(Suit.Spade, CardValue.Jack),
                                new Card(Suit.Heart, CardValue.Queen),
                                new Card(Suit.Heart, CardValue.King),
                                new Card(Suit.Heart, CardValue.Ace)
                        };

            _hand.Deal(cards);

            _hand.IsStraight.Should().BeTrue();
        }

        [Test]
        public void AceCanBeLowForAStraight()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Ace),
                                new Card(Suit.Spade, CardValue.Two),
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Five)
                        };

            _hand.Deal(cards);

            _hand.IsStraight.Should().BeTrue();
        }

        [Test]
        public void IfAllFiveCardsHaveSameSuiteThenIsFlushIsTrue()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Six),
                                new Card(Suit.Heart, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsFlush.Should().BeTrue();
        }

        [Test]
        public void IfCardValuesAreInOrderThenItIsAStraight()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Nine),
                                new Card(Suit.Heart, CardValue.Ten),
                                new Card(Suit.Heart, CardValue.Seven),
                                new Card(Suit.Spade, CardValue.Eight),
                                new Card(Suit.Heart, CardValue.Jack)
                        };

            _hand.Deal(cards);

            _hand.IsStraight.Should().BeTrue();
        }

        [Test]
        public void IfHandJustHasHighCardThenItIsNotAStraight()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Seven),
                                new Card(Suit.Spade, CardValue.Ten),
                                new Card(Suit.Heart, CardValue.Four),
                                new Card(Suit.Diamond, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsStraight.Should().BeFalse();
        }

        [Test]
        public void IfOneOfTheCardsHasADifferentSuitThenIsFlushIsFalse()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Six),
                                new Card(Suit.Spade, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsFlush.Should().BeFalse();
        }

        [Test]
        public void IfTwoCardsAreNotTheSameValueThenIsPairIsFalse()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Six),
                                new Card(Suit.Spade, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsPair.Should().BeFalse();
        }

        [Test]
        public void IfTwoCardsAreTheSameValueThenIsPairIsTrue()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Spade, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsPair.Should().BeTrue();
        }

        [Test]
        public void IfTwoCardsAreTheSameValueThenIsStraightIsFalse()
        {
            var cards = new List<Card>
                        {
                                new Card(Suit.Heart, CardValue.Three),
                                new Card(Suit.Spade, CardValue.Three),
                                new Card(Suit.Heart, CardValue.Four),
                                new Card(Suit.Heart, CardValue.Two),
                                new Card(Suit.Heart, CardValue.King)
                        };

            _hand.Deal(cards);

            _hand.IsStraight.Should().BeFalse();
        }

        private void CreateHand()
        {
            _hand = new Hand();
        }
    }
}