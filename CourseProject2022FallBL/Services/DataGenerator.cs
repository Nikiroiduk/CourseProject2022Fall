using Bogus;
using CourseProject2022FallBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.Services
{
    public static class DataGenerator
    {
        private static string[] categories = { "Food", "Social Life", "Self-development", "Transportation", "Culture", "Household", "Apparel", "Beaty", "Health", "Education", "Gift", "Other" };
        private static string[] comments = 
        {
            "I want to learn this kind of playfulness! Teach me.",
            "Good. So sleek.",
            "It's simple not just sleek!",
            "Just killer m8",
            "Blur, gradient, texture, shot – killer m8",
            "Please stop!",
            "Designgasmed all over this!",
            "Very strong illustration, friend.",
            "Let me take a nap... great shot, anyway.",
            "Super thought out! Jesus Christ. How do you do it?",
            "Engaging. It keeps your mind occupied while you wait.",
            "Nice use of red in this shot."
        };
        
        public static Faker<User> testUsers = new Faker<User>().RuleFor(u => u.Name, (f, u) => f.Name.FirstName());
        public static Faker<Target> testTargets = new Faker<Target>().RuleFor(t => t.Name, f => f.PickRandom(categories));
        public static List<Currency> testCurrencies = new() 
        { 
            new Currency() { Name = "RUB", Ratio = 0.017f },
            new Currency() { Name = "UAH", Ratio = 0.027f },
            new Currency() { Name = "USD", Ratio = 1f },
            new Currency() { Name = "EUR", Ratio = 1.03f },
            new Currency() { Name = "AZN", Ratio = 0.58f },
            new Currency() { Name = "GBP", Ratio = 1.20f },
        };
        public static Faker<Operation> testOperations = new Faker<Operation>()
            .RuleFor(o => o.Comment, f => f.PickRandom(comments))
            .RuleFor(o => o.Value, f => f.Random.Float(10, 3000))
            .RuleFor(o => o.User, f => f.PickRandom(testUsers))
            .RuleFor(o => o.Target, f => f.PickRandom(testTargets))
            .RuleFor(o => o.Currency, f => f.PickRandom(testCurrencies));
        public static Faker<Income> testIncomes = new Faker<Income>()
            .RuleFor(i => i.Operation, f => f.PickRandom(testOperations));
        public static Faker<Expense> testExpenses = new Faker<Expense>()
            .RuleFor(i => i.Operation, f => f.PickRandom(testOperations));
    }
}
