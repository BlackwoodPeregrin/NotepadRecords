using System;

namespace AppRecords
{
    internal class RowTablePlanka : RowTable
    {
        public TimeSpan Time { get; }
        public DateTime Date { get; }

        public RowTablePlanka(int userId, TimeSpan time, DateTime date)
        {
            _userId = userId;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.Planka; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
