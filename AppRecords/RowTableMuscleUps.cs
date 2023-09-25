using System;

namespace AppRecords
{
    internal class RowTableMuscleUps : RowTable
    {
        public int Number { get; }
        public double? ExtraWeight { get; }
        public TimeSpan? Time { get; }
        public DateTime Date { get; }

        public RowTableMuscleUps(int userId, int nubmer, double? extraWeight, TimeSpan? time, DateTime date)
        {
            _userId = userId;
            Number = nubmer;
            ExtraWeight = extraWeight;
            Time = time;
            Date = date;
        }

        public override TableType Type() { return TableType.MuscleUps; }
        public override int UserId() { return _userId; }

        private int _userId;
    }
}
