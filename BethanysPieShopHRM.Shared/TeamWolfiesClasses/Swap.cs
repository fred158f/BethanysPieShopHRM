using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.TeamWolfiesClasses
{
    public class Swap
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int SwapStatusInt { get; set; }
        public SwapStatus SwapStatus { get; set; }
    }


    public enum SwapStatus
    {
        Pending,
        Accepted,
        Refused
    }
}
