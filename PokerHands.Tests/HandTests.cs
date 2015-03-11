using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace PokerHands.Tests
{
    [TestFixture]
    [Category("PokerHands.Tests")]
    public class HandTests
    {
        private HandRanker _handRanker;

        [SetUp]
        public void SetUp()
        {
            _handRanker = new HandRanker();
        }

        [Test]
        public void Hand1FourOfAKindAcesWinsOverHand2Kings()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Spade, CardValue.King),
                                new C(Suit.Heart, CardValue.King),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Diamond, CardValue.Six)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1FourOfAKindWinsOverHand2()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1FullHouseWins()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Heart, CardValue.Three)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1FullHouseWinsWithSevenOverTwoComparedToFourOverAces()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Spade, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Seven)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAFlush()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.King)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAFlushAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Spade, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Spade, CardValue.Queen),
                                new C(Suit.Spade, CardValue.King)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithARoyalFlushStraightFlushFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Club, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAStraightAceLow()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Eight),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Seven)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAStraightNineHighOverAStraightFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Eight),
                                new C(Suit.Diamond, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAStraightTenHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Eight),
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithAStraightTenHighOverHand2StraightNineHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight),
                                new C(Suit.Diamond, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Five),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Seven)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithHighCardAceAndKingJackKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithHighCardAceAndKingTenEightKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Spade, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithHighCardAceAndKingTenSevenFiveKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithHighCardAceAndTenKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithPairOfThreesAndJackKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithStraightFlush()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Club, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithStraightFlushJackHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Club, CardValue.Nine),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Jack)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Spade, CardValue.Five),
                                new C(Suit.Spade, CardValue.Six),
                                new C(Suit.Spade, CardValue.Seven),
                                new C(Suit.Spade, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithStraightFlushNineHighOverStraightFlushFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Club, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Spade, CardValue.Five)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithThreeOfAKindTens()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithThreeOfAKindTensAgainistHand2ThreeOfAKind()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithTwoPairJacksAndFoursAndKingKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Four),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Queen)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithTwoPairSevensAndTensAndKingKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Diamond, CardValue.Five),
                                new C(Suit.Spade, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Heart, CardValue.King)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WinsWithTwoPairTwosAndFoursAndKingKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Heart, CardValue.Four),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Queen)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfFives()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Five),
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfFoursAceJackKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfFoursAceJackSixKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfFoursAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfKings()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.King),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithHighestPairWinsPairOfTwos()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand1WithTwoPairTwosAndThrees()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Three)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand2FourOfAKindQueensWinsOverHand1FourOfAKindNines()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Diamond, CardValue.Nine),
                                new C(Suit.Club, CardValue.Nine),
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Spade, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Queen),
                                new C(Suit.Diamond, CardValue.Queen),
                                new C(Suit.Diamond, CardValue.Two)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2FourOfAKindWinsOverHand1()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.King),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Spade, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Queen),
                                new C(Suit.Diamond, CardValue.Queen),
                                new C(Suit.Diamond, CardValue.Two)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2FullHouseWins()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Heart, CardValue.Three)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2FullHouseWinsWithKingsOverAcesComparedToFourOverAces()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Diamond, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAFlush()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAFlushKingKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.King)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithARoyalFlushStraightFlushFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Club, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAStraightAceLow()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Eight),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Seven)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAStraightKingHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.King)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAStraightKingHighOverHand1QueenHighStraight()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Spade, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Nine),
                                new C(Suit.Heart, CardValue.Queen)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Nine),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Heart, CardValue.King)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithAStraightNineHighOverAStraightFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Heart, CardValue.Five)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Eight),
                                new C(Suit.Diamond, CardValue.Nine)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithHighCardAceAndKingKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithHighCardAceAndKingTenKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithHighCardAceAndKingTenSevenFourKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithHighCardAceAndKingTenSevenKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithStraightFlush()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Diamond, CardValue.Seven),
                                new C(Suit.Diamond, CardValue.Eight),
                                new C(Suit.Diamond, CardValue.Nine),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Jack)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithStraightFlushEightHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.Seven)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Spade, CardValue.Five),
                                new C(Suit.Spade, CardValue.Six),
                                new C(Suit.Spade, CardValue.Seven),
                                new C(Suit.Spade, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithStraightFlushNineHighOverStraightFlushFiveHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Spade, CardValue.Five)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Eight),
                                new C(Suit.Club, CardValue.Nine)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithThreeOfAKindJacks()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Seven),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithThreeOfAKindJacksAgainistHand1ThreeOfAKind()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ten),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Jack),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithTwoPairFivesAndTensAndAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Diamond, CardValue.Five),
                                new C(Suit.Spade, CardValue.Ten),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Heart, CardValue.King)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithTwoPairTwosAndFours()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithTwoPairTwosAndFoursAndAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Heart, CardValue.Four),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Four),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WinsWithTwoPairTwosAndTensAndAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Heart, CardValue.Four),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.King)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Spade, CardValue.Two),
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Ten),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfFours()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Nine),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfFoursAceJackSevenKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Six),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Seven),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfFoursAceKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfFoursAceQueenKicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Spade, CardValue.Four),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Ace),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Diamond, CardValue.Four)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfThrees()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfThreesAnd10Kicker()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Three),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Four)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Spade, CardValue.Three),
                                new C(Suit.Heart, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ten)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void Hand2WithHighestPairWinsPairOfTwos()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Heart, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Ace)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Diamond, CardValue.Two),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void HandWithHighestRankWinsAceHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Ace),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void HandWithHighestRankWinsEightHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Seven)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void HandWithHighestRankWinsJackHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void HandWithHighestRankWinsKingHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.King),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 2);
        }

        [Test]
        public void HandWithHighestRankWinsNineHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Five),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void HandWithHighestRankWinsQueenHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Queen),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Jack),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 1);
        }

        [Test]
        public void HandWithHighestRankWinsTenHigh()
        {
            var hand1 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Ten),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Nine)
                        };

            var hand2 = new List<C>
                        {
                                new C(Suit.Club, CardValue.Two),
                                new C(Suit.Club, CardValue.Four),
                                new C(Suit.Club, CardValue.Three),
                                new C(Suit.Club, CardValue.Six),
                                new C(Suit.Heart, CardValue.Eight)
                        };

            RankHands(hand1, hand2, 1);
        }

        private void RankHands(IList<C> hand1, IList<C> hand2, int expectedWinner)
        {
            var winner = _handRanker.RankHands(hand1, hand2);

            winner.Should().Be(expectedWinner);
        }
    }
}