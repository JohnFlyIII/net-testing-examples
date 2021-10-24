using System;
using Xunit;
using Calculator.Data.Repositories.Interfaces;

namespace Calculator.Data.Tests
{
    public class ConstantsRepositoryTests
    {

        private readonly IConstantsRepository _constantsRepository;

        public ConstantsRepositoryTests(IConstantsRepository constantsRepository)
        {
            _constantsRepository = constantsRepository;
        }

        [Theory, TestPriority(1)]
        [InlineData("pi","3.14")]
        [InlineData("testName","testValue")]
        public async void RepositoryCanAddConstants(string name, string value)
        {
            await _constantsRepository.AddConstant(name, value).ConfigureAwait(false);
        }

        [Fact]
        public async void RepositoryCanGetAllConstants()
        {
            var constants = await _constantsRepository.GetConstants().ConfigureAwait(false);
            Assert.NotNull(constants);
            Assert.True(constants.Count > 0);
        }

        [Theory]
        [InlineData("pi", "3.14")]
        [InlineData("testName","testValue")]
        public async void RepositoryCanGetConstantByName(string constantName, string expectedValue)
        {
            var constant = await _constantsRepository.GetConstant(constantName).ConfigureAwait(false);
            Assert.Equal(constant.Name, constantName);
            Assert.Equal(constant.Value, expectedValue);
        }
    }
}
