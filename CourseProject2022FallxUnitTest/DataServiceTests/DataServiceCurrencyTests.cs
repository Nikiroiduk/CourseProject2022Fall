using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallxUnitTest.DataServiceTests
{
    public class DataServiceCurrencyTests : IClassFixture<DatabaseFixtureCurrency>
    {
        DatabaseFixtureCurrency fixture;
        public DataServiceCurrencyTests(DatabaseFixtureCurrency fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddCurrency_True_CorrectCurrency()
        {
            Assert.True(fixture.AddCurrency(new Currency { Name = "tst", Ratio = 1f }));
        }

        [Fact]
        public void AddCurrency_True_DefaultCurrency()
        {
            Assert.True(fixture.AddCurrency(new Currency()));
        }

        [Fact]
        public void GetCurrency_False()
        {
            var currency = new Currency { Name = "tst", Ratio = 1f };
            fixture.AddCurrency(currency);
            Assert.False(fixture.GetCurrencyID(currency) == 0);
        }

        [Fact]
        public void GetCurrencies_False()
        {
            fixture.AddCurrency(new Currency { Name = "ts1", Ratio = 1f });
            fixture.AddCurrency(new Currency { Name = "ts2", Ratio = 2f });
            Assert.False(fixture.GetCurrencies().IsNullOrEmpty());
        }

        [Fact]
        public void GetCurrencyID_True()
        {
            var currency = new Currency { Name = "ts3" };
            fixture.AddCurrency(currency);
            Assert.True(fixture.GetCurrencyID(currency) != 0);
        }

        [Fact]
        public void UpdateCurrency_True()
        {
            var currency = new Currency { Name = "ts6", Ratio = 1f };
            fixture.AddCurrency(currency);
            currency.ID = fixture.GetCurrencyID(currency);
            currency.Name = "ts9";
            fixture.UpdateCurrency(currency);
            Assert.True(fixture.GetCurrency(currency.ID).Name == currency.Name);
        }

        [Fact]
        public void RemoveCurrency_True()
        {
            var currency = new Currency { Name = "ts8", Ratio = 1f };
            fixture.AddCurrency(currency);
            currency.ID = fixture.GetCurrencyID(currency);
            fixture.RemoveCurrency(currency);
            Assert.True(fixture.GetCurrencyID(currency) == 0);
        }

        [Fact]
        public void RemoveAllDataInCurrencyTable_True()
        {
            fixture.AddCurrency(new Currency { Name = "tss", Ratio = 2f });
            fixture.RemoveAllDataInCurrencyTable();
            Assert.True(fixture.GetCurrencies().IsNullOrEmpty());
        }

        [Fact]
        public void AddCurrencies_True()
        {
            var currencies = new List<Currency> 
            { 
                new Currency { Name = "ttt", Ratio = 3f }, 
                new Currency { Name = "aaa", Ratio = 2f } 
            };
            fixture.AddCurrencies(currencies);
            Assert.True(fixture.GetCurrencies().Count > 0);
        }

        [Fact]
        public void UpsertCurrency_True()
        {
            var currency = new Currency { Name = "zzz", Ratio = 2f };
            fixture.AddCurrency(currency);
            currency.ID = fixture.GetCurrencyID(currency);
            currency.Name = "ppp";
            fixture.UpsertCurrency(currency);
            Assert.True(fixture.GetCurrency(currency.ID).Name == currency.Name);
        }
    }
}
