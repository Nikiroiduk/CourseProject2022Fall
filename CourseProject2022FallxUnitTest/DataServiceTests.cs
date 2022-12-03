using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallxUnitTest
{
    public class DataServiceTests
    {
        [Fact]
        public void AddUser_True()
        {
            var mock = new Mock<IWrapper>();
            mock.Setup(x => x.AddUser(It.IsAny<User>()));
            new DataServie(mock.Object).AddUser(new User());
            mock.VerifyAll();
        }
    }
}
