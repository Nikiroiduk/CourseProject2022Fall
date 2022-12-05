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
            Assert.True(fixture.AddUser(new User { Name = "TestUser" }));
        }

        [Fact]
        public void AddUser_True_DefaultUser()
        {
            Assert.True(fixture.AddUser(new User()));
        }

        [Fact]
        public void GetUser_False()
        {
            var user = new User { Name = "TestUser" };
            fixture.AddUser(user);
            Assert.False(fixture.GetUserID(user) == 0);
        }

        [Fact]
        public void GetTargets_False()
        {
            fixture.AddUser(new User { Name = "TestUser" });
            fixture.AddUser(new User { Name = "TestUser1" });
            Assert.False(fixture.GetUsers().IsNullOrEmpty());
        }

        [Fact]
        public void GetUserID_True()
        {
            var user = new User { Name = "TestUser2" };
            fixture.AddUser(user);
            Assert.True(fixture.GetUserID(user) != 0);
        }

        [Fact]
        public void UpdateUser_True()
        {
            var user = new User { Name = "UserNameForTest" };
            fixture.AddUser(user);
            user.ID = fixture.GetUserID(user);
            user.Name = "UserNameForTestNew";
            fixture.UpdateUser(user);
            Assert.True(fixture.GetUser(user.ID).Name == user.Name);
        }

        [Fact]
        public void RemoveTarget_True()
        {
            var user = new User { Name = "UserNameForDeletion" };
            fixture.AddUser(user);
            user.ID = fixture.GetUserID(user);
            fixture.RemoveUser(user);
            Assert.True(fixture.GetUserID(user) == 0);
        }

        [Fact]
        public void RemoveAllDataInUserTable_True()
        {
            fixture.AddUser(new User { Name = "WowNewUser" });
            fixture.RemoveAllDataInUserTable();
            Assert.True(fixture.GetUsers().IsNullOrEmpty());
        }

        [Fact]
        public void AddUsers_True()
        {
            var users = new List<User> { new User { Name = "User0" }, new User { Name = "User1" } };
            fixture.AddUsers(users);
            Assert.True(fixture.GetUsers().Count > 0);
        }

        [Fact]
        public void UpsertUser_True()
        {
            var user = new User { Name = "UserForUpsert" };
            fixture.AddUser(user);
            user.ID = fixture.GetUserID(user);
            user.Name = "UserNameChanged";
            fixture.UpsertUser(user);
            Assert.True(fixture.GetUser(user.ID).Name == user.Name);
        }
    }
}
