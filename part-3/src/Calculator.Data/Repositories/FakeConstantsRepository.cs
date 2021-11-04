using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Data.Entities;
using Calculator.Data.Repositories.Interfaces;

namespace Calculator.Data.Repositories
{
    public class FakeConstantsRepository : IConstantsRepository
    {
        private readonly List<Constant> _constants;

        public FakeConstantsRepository()
        {
            _constants = new List<Constant>();

            var testPi = new Constant
            {
                Id = Guid.Empty,
                Name = "pi",
                Value = "3.14",
                ModifyDate = DateTime.Now
            };

            _constants.Add(testPi);
        }

        public Task AddConstant(string name, string value)
        {
            return Task.CompletedTask;
        }

        public Task<Constant> GetConstant(string name)
        {
            var constant = _constants.FirstOrDefault(c => c.Name == name);
            return Task.FromResult(constant);
        }

        public Task<List<Constant>> GetConstants()
        {
            return Task.FromResult(_constants);
        }
    }
}
