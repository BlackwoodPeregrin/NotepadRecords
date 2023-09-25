using System;

namespace AppRecords
{
    internal class RowTableSwim : RowTable
    {
        public double Distance { get; }
        public TimeSpan Time { get; }
        public DateTime Date { get; }

        public RowTableSwim(int userId, double distance, TimeSpan time, DateTime date)
        {
            _userId = userId;
            Distance = distance;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.Swim; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
