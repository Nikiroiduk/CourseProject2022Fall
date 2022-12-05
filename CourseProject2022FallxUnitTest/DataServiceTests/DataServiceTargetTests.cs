using CourseProject2022FallBL.Models;
using Microsoft.IdentityModel.Tokens;

namespace CourseProject2022FallxUnitTest.DataServiceTests
{
    public class DataServiceTargetTests : IClassFixture<DatabaseFixtureTarget>
    {
        DatabaseFixtureTarget fixture;
        public DataServiceTargetTests(DatabaseFixtureTarget fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddTarget_True_CorrectTarget()
        {
            Assert.True(fixture.AddTarget(new Target { Name = "TestTarget" }));
        }

        [Fact]
        public void AddTarget_True_DefaultTarget()
        {
            Assert.True(fixture.AddTarget(new Target()));
        }

        [Fact]
        public void GetTarget_False()
        {
            var target = new Target { Name = "TestTarget" };
            fixture.AddTarget(target);
            Assert.False(fixture.GetTargetID(target) == 0);
        }

        [Fact]
        public void GetTargets_False()
        {
            fixture.AddTarget(new Target { Name = "TestTarget" });
            fixture.AddTarget(new Target { Name = "TestTarget1" });
            Assert.False(fixture.GetTargets().IsNullOrEmpty());
        }

        [Fact]
        public void GetTargetID_True()
        {
            var target = new Target { Name = "TestTarget2" };
            fixture.AddTarget(target);
            Assert.True(fixture.GetTargetID(target) != 0);
        }

        [Fact]
        public void UpdateTarget_True()
        {
            var target = new Target { Name = "TargetNameForTest" };
            fixture.AddTarget(target);
            target.ID = fixture.GetTargetID(target);
            target.Name = "TargetNameForTestNew";
            fixture.UpdateTarget(target);
            Assert.True(fixture.GetTarget(target.ID).Name == target.Name);
        }

        [Fact]
        public void RemoveTarget_True()
        {
            var target = new Target { Name = "TargetNameForDeletion" };
            fixture.AddTarget(target);
            target.ID = fixture.GetTargetID(target);
            fixture.RemoveTarget(target);
            Assert.True(fixture.GetTargetID(target) == 0);
        }

        [Fact]
        public void RemoveAllDataInTargetTable_True()
        {
            fixture.AddTarget(new Target { Name = "WowNewTarget" });
            fixture.RemoveAllDataInTargetTable();
            Assert.True(fixture.GetTargets().IsNullOrEmpty());
        }

        [Fact]
        public void AddTargets_True()
        {
            var targets = new List<Target> { new Target { Name = "Target0" }, new Target { Name = "Target1" } };
            fixture.AddTargets(targets);
            Assert.True(fixture.GetTargets().Count > 0);
        }

        [Fact]
        public void UpsertTarget_True()
        {
            var target = new Target { Name = "TargetForUpsert" };
            fixture.AddTarget(target);
            target.ID = fixture.GetTargetID(target);
            target.Name = "TargetNameChanged";
            fixture.UpsertTarget(target);
            Assert.True(fixture.GetTarget(target.ID).Name == target.Name);
        }
    }
}
