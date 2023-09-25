using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecords
{
    internal class RowTableBackSquats : RowTable
    {
        public int Number { get; }
        public double RodWeight { get; }
        public TimeSpan? Time { get; }
        public DateTime Date { get; }

        public RowTableBackSquats(int userId, int nubmer, double rodWeight, TimeSpan? time, DateTime date)
        {
            _userId = userId;
            Number = nubmer;
            RodWeight = rodWeight;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.BackSquats; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
