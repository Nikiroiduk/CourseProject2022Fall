using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using Microsoft.IdentityModel.Tokens;

namespace CourseProject2022FallxUnitTest.DataServiceTests
{
    public class DataServiceUserTests : IClassFixture<DatabaseFixtureUser>
    {
        DatabaseFixtureUser fixture;
        public DataServiceUserTests(DatabaseFixtureUser fixture)
        {
            this.fixture = fixture;
            fixture.InitialCatalog = "UserTest";
        }

        [Fact]
        public void AddUser_True_CorrectUser()
        {
            Assert.True(DataService.AddUser(new User { Name = "TestUser" }, fixture.InitialCatalog));
        }

        [Fact]
        public void AddUser_False_DefaultUser()
        {
            Assert.True(DataService.AddUser(new User(), fixture.InitialCatalog));
        }

        [Fact]
        public void GetUser_False()
        {
            var user = new User { Name = "TestUser" };
            DataService.AddUser(user, fixture.InitialCatalog);
            Assert.False(DataService.GetUser(DataService.GetUserID(user, fixture.InitialCatalog), fixture.InitialCatalog).isDefault);
        }

        [Fact]
        public void GetUsers_False()
        {
            DataService.AddUser(new User { Name = "TestUser" }, fixture.InitialCatalog);
            DataService.AddUser(new User { Name = "TestUser1" }, fixture.InitialCatalog);
            Assert.False(DataService.GetUsers(fixture.InitialCatalog).IsNullOrEmpty());
        }

        [Fact]
        public void GetUserID_True()
        {
            var user = new User { Name = "TestUser2" };
            DataService.AddUser(user, fixture.InitialCatalog);
            Assert.True(DataService.GetUserID(user, fixture.InitialCatalog) != 0);
        }

        [Fact]
        public void UpdateUser_True()
        {
            var user = new User { Name = "UserNameForTest" };
            DataService.AddUser(user, fixture.InitialCatalog);
            user.ID = DataService.GetUserID(user, fixture.InitialCatalog);
            Assert.True(DataService.GetUser(user.ID, fixture.InitialCatalog).Name == user.Name);
        }

        [Fact]
        public void RemoveUser_True()
        {
            var user = new User { Name = "UserNameForDeletion" };
            DataService.AddUser(user, fixture.InitialCatalog);
            user.ID = DataService.GetUserID(user, fixture.InitialCatalog);
            DataService.RemoveUser(user, fixture.InitialCatalog);
            Assert.True(DataService.GetUserID(user, fixture.InitialCatalog) == 0);
        }

        [Fact]
        public void RemoveAllDataInUserTable_True()
        {
            DataService.AddUser(new User { Name = "WowNewUser" }, fixture.InitialCatalog);
            DataService.RemoveAllDataInUserTable(fixture.InitialCatalog);
            Assert.True(DataService.GetUsers(fixture.InitialCatalog).IsNullOrEmpty());
        }

        [Fact]
        public void AddUsers_True()
        {
            var users = new List<User> { new User { Name = "User0" }, new User { Name = "User1" } };
            DataService.AddUsers(users, fixture.InitialCatalog);
            Assert.True(DataService.GetUsers(fixture.InitialCatalog).Count > 0);
        }

        [Fact]
        public void UpsertUser_True()
        {
            var user = new User { Name = "UserForUpsert" };
            DataService.AddUser(user, fixture.InitialCatalog);
            user.ID = DataService.GetUserID(user, fixture.InitialCatalog);
            user.Name = "UserNameChanged";
            DataService.UpsertUser(user, fixture.InitialCatalog);
            Assert.True(DataService.GetUser(user.ID, fixture.InitialCatalog).Name == user.Name);
        }
    }
}
