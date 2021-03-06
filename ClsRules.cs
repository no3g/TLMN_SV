﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ClsRules
    {
        public static void sort(List<ClsCard> Card)
        {
            for (int i=0; i<Card.Count-1; i++)
                for (int j=i+1; j<Card.Count; j++)
                    if (Card[j]<Card[i])
                    {
                        ClsCard t= new ClsCard(0,0);
                        t.setCard(Card[i]);
                        Card[i].setCard(Card[j]);
                        Card[j].setCard(t);
                    }
        }
        public static bool isSingleCardWin(ClsCard Card1, ClsCard Card2)
        {
            if (Card1 < Card2) return true;
            return false;
        }
        public static bool isDouble(List<ClsCard> Card)
        {
            if (Card.Count != 2) return false;
            if (Card[0].getvalue() == Card[1].getvalue()) return true;
            return false;
        }
        public static bool Is3Equal(List<ClsCard> Card)
        {
            if (Card.Count != 3) return false;
            if (Card[0].getvalue() == Card[1].getvalue() && Card[2].getvalue() == Card[1].getvalue()) return true;
            return false;
        }
        public static bool Is4Equal(List<ClsCard> Card)
        {
            if (Card.Count != 4) return false;
            if (Card[0].getvalue() == Card[1].getvalue() && Card[2].getvalue() == Card[1].getvalue() && Card[2].getvalue() == Card[3].getvalue()) return true;
            return false;
        }
        public static bool IsOrder(List<ClsCard> Card)
        {
            if (Card.Count < 3 || Card[Card.Count - 1].value == 12) return false;
            for (int i = 0; i < Card.Count - 1; i++)
                if (Card[i].getvalue() != Card[i + 1].getvalue() - 1) return false;
            return true;
        }
        public static bool isTrue(List<ClsCard> Card)
        {
            if (Card.Count == 1 || isDouble(Card) || Is3Equal(Card) || Is4Equal(Card) || IsOrder(Card) || IsDoubleOrder(Card) != -1) return true;
            return false;
        }
        public static int IsDoubleOrder(List<ClsCard> Card)
        {
            if (Card.Count < 6 || Card.Count % 2 == 1 || Card[Card.Count - 1].value == 12) return -1;
            for (int i = 0; i < Card.Count / 2 - 2; i++)
                if (Card[2 * i].getvalue() != Card[2 * i + 2].getvalue() - 1) return -1;
            for (int i = 0; i < Card.Count / 2 - 1; i++)
                if (Card[i * 2].value != Card[i * 2 + 1].value) return -1;
            return Card.Count / 2;
        }
        public static bool IsWin(List<ClsCard> Card1, List<ClsCard> Card2)
        {
            sort(Card1);
            sort(Card2);
            if ((Card1.Count==0)&&(Card2.Count==1||isDouble(Card2)||Is3Equal(Card2)||Is4Equal(Card2)||IsOrder(Card2)||IsDoubleOrder(Card2) != -1)) return true;
            if (isDouble(Card1))
            {
                if (Card1[0].value == 12 && (Is4Equal(Card2) || IsDoubleOrder(Card2) == 4)) return true;
                if (!isDouble(Card2)) return false;
                if (Card2[1] < Card1[1]) return false;
                return true;
            }
            if (Is3Equal(Card1))
            {
                if (!Is3Equal(Card2)) return false;
                if (Card2[2] < Card1[2]) return false;
                return true;
            }
            if (Is4Equal(Card1))
            {
                if (Card1[0].value != 12 && IsDoubleOrder(Card2) == 4) return true;
                if (!Is4Equal(Card2)) return false;
                if (Card2[3] < Card1[3]) return false;
                return true;
            }
            if (IsOrder(Card1))
            {
                if (!IsOrder(Card2)||Card1.Count!=Card2.Count) return false;
                if (Card2[Card2.Count - 1] < Card1[Card1.Count - 1]) return false;
                return true;
            }
            if (IsDoubleOrder(Card1) == 3)
            {
                if (IsDoubleOrder(Card2) == 4) return true;
                if (IsDoubleOrder(Card2) != 3) return false;
                if (Card2[5] < Card1[5]) return false;
                return true;
            }
            if (IsDoubleOrder(Card1) == 4)
            {
                if (IsDoubleOrder(Card2) != 4) return false;
                if (Card2[7] < Card1[7]) return false;
                return true;
            }
            if (Card1.Count == 1 && (Is4Equal(Card2) || IsDoubleOrder(Card2) != -1)) return true;
            if (Card1.Count == 1 && Card2.Count == 1 && isSingleCardWin(Card1[0], Card2[0])) return true;
            return false;
        }
    }
}
