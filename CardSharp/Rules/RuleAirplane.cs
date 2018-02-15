﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSharp.Rules
{
    public class RuleAirplane : RuleBase
    {
        public override bool IsMatch(List<CardGroup> cards, List<CardGroup> lastCards)
        {
            var first = cards.First();
            if (lastCards != null) {
                if (cards.Count != lastCards.Count) // 与之前张数必须相同
                    return false;
                if (first.Amount <= lastCards.First().Amount) // 必须比前面的大
                    return false;
            }

            for (var index = first.Amount; index < cards.Count + first.Amount; index++) {
                var cardGroup = cards[index- first.Amount];
                if (cardGroup.Count != 3) // 必须只有3张
                    return false;
                if (index != cardGroup.Amount) // 必须连起来
                    return false;
                if (index == Constants.Cards.C2) // 不能是2
                    return false;
            }

            if (cards.Count < 2)
                return false; // 必须大于等于两组

            return true;
        }

        public override string ToString(List<CardGroup> cards)
        {
            return "飞机";
        }
    }
}