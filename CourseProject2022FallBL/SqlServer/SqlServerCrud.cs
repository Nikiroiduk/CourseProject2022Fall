using CourseProject2022FallBL.Models;
using Microsoft.Data.SqlClient;

using Operation = CourseProject2022FallBL.Models.Operation;
using Action = CourseProject2022FallBL.Models.Action;


namespace CourseProject2022FallBL.SqlServer
{
    internal static class SqlServerCrud
    {
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
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

        internal static bool UpdateUser(User user)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE [User] SET Name = @Name WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@ID", user.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveUser(User user)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM [User] WHERE ID = @ID AND Name = @Name";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@ID", user.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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

        internal static bool UpdateTarget(Target target)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE [Target] SET Name = @Name WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", target.Name);
                command.Parameters.AddWithValue("@ID", target.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveTarget(Target target)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM [Target] WHERE ID = @ID AND Name = @Name";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", target.Name);
                command.Parameters.AddWithValue("@ID", target.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
                var sql = $"SELECT ID, Name, Ratio FROM Currency";
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

        internal static bool UpdateCurrency(Currency currency)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE Currency SET Name = @Name, Ratio = @Ratio WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", currency.Name);
                command.Parameters.AddWithValue("@Ratio", currency.Ratio);
                command.Parameters.AddWithValue("@ID", currency.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveCurrency(Currency currency)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM Currency WHERE ID = @ID AND Name = @Name AND Ratio = @Ratio";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@Name", currency.Name);
                command.Parameters.AddWithValue("@Ratio", currency.Ratio);
                command.Parameters.AddWithValue("@ID", currency.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
                command.Parameters.AddWithValue("@Comment", operation.Comment);

                if (GetCurrencyID(operation.Currency) == 0)
                    AddCurrency(operation.Currency);
                command.Parameters.AddWithValue("@CurrencyID", GetCurrencyID(operation.Currency));

                if (GetTargetID(operation.Target) == 0)
                    AddTarget(operation.Target);
                command.Parameters.AddWithValue("@TargetID", GetTargetID(operation.Target));

                if (GetUserID(operation.User) == 0)
                    AddUser(operation.User);
                command.Parameters.AddWithValue("@UserID", GetUserID(operation.User));
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

        internal static bool UpdateOperation(Operation operation)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE Operation SET Value = @Value, Comment = @Comment, UserID = @UserID, TargetID = @TargetID, CurrencyID = @CurrencyID WHERE ID = @ID";


                using SqlCommand command = new(sql, connection);
                UpdateCurrency(operation.Currency);
                command.Parameters.AddWithValue("@CurrencyID", operation.Currency.ID);
                UpdateTarget(operation.Target);
                command.Parameters.AddWithValue("@TargetID", operation.Target.ID);
                UpdateUser(operation.User);
                command.Parameters.AddWithValue("@UserID", operation.User.ID);
                command.Parameters.AddWithValue("@Value", operation.Value);
                command.Parameters.AddWithValue("@Comment", operation.Comment);
                command.Parameters.AddWithValue("@ID", operation.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveOperation(Operation operation)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM Operation WHERE ID = @ID AND Value = @Value " +
                    "AND Comment = @Comment AND UserID = @UserID AND TargetID = @TargetID " +
                    "AND CurrencyID = @CurrencyID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", operation.ID);
                command.Parameters.AddWithValue("@Value", operation.Value);
                command.Parameters.AddWithValue("@Comment", operation.Comment);
                command.Parameters.AddWithValue("@UserID", operation.User.ID);
                command.Parameters.AddWithValue("@TargetID", operation.Target.ID);
                command.Parameters.AddWithValue("@CurrencyID", operation.Currency.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Income

        public static bool AddIncome(Income income)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = $"INSERT INTO Income (OperationID) VALUES (@OperationID)";
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

        internal static bool UpdateIncome(Income income)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE Income SET OperationID = @OperationID WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                UpdateOperation(income.Operation);
                command.Parameters.AddWithValue("@OperationID", income.Operation.ID);
                command.Parameters.AddWithValue("@ID", income.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveIncome(Income income)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM Income WHERE ID = @ID AND OperationID = @OperationID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@OperationID", income.Operation.ID);
                command.Parameters.AddWithValue("@ID", income.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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

        internal static bool UpdateExpense(Expense expense)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "UPDATE Expense SET OperationID = @OperationID WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                UpdateOperation(expense.Operation);
                command.Parameters.AddWithValue("@OperationID", expense.Operation.ID);
                command.Parameters.AddWithValue("@ID", expense.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static bool RemoveExpense(Expense expense)
        {
            try
            {
                using SqlConnection connection = new(builder.ConnectionString);
                var sql = "DELETE FROM Expense WHERE ID = @ID AND OperationID = @OperationID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@OperationID", expense.Operation.ID);
                command.Parameters.AddWithValue("@ID", expense.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Action

        internal static List<Action> GetActions()
        {
            var res = new List<Action>();
            try
            {
                res.AddRange(GetIncomes());
                res.AddRange(GetExpenses());
            }
            catch (Exception)
            {
                return new List<Action>();
            }
            return res;
        }

        #endregion
    }
}
