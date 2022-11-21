using CourseProject2022FallBL.Models;
using Microsoft.Data.SqlClient;

using Operation = CourseProject2022FallBL.Models.Operation;

namespace CourseProject2022FallBL
{
    internal static class SqlServerCrud
    {
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder{ 
            DataSource = "DESKTOP-9922B5A", 
            InitialCatalog = "Finances", 
            IntegratedSecurity = true, 
            Encrypt = false, 
        };

        #region User

        internal static bool AddUser(User user)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO [User] (Name) VALUES (@Name)";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static User GetUser(int ID)
        {
            var res = new User();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name FROM [User] WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new User { ID = (int)reader.GetValue(0), Name = reader.GetString(1) };
                }
            }
            catch (Exception)
            {
                return new User();
            }
            return res;
        }

        internal static List<User> GetUsers()
        {
            var res = new List<User>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name FROM [User]";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new User { ID = (int)reader.GetValue(0), Name = reader.GetString(1) });
                }
            }
            catch (Exception)
            {
                return new List<User>();
            }
            return res;
        }

        internal static int GetUserID(User user)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM [User] WHERE Name = @Name;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion

        #region Target

        internal static bool AddTarget(Target target)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Target (Name) VALUES (@Name)";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", target.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static Target GetTarget(int ID)
        {
            var res = new Target();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name FROM Target WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new Target { ID = (int)reader.GetValue(0), Name = reader.GetString(1) };
                }
            }
            catch (Exception)
            {
                return new Target();
            }
            return res;
        }

        internal static List<Target> GetTargets()
        {
            var res = new List<Target>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name FROM Target";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Target { ID = (int)reader.GetValue(0), Name = reader.GetString(1) });
                }
            }
            catch (Exception)
            {
                return new List<Target>();
            }
            return res;
        }

        internal static int GetTargetID(Target target)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM Target WHERE Name = @Name;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", target.Name);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion

        #region Currency

        internal static bool AddCurrency(Currency currency)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Currency (Name, Ratio) VALUES (@Name, @Ratio)";
                using SqlCommand command = new(sql, connection);
                // TODO: Name should be 3 or less symbols length
                command.Parameters.AddWithValue("@Name", currency.Name.ToUpper());
                command.Parameters.AddWithValue("@Ratio", currency.Ratio);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static Currency GetCurrency(int ID)
        {
            var res = new Currency();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name, Ratio FROM Currency WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new Currency { ID = (int)reader.GetValue(0), Name = reader.GetString(1), Ratio = (float)reader.GetValue(2) };
                }
            }
            catch (Exception)
            {
                return new Currency();
            }
            return res;
        }

        internal static List<Currency> GetCurrencies()
        {
            var res = new List<Currency>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Name FROM Currency";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Currency { ID = (int)reader.GetValue(0), Name = reader.GetString(1), Ratio = (float)reader.GetValue(2) });
                }
            }
            catch (Exception)
            {
                return new List<Currency>();
            }
            return res;
        }

        internal static int GetCurrencyID(Currency currency)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM Currency WHERE Name = @Name AND Ratio = @Ratio;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", currency.Name.ToUpper());
                command.Parameters.AddWithValue("@Ratio", currency.Ratio);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion

        #region Operation

        public static bool AddOperation(Operation operation)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Operation (Value, CurrencyID, TargetID, UserID, Comment)" +
                           "VALUES (@Value, @CurrencyID, @TargetID, @UserID, @Comment)";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Value", operation.Value);

                if (GetCurrencyID(operation.Currency) == 0)
                    AddCurrency(operation.Currency);
                command.Parameters.AddWithValue("@CurrencyID", GetCurrencyID(operation.Currency));

                if (GetTargetID(operation.Target) == 0)
                    AddTarget(operation.Target);
                command.Parameters.AddWithValue("@TargetID", GetTargetID(operation.Target));

                if (GetUserID(operation.User) == 0)
                    AddUser(operation.User);
                command.Parameters.AddWithValue("@UserID", GetUserID(operation.User));
                command.Parameters.AddWithValue("@Comment", operation.Comment);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static Operation GetOperation(int ID)
        {
            var res = new Operation();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Value, CurrencyID, TargetID, UserID, Comment FROM Operation WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new Operation
                    {
                        ID = (int)reader.GetValue(0),
                        Value = (float)reader.GetValue(1),
                        Currency = GetCurrency((int)reader.GetValue(2)),
                        Target = GetTarget((int)reader.GetValue(3)),
                        User = GetUser((int)reader.GetValue(4)),
                        Comment = reader.GetString(5),
                    };
                }
            }
            catch (Exception)
            {
                return new Operation();
            }
            return res;
        }

        internal static List<Operation> GetOperations()
        {
            var res = new List<Operation>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, Value, CurrencyID, TargetID, UserID, Comment FROM Operation";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Operation
                    {
                        ID = (int)reader.GetValue(0),
                        Value = (float)reader.GetValue(1),
                        Currency = GetCurrency((int)reader.GetValue(2)),
                        Target = GetTarget((int)reader.GetValue(3)),
                        User = GetUser((int)reader.GetValue(4)),
                        Comment = reader.GetString(5),
                    });
                }
            }
            catch (Exception)
            {
                return new List<Operation>();
            }
            return res;
        }

        internal static int GetOperationID(Operation operation)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM Operation WHERE Value = @Value AND Comment = @Comment AND CurrencyID = @CurrencyID AND UserID = @UserID AND TargetID = @TargetID;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Value", operation.Value);
                command.Parameters.AddWithValue("@Comment", operation.Comment);
                command.Parameters.AddWithValue("@CurrencyID", operation.Currency.ID);
                command.Parameters.AddWithValue("@UserID", operation.User.ID);
                command.Parameters.AddWithValue("@TargetID", operation.Target.ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion

        #region Income

        public static bool AddIncome(Income income)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Income (OperationID)" +
                           "VALUES (@OperationID)";
                using SqlCommand command = new(sql, connection);
                if (GetOperationID(income.Operation) == 0)
                    AddOperation(income.Operation);
                command.Parameters.AddWithValue("@OperationID", GetOperationID(income.Operation));
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static Income GetIncome(int ID)
        {
            var res = new Income();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, OperationID FROM Income WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new Income { ID = (int)reader.GetValue(0), Operation = GetOperation((int)reader.GetValue(1)) };
                }
            }
            catch (Exception)
            {
                return new Income();
            }
            return res;
        }

        internal static List<Income> GetIncomes()
        {
            var res = new List<Income>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, OperationID FROM Income";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Income { ID = (int)reader.GetValue(0), Operation = GetOperation((int)reader.GetValue(1)) });
                }
            }
            catch (Exception)
            {
                return new List<Income>();
            }
            return res;
        }

        internal static int GetIncomeID(Income income)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM Income WHERE OperationID = @OperationID;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@OperationID", income.Operation.ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion

        #region Expense

        public static bool AddExpense(Expense expense)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Expense (OperationID)" +
                           "VALUES (@OperationID)";
                using SqlCommand command = new(sql, connection);
                if (GetOperationID(expense.Operation) == 0)
                    AddOperation(expense.Operation);
                command.Parameters.AddWithValue("@OperationID", GetOperationID(expense.Operation));
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static Expense GetExpense(int ID)
        {
            var res = new Expense();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, OperationID FROM Expense WHERE ID = @ID";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new Expense { ID = (int)reader.GetValue(0), Operation = GetOperation((int)reader.GetValue(1)) };
                }
            }
            catch (Exception)
            {
                return new Expense();
            }
            return res;
        }

        internal static List<Expense> GetExpenses()
        {
            var res = new List<Expense>();
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID, OperationID FROM Expense";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Expense { ID = (int)reader.GetValue(0), Operation = GetOperation((int)reader.GetValue(1)) });
                }
            }
            catch (Exception)
            {
                return new List<Expense>();
            }
            return res;
        }

        internal static int GetExpenseID(Expense expense)
        {
            var res = 0;
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"SELECT ID FROM Expense WHERE OperationID = @OperationID;";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@OperationID", expense.Operation.ID);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = (int)reader.GetValue(0);
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        #endregion
    }
}
