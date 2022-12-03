using CourseProject2022FallBL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.SqlServer
{
    internal static class SqlServerActions
    {
        internal static List<Operation> GetIncomeExpenseDataByUser(User user, bool isIncome)
        {
            var res = new List<Operation>();
            try
            {
                using SqlConnection connection = new(SqlServerCrud.builder.ConnectionString);
                var sql = $"SELECT Operation.TargetID, Operation.[Value], Operation.CurrencyID, Operation.UserID, Operation.Comment, Operation.ID " +
                    $"FROM " + (isIncome ? "Income" : "Expense") + " INNER JOIN Operation " +
                    $"ON " + (isIncome ? "Income" : "Expense") + ".OperationID = Operation.ID " +
                    $"WHERE UserID = @UserID " +
                    $"ORDER BY Operation.TargetID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@UserID", user.ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Operation
                    {
                        Target = SqlServerCrud.GetTarget((int)reader.GetValue(0)),
                        Value = (float)reader.GetValue(1),
                        Currency = SqlServerCrud.GetCurrency((int)reader.GetValue(2)),
                        User = SqlServerCrud.GetUser((int)reader.GetValue(3)),
                        Comment = reader.GetString(4),
                        ID = (int)reader.GetValue(5),
                    }) ;
                }
            }
            catch (Exception)
            {
                return new List<Operation>();
            }
            return res;
        }

        internal static List<Operation> GetIncomeExpenseDataByTarget(Target target, bool isIncome)
        {
            var res = new List<Operation>();
            try
            {
                using SqlConnection connection = new(SqlServerCrud.builder.ConnectionString);
                var sql = $"SELECT Operation.TargetID, Operation.[Value], Operation.CurrencyID, Operation.UserID, Operation.Comment, Operation.ID " +
                    $"FROM " + (isIncome ? "Income" : "Expense") + " INNER JOIN Operation " +
                    $"ON " + (isIncome ? "Income" : "Expense") + ".OperationID = Operation.ID " +
                    $"WHERE TargetID = @TargetID " +
                    $"ORDER BY Operation.TargetID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@TargetID", target.ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Operation
                    {
                        Target = SqlServerCrud.GetTarget((int)reader.GetValue(0)),
                        Value = (float)reader.GetValue(1),
                        Currency = SqlServerCrud.GetCurrency((int)reader.GetValue(2)),
                        User = SqlServerCrud.GetUser((int)reader.GetValue(3)),
                        Comment = reader.GetString(4),
                        ID = (int)reader.GetValue(5),
                    });
                }
            }
            catch (Exception)
            {
                return new List<Operation>();
            }
            return res;
        }

        internal static List<Operation> GetIncomeExpenseDataByCurrency(bool isIncome)
        {
            var res = new List<Operation>();
            try
            {
                using SqlConnection connection = new(SqlServerCrud.builder.ConnectionString);
                var sql = $"SELECT Operation.TargetID, Operation.[Value], Operation.CurrencyID, Operation.UserID, Operation.Comment, Operation.ID " +
                    $"FROM " + (isIncome ? "Income" : "Expense") + " INNER JOIN Operation " +
                    $"ON " + (isIncome ? "Income" : "Expense") + ".OperationID = Operation.ID " +
                    "ORDER BY Operation.CurrencyID";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Operation
                    {
                        Target = SqlServerCrud.GetTarget((int)reader.GetValue(0)),
                        Value = (float)reader.GetValue(1),
                        Currency = SqlServerCrud.GetCurrency((int)reader.GetValue(2)),
                        User = SqlServerCrud.GetUser((int)reader.GetValue(3)),
                        Comment = reader.GetString(4),
                        ID = (int)reader.GetValue(5),
                    });
                }
            }
            catch (Exception)
            {
                return new List<Operation>();
            }
            return res;
        }
    }
}
