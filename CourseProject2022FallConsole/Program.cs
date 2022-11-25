
using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;

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



Console.WriteLine(DataService.UpsertIncome(new Income
{
    Operation = new Operation
    {
        Value = 1489,
        Comment = "value",
        User = new User { ID = 1, Name = "Niki" },
        Target = new Target { ID = 26, Name = "Drugs" },
        Currency = new Currency { ID = 6, Name = "rub", Ratio = 0.017f }
    }
}));