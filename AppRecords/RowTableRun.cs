using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecords
{
    public class RowTableRun : RowTable
    {
        public double Distance { get; }
        public TimeSpan Time { get; }
        public DateTime Date { get; }

        public RowTableRun(int userId, double distance, TimeSpan time, DateTime date)
        {
            _userId = userId;
            Distance = distance;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.Run; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
