using katon_example.Core.Models;
using katon_example.Core.Services;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace katon_example.Test.Services
{
    public class UserServicesTest
    {
        private readonly ITestOutputHelper _output;

        private readonly UserServices _service;

        public UserServicesTest(ITestOutputHelper output)
        {
            _output = output;
            _service = new UserServices();
        }

        [Fact]
        public void CanGetListUser()
        {
            var result = _service.GetAll();
            Assert.True(result.Count > 0, result.Count.ToString());
            _output.WriteLine(result.Count.ToString());
        }

        [Theory]
        [InlineData(1)]
        public void CanGetUserById(int Id)
        {
            var result = _service.GetById(Id);
            Assert.True(result != null);

            var message = $"Id:{result?.Id} Name:{result?.Name} Last:{result?.LastName}";
            _output.WriteLine(message);
        }

        [Theory]
        [InlineData("katonAdd1", "LastNameAdd1")]
        public void CanAddUser(string Name, string LastName)
        {
            var user = new UserModelDTO()
            {
                Name = Name,
                LastName = LastName
            };

            var fristList = _service.GetAll().Count;

            _service.Add(user);

            var secondList = _service.GetAll();

            Assert.True(fristList < secondList.Count);

            var result = secondList.OrderBy(x => x.Id).LastOrDefault();

            var message = $"Id:{result?.Id} Name:{result?.Name} Last:{result?.LastName}";

            _output.WriteLine(message);
        }

        [Theory]
        [InlineData(1, "katonEdit", "LastNameEdit")]
        [InlineData(3, "katonEdit", "LastNameEdit", false)]
        public void CanEditUser(int Id, string Name, string LastName, bool CheckTrue = true)
        {
            var user = new UserModelDTO()
            {
                Id = Id,
                Name = Name,
                LastName = LastName
            };

            _service.Edit(user);

            var result = _service.GetById(Id);

            if (CheckTrue) Assert.True(result?.Name == Name && result?.LastName == LastName);

            if (!CheckTrue) Assert.False(result?.Name == Name);

            var message = $"Id:{result?.Id} Name:{result?.Name} Last:{result?.LastName} result:{CheckTrue}";

            _output.WriteLine(message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3, false)]
        public void CanDeleteUser(int Id, bool CheckTrue = true)
        {
            var firstList = _service.GetAll().Count;

            _service.Delete(Id);

            var secondList = _service.GetAll();

            if (CheckTrue) Assert.True(firstList > secondList.Count);

            if (!CheckTrue) Assert.True(firstList == secondList.Count);

            var message = $"first:{ firstList } second:{ secondList }";

            _output.WriteLine(message);
        }
    }
}