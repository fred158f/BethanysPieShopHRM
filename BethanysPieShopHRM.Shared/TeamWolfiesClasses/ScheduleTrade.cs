using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.TeamWolfiesClasses
{
    public class ScheduleTrade
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string TradeStatus { get; set; }
    }
}
