using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecords
{
    internal class RowTablePushUps : RowTable
    {
        public int Number { get; }
        public double? ExtraWeight { get; }
        public TimeSpan? Time { get; }
        public DateTime Date { get; }

        public RowTablePushUps(int userId, int nubmer, double? extraWeight, TimeSpan? time, DateTime date)
        {
            _userId = userId;
            Number = nubmer;
            ExtraWeight = extraWeight;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.PushUps; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
