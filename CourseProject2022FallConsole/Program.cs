
using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;

Console.WriteLine();

//Console.WriteLine(DataService.AddUser(user: new User{ Name = "TestUserName" }));

//Console.WriteLine(DataService.AddTarget(target: new Target { Name = "TargetTestName" }));

//Console.WriteLine(DataService.AddCurrency(currency: new Currency { Name = "Rub", Ratio = 0.017}));


//foreach (var item in DataService.GetUsers())
//{
//    Console.WriteLine(item.Name);
//}

//Console.WriteLine(DataService.GetUserID(new User { Name = "Meh" }));

//Console.WriteLine(DataService.GetCurrencyID(new Currency { Name = "RUB", Ratio = 0.017f } ));

//Console.WriteLine(DataService.AddOperation(new Operation
//{
//    Value = 300,
//    Comment = "Comment",
//    User = new User { Name = "Meh" },
//    Target = new Target { Name = "Food" },
//    Currency = new Currency { Name = "eur", Ratio = 1.03f }
//}));

//Console.WriteLine(DataService.GetOperationID(new Operation
//{
//    Value = 300,
//    Comment = "This is a comment to first added operation",
//    User = new User { ID = 2, Name = "Meh" },
//    Target = new Target { ID = 4, Name = "Food" },
//    Currency = new Currency { ID = 6, Name = "rub", Ratio = 0.017f }
//}));

//Console.WriteLine(DataService.AddIncome(new Income
//{
//    Operation = new Operation
//    {
//        Value = 300,
//        Comment = "This is a comment to first added operation",
//        User = new User { ID = 2, Name = "Meh" },
//        Target = new Target { ID = 4, Name = "Food" },
//        Currency = new Currency { ID = 6, Name = "rub", Ratio = 0.017f }
//    }
//}));

//Console.WriteLine(DataService.GetOperationID(new Operation
//{
//    Value = 300,
//    Comment = "Comment",
//    User = new User { ID = 2, Name = "Meh" },
//    Target = new Target { ID = 4, Name = "Food" },
//    Currency = new Currency { ID = 7, Name = "eur", Ratio = 1.03f }
//}));

//Console.WriteLine(DataService.AddIncome(new Income
//{
//    Operation = new Operation
//    {
//        Value = 300,
//        Comment = "Comment",
//        User = new User { ID = 2, Name = "Meh" },
//        Target = new Target { ID = 4, Name = "Food" },
//        Currency = new Currency { ID = 7, Name = "eur", Ratio = 1.03f }
//    }
//}));

//Console.WriteLine(DataService.UpdateUser(new User { ID = 16, Name = "UpsertUserNewNewer"}));

//Console.WriteLine(DataService.RemoveUser(new User { ID = 16, Name = "UpsertUserNewNewer" }));

//Console.WriteLine(DataService.GetOperationID(new Operation
//{
//    Value = 300,
//    Comment = "Comment",
//    User = new User { Name = "Meh" },
//    Target = new Target { Name = "Food" },
//    Currency = new Currency { Name = "eur", Ratio = 1.03f }
//}));


//Console.WriteLine(DataService.GetIncomeID(new Income
//{
//    Operation = new Operation
//    {
//        ID = 9,
//        Value = 300,
//        Comment = "Comment",
//        User = new User { Name = "Andrey" },
//        Target = new Target { Name = "Food" },
//        Currency = new Currency { Name = "eur", Ratio = 1.03f }
//    }
//}));


//List<User> users = new(DataGenerator.testUsers.GenerateLazy(100));
//List<Target> targets = new(DataGenerator.testTargets.GenerateLazy(100));
//List<Currency> currencies = new(DataGenerator.testCurrencies);
//for (int i = 0; i < 100; i++)
//{
//    Console.WriteLine($"{users[i].Name}\t{targets[i].Name}");
//}

//foreach (var cur in currencies)
//{
//    Console.WriteLine($"{cur.Name} {cur.Ratio}");
//}

//foreach (var operation in new List<Operation>(DataGenerator.testOperations.GenerateLazy(100)))
//{
//    Console.WriteLine($"{operation.Value} {operation.Comment} {operation.User.Name} {operation.Target.Name} {operation.Currency.Name}");
//}

//foreach (var income in new List<Income>(DataGenerator.testIncomes.GenerateLazy(100)))
//{
//    Console.WriteLine($"{income.Operation.Value} {income.Operation.Comment} {income.Operation.User.Name} {income.Operation.Target.Name} {income.Operation.Currency.Name}");
//}

//foreach (var expense in new List<Expense>(DataGenerator.testExpenses.GenerateLazy(100)))
//{
//    Console.WriteLine($"{expense.Operation.Value} {expense.Operation.Comment} {expense.Operation.User.Name} {expense.Operation.Target.Name} {expense.Operation.Currency.Name}");
//}

//DataService.AddUsers(new List<User>(DataGenerator.testUsers.GenerateLazy(100)));

Console.WriteLine(DataService.RemoveAllDataFromTables());

List<Income> incomes = new(DataGenerator.testIncomes.GenerateLazy(100));
//Console.WriteLine(DataService.AddUsers(incomes.Select(u => u.Operation.User).ToList()));
//Console.WriteLine(DataService.AddTargets(incomes.Select(u => u.Operation.Target).ToList()));
//Console.WriteLine(DataService.AddCurrencies(incomes.Select(u => u.Operation.Currency).ToList()));
foreach (var income in incomes)
{
    DataService.UpsertOperation(income.Operation);
    income.Operation.User.ID = DataService.GetUserID(income.Operation.User);
    income.Operation.Target.ID = DataService.GetTargetID(income.Operation.Target);
    income.Operation.Currency.ID = DataService.GetCurrencyID(income.Operation.Currency);
    income.Operation.ID = DataService.GetOperationID(income.Operation);
    DataService.UpsertIncome(income);
    income.ID = DataService.GetIncomeID(income);
}

List<Expense> expenses = new(DataGenerator.testExpenses.GenerateLazy(100));
//Console.WriteLine(DataService.AddUsers(expenses.Select(u => u.Operation.User).ToList()));
//Console.WriteLine(DataService.AddTargets(expenses.Select(u => u.Operation.Target).ToList()));
//Console.WriteLine(DataService.AddCurrencies(expenses.Select(u => u.Operation.Currency).ToList()));
foreach (var expense in expenses)
{
    DataService.UpsertOperation(expense.Operation);
    expense.Operation.User.ID = DataService.GetUserID(expense.Operation.User);
    expense.Operation.Target.ID = DataService.GetTargetID(expense.Operation.Target);
    expense.Operation.Currency.ID = DataService.GetCurrencyID(expense.Operation.Currency);
    expense.Operation.ID = DataService.GetOperationID(expense.Operation);
    DataService.UpsertExpense(expense);
    expense.ID = DataService.GetExpenseID(expense);
}