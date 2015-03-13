using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class FiveCardPokerHandRanking
    {
        public int RankHands(IList<Card> o, IList<Card> t)
        {
            var ovov = o.GroupBy(i => i.CardValue).Select(g => new
                                                                            {
                                                                                    Value = g.Key,
                                                                                    Count = g.Select(v => (int)v.CardValue).Count()
                                                                            }).ToList();

            var tvt = t.GroupBy(i => i.CardValue).Select(g => new
                                                                            {
                                                                                    Value = g.Key,
                                                                                    Count = g.Select(v => (int)v.CardValue).Count()
                                                                            }).ToList();

            var oVl = ovov.OrderBy(i => (int)i.Value).Select(i => (int)i.Value).FirstOrDefault();

            var oCon = ovov.Count == 5;

            if (ovov.Count == 5)
            {
                if (ovov.Any(i => i.Value == CardValue.Ace))
                {
                    for (var i = 0; i < 4; i++)
                    {
                        if (ovov.Any(v => (int)v.Value == (i))) ;
                        else
                        {
                            oCon = false;

                            break;
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < ovov.Count; i++)
                    {
                        if (ovov.Any(v => (int)v.Value == (oVl))) oVl = oVl + 1;
                        else
                        {
                            oCon = false;

                            break;
                        }
                    }
                }
            }

            var tVl = tvt.OrderBy(i => (int)i.Value).Select(i => (int)i.Value).FirstOrDefault();

            var tCon = tvt.Count == 5;

            if (tvt.All(i => i.Count > 0 && i.Count < 2))
            {
                if (tvt.Any(i => i.Value == CardValue.Ace))
                {
                    for (var i = 0; i < 4; i++)
                    {
                        if (tvt.Any(v => (int)v.Value == (i))) ;
                        else
                        {
                            tCon = false;

                            break;
                        }
                    }
                }
                else
                {
                    foreach (var value in tvt)
                    {
                        if (tvt.Any(v => (int)v.Value == (tVl))) tVl = tVl + 1;
                        else
                        {
                            tCon = false;

                            break;
                        }
                    }
                }
            }

            var oF = o.All(i => i.Suit == o.Select(j => j.Suit).FirstOrDefault());
            var tF = t.All(i => i.Suit == t.Select(j => j.Suit).FirstOrDefault());

            if ((oF && oCon) || (tF && tCon))
            {
                if (!(oF && oCon)) return 2;

                if (!(tF && tCon)) return 1;

                var o_m_v_12 = ovov.OrderByDescending(i => (int)i.Value).Select(i => (int)i.Value).FirstOrDefault();
                var tMVM = tvt.OrderByDescending(i => (int)i.Value).Select(i => (int)i.Value).FirstOrDefault();

                if (o_m_v_12 == 12)
                {
                    var lowCard = ovov.OrderBy(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                    if (lowCard == 0) o_m_v_12 = 3;
                }

                if (tMVM == 12)
                {
                    var lowCard = tvt.OrderBy(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                    if (lowCard == 0) tMVM = 3;
                }

                if (o_m_v_12 > tMVM) return 1;

                if (o_m_v_12 < tMVM) return 2;
            }

            if (ovov.Any(i => i.Count == 4) || tvt.Any(i => i.Count == 4))
            {
                if (ovov.Any(i => i.Count == 4) && tvt.All(i => i.Count != 4)) return 1;

                if (tvt.Any(i => i.Count == 4) && ovov.All(i => i.Count != 4)) return 2;

                var oFKIOD = ovov.Where(i => i.Count == 4).Select(i => (int)i.Value).FirstOrDefault();
                var T_why_Not = tvt.Where(i => i.Count == 4).Select(i => (int)i.Value).FirstOrDefault();

                if (oFKIOD > T_why_Not) return 1;

                if (T_why_Not > oFKIOD) return 2;
            }

            if ((ovov.Any(i => i.Count == 3) && ovov.Any(i => i.Count == 2)) || (tvt.Any(i => i.Count == 3) && tvt.Any(i => i.Count == 2)))
            {
                if ((ovov.Any(i => i.Count == 3) && ovov.Any(i => i.Count == 2)) && !(tvt.Any(i => i.Count == 3) && tvt.Any(i => i.Count == 2))) return 1;

                if (!(ovov.Any(i => i.Count == 3) && ovov.Any(i => i.Count == 2))) return 2;
            }

            if (oF || tF)
            {
                if (oF && !tF) return 1;

                if (!oF) return 2;
            }

            if (oCon || tCon)
            {
                if (oCon && !tCon) return 1;

                if (!oCon) return 2;

                var o9 = ovov.OrderByDescending(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();
                var T2 = tvt.OrderByDescending(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                if (o9 == 12)
                {
                    var lowCard = ovov.OrderBy(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                    if (lowCard == 0) o9 = 3;
                }

                if (T2 == 12)
                {
                    var lowCard = tvt.OrderBy(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                    if (lowCard == 0) T2 = 3;
                }

                if (o9 > T2) return 1;

                if (o9 < T2) return 2;

                return -1;
            }

            if (ovov.Any(i => i.Count == 3) || tvt.Any(i => i.Count == 3))
            {
                var o90 = ovov.Where(i => i.Count == 3).Select(i => i.Value).FirstOrDefault();
                var T3Fv = tvt.Where(i => i.Count == 3).Select(i => i.Value).FirstOrDefault();

                if (o90 > T3Fv) return 1;

                if (T3Fv > o90) return 2;
            }

            if (ovov.Count(i => i.Count == 2) == 2 || tvt.Count(i => i.Count == 2) == 2)
            {
                if (ovov.Count(i => i.Count == 2) == 2 && tvt.Count(i => i.Count == 2) != 2) return 1;

                if (tvt.Count(i => i.Count == 2) == 2 && ovov.Count(i => i.Count == 2) != 2) return 2;

                var o78658 = ovov.Where(i => i.Count == 2).OrderByDescending(i => i.Value).Select(i => i.Value).FirstOrDefault();
                var sIsAfterT = tvt.Where(i => i.Count == 2).OrderByDescending(i => i.Value).Select(i => i.Value).FirstOrDefault();

                if (o78658 > sIsAfterT) return 1;

                if (o78658 < sIsAfterT) return 2;

                ovov = ovov.Where(i => i.Value != o78658).ToList();
                tvt = tvt.Where(i => i.Value != sIsAfterT).ToList();
            }

            if (ovov.Any(i => i.Count == 2) || tvt.Any(i => i.Count == 2))
            {
                if (ovov.Any(i => i.Count == 2) && tvt.All(i => i.Count != 2)) return 1;

                if (ovov.All(i => i.Count != 2) && tvt.Any(i => i.Count == 2)) return 2;

                var o123894_Griffins = ovov.Where(i => i.Count == 2).Select(i => i.Value).FirstOrDefault();
                var t_24_This_IsWrong = tvt.Where(i => i.Count == 2).Select(i => i.Value).FirstOrDefault();

                if (o123894_Griffins > t_24_This_IsWrong) return 1;

                if (o123894_Griffins < t_24_This_IsWrong) return 2;

                o = o.Where(i => i.CardValue != o123894_Griffins).ToList();
                t = t.Where(i => i.CardValue != o123894_Griffins).ToList();

                if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

                if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

                var o873 = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

                o.Remove(o873);

                var ty7 = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

                t.Remove(ty7);

                if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

                if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

                o873 = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

                o.Remove(o873);

                ty7 = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

                t.Remove(ty7);

                if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

                if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;
            }

            if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

            if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

            var o0987_s = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

            o.Remove(o0987_s);

            var t_Valid = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

            t.Remove(t_Valid);

            if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

            if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

            o0987_s = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

            o.Remove(o0987_s);

            t_Valid = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

            t.Remove(t_Valid);

            if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

            if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

            o0987_s = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

            o.Remove(o0987_s);

            t_Valid = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

            t.Remove(t_Valid);

            if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

            if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

            o0987_s = o.FirstOrDefault(j => (int)j.CardValue == o.Max(i => (int)i.CardValue));

            o.Remove(o0987_s);

            t_Valid = t.FirstOrDefault(j => (int)j.CardValue == t.Max(i => (int)i.CardValue));

            t.Remove(t_Valid);

            if (o.Max(i => (int)i.CardValue) > t.Max(i => (int)i.CardValue)) return 1;

            if (o.Max(i => (int)i.CardValue) < t.Max(i => (int)i.CardValue)) return 2;

            return -1;
        }
    }
}