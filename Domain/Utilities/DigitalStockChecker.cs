using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public class DigitalStockChecker : IStockChecker
    {
        public int GetStock() => int.MaxValue;
    }
}
