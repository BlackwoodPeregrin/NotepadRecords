using System;
using System.Collections.Generic;
using Npgsql;

namespace AppRecords
{
    internal class DBExecutor
    {
        private DBConnector connector = new DBConnector();

        public DBExecutor()
        {
            connector.open();
        }

        ~DBExecutor()
        {
            connector.close();
        }

        public int? SelectUser(string username, string pswd)
        {
            string sql = string.Format(
                "SELECT id FROM {0} WHERE username = '{1}' AND pswd = '{2}'",
                this.TableTypeAsString(TableType.Users),
                username,
                pswd
            );
            using (var cmd = new NpgsqlCommand(sql, connector.connection())) {
                using (var rd = cmd.ExecuteReader()) {
                    int idx = 0;
                    while (rd.Read()) {
                        return rd.GetInt32(idx);
                    }
                }
            }
            return null;
        }

        public List<RowTableRun> SelectFromTableRun(int userId)
        {
            var sql = string.Format(
                "SELECT distance, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.Run),
                userId
            );

            var result = new List<RowTableRun>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableRun(
                            userId,
                            rd.GetDouble(idx++),
                            rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableSwim> SelectFromTableSwim(int userId)
        {
            var sql = string.Format(
                "SELECT distance, m_time, m_date FROM {0} WHERE user_id = {1}", 
                TableTypeAsString(TableType.Swim), 
                userId
            );

            var result = new List<RowTableSwim>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection())) {
                using (var rd = cmd.ExecuteReader()) {
                    while (rd.Read()) {
                        int idx = 0;
                        result.Add(new RowTableSwim(
                            userId,
                            rd.GetDouble(idx++),
                            rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTablePlanka> SelectFromTablePlanka(int userId)
        {
            var sql = string.Format(
                "SELECT m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.Planka),
                userId
            );

            var result = new List<RowTablePlanka>();
            
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTablePlanka(
                            userId,
                            rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTablePullUps> SelectFromTablePullUps(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, extra_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.PullUps),
                userId
            );
            
            var result = new List<RowTablePullUps>();
            
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTablePullUps(
                            userId,
                            rd.GetInt32(idx++),
                            rd.IsDBNull(idx) ? null : (double?)rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTablePushUps> SelectFromTablePushUps(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, extra_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.PushUps),
                userId
            );

            var result = new List<RowTablePushUps>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTablePushUps(
                            userId,
                            rd.GetInt32(idx++),
                            rd.IsDBNull(idx) ? null : (double?)rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableDips> SelectFromTableDips(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, extra_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.Dips),
                userId
            );

            var result = new List<RowTableDips>();
            
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableDips(
                             userId,
                             rd.GetInt32(idx++),
                             rd.IsDBNull(idx) ? null : (double?)rd.GetDouble(idx++),
                             rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                             rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableMuscleUps> SelectFromTableMuscleUps(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, extra_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.MuscleUps),
                userId
            );

            var result = new List<RowTableMuscleUps>();
            
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableMuscleUps(
                             userId,
                             rd.GetInt32(idx++),
                             rd.IsDBNull(idx) ? null : (double?)rd.GetDouble(idx++),
                             rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                             rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableBenchPress> SelectFromTableBenchPress(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, rod_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.BenchPress),
                userId
            );

            var result = new List<RowTableBenchPress>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableBenchPress(
                                userId,
                                rd.GetInt32(idx++),
                                rd.GetDouble(idx++),
                                rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                                rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableBackSquats> SelectFromTableBackSquats(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, rod_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.BackSquats),
                userId
            );

            var result = new List<RowTableBackSquats>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableBackSquats(
                            userId,
                            rd.GetInt32(idx++),
                            rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableDeadlifts> SelectFromTableDeadlifts(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, rod_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.Deadlifts),
                userId
            );

            var result = new List<RowTableDeadlifts>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableDeadlifts(
                            userId,
                            rd.GetInt32(idx++),
                            rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableBicepCurls> SelectFromTableBicepCurls(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, rod_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.BicepCurls),
                userId
            );

            var result = new List<RowTableBicepCurls>();
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableBicepCurls(
                            userId,
                            rd.GetInt32(idx++),
                            rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public List<RowTableOverheadPress> SelectFromTableOverheadPress(int userId)
        {
            var sql = string.Format(
                "SELECT m_number, rod_weight, m_time, m_date FROM {0} WHERE user_id = {1}",
                TableTypeAsString(TableType.OverheadPress),
                userId
            );

            var result = new List<RowTableOverheadPress>();

            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int idx = 0;
                        result.Add(new RowTableOverheadPress(
                            userId,
                            rd.GetInt32(idx++),
                            rd.GetDouble(idx++),
                            rd.IsDBNull(idx) ? null : (TimeSpan?)rd.GetTimeSpan(idx++),
                            rd.GetDateTime(idx)
                        ));
                    }
                }
            }
            return result;
        }

        public bool InsertUser(string username, string pswd)
        {
            var sql = string.Format("SELECT insert_user('{0}', '{1}');", username, pswd);
            using (var cmd = new NpgsqlCommand(sql, connector.connection())) {
                using (var rd = cmd.ExecuteReader()) {
                    int idx = 0;
                    while (rd.Read()) {
                        return rd.GetBoolean(idx);
                    }
                }
            }
            return false;
        }

        public int InsertIntoTableRun(int userId, double distance, TimeSpan time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, distance, m_time, m_date) VALUES({1}, {2}, '{3}', '{4}');",
                TableTypeAsString(TableType.Run),
                userId,
                distance,
                time.ToString(@"hh\:mm\:ss"),
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableRun(RowTableRun row)
        {
            return InsertIntoTableRun(row.UserId(), row.Distance, row.Time, row.Date);
        }

        public int InsertIntoTableSwim(int userId, double distance, TimeSpan time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, distance, m_time, m_date) VALUES({1}, {2}, '{3}', '{4}');",
                TableTypeAsString(TableType.Swim),
                userId,
                distance,
                time.ToString(@"hh\:mm\:ss"),
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableSwim(RowTableSwim row)
        {
            return InsertIntoTableSwim(row.UserId(), row.Distance, row.Time, row.Date);
        }

        public int InsertIntoTablePlanka(int userId, TimeSpan time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_time, m_date) VALUES({1}, '{2}', '{3}');",
                TableTypeAsString(TableType.Planka),
                userId,
                time.ToString(@"hh\:mm\:ss"),
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTablePlanka(RowTablePlanka row)
        {
            return InsertIntoTablePlanka(row.UserId(), row.Time, row.Date);
        }

        public int InsertIntoTablePullUps(int userId, int number, double? extraWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.PullUps),
                userId,
                number,
                extraWeight ?? null,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTablePullUps(RowTablePullUps row)
        {
            return InsertIntoTablePullUps(row.UserId(), row.Number, row.ExtraWeight, row.Time, row.Date);
        }

        public int InsertIntoTablePushUps(int userId, int number, double? extraWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.PushUps),
                userId,
                number,
                extraWeight ?? null,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTablePushUps(RowTablePushUps row)
        {
            return InsertIntoTablePushUps(row.UserId(), row.Number, row.ExtraWeight, row.Time, row.Date);
        }

        public int InsertIntoTableDips(int userId, int number, double? extraWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.Dips),
                userId,
                number,
                extraWeight ?? null,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableDips(RowTableDips row)
        {
            return InsertIntoTableDips(row.UserId(), row.Number, row.ExtraWeight, row.Time, row.Date);
        }

        public int InsertIntoTableMuscleUps(int userId, int number, double? extraWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.MuscleUps),
                userId,
                number,
                extraWeight ?? null,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableMuscleUps(RowTableMuscleUps row)
        {
            return InsertIntoTableMuscleUps(row.UserId(), row.Number, row.ExtraWeight, row.Time, row.Date);
        }

        public int InsertIntoTableBenchPress(int userId, int number, double rodWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.BenchPress),
                userId,
                number,
                rodWeight,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableBenchPress(RowTableBenchPress row)
        {
            return InsertIntoTableBenchPress(row.UserId(), row.Number, row.RodWeight, row.Time, row.Date);
        }

        public int InsertIntoTableBackSquats(int userId, int number, double rodWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.BackSquats),
                userId,
                number,
                rodWeight,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableBackSquats(RowTableBackSquats row)
        {
            return InsertIntoTableBackSquats(row.UserId(), row.Number, row.RodWeight, row.Time, row.Date);
        }

        public int InsertIntoTableDeadlifts(int userId, int number, double rodWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.Deadlifts),
                userId,
                number,
                rodWeight,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableDeadlifts(RowTableDeadlifts row)
        {
            return InsertIntoTableDeadlifts(row.UserId(), row.Number, row.RodWeight, row.Time, row.Date);
        }

        public int InsertIntoTableBicepCurls(int userId, int number, double rodWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.BicepCurls),
                userId,
                number,
                rodWeight,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableBicepCurls(RowTableBicepCurls row)
        {
            return InsertIntoTableBicepCurls(row.UserId(), row.Number, row.RodWeight, row.Time, row.Date);
        }

        public int InsertIntoTableOverheadPress(int userId, int number, double rodWeight, TimeSpan? time, DateTime date)
        {
            var sql = string.Format(
                "INSERT INTO {0}(user_id, m_number, extra_weight, m_time, m_date) VALUES({1}, {2}, {3}, '{4}', '{5}');",
                TableTypeAsString(TableType.OverheadPress),
                userId,
                number,
                rodWeight,
                time?.ToString(@"hh\:mm\:ss") ?? null,
                date.ToString("yyyy-MM-dd")
            );
            return ExecuteNonQuerySql(sql);
        }

        public int InsertIntoTableOverheadPress(RowTableOverheadPress row)
        {
            return InsertIntoTableOverheadPress(row.UserId(), row.Number, row.RodWeight, row.Time, row.Date);
        }

        private string TableTypeAsString(TableType name)
        {
            switch (name)
            {
                case TableType.Users:
                    return "users";
                case TableType.Run:
                    return "run";
                case TableType.Swim:
                    return "swim";
                case TableType.Planka:
                    return "planka";
                case TableType.PullUps:
                    return "pull_ups";
                case TableType.PushUps:
                    return "push_ups";
                case TableType.Dips:
                    return "dips";
                case TableType.MuscleUps:
                    return "muscle_ups";
                case TableType.BenchPress:
                    return "bench_press";
                case TableType.BackSquats:
                    return "back_squats";
                case TableType.Deadlifts:
                    return "deadlifts";
                case TableType.BicepCurls:
                    return "bicep_curls";
                case TableType.OverheadPress:
                    return "overhead_press";
            }
            throw new ArgumentException("Incorrect type table name to convert string");
        }

        private int ExecuteNonQuerySql(string sql)
        {
            using (var cmd = new NpgsqlCommand(sql, connector.connection()))
            {
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

