using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Calculator.Data.Repositories.Interfaces;

namespace Calculator.Data.Repositories
{
    public class ConstantsRepository : IConstantsRepository
    {
        private readonly ILogger<ConstantsRepository> _logger;
        private readonly CalculatorDbContext _context;

        public ConstantsRepository(
            ILogger<ConstantsRepository> logger,
            CalculatorDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task AddConstant(string name, string value)
        {
            var constant = new Entities.Constant()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value,
                ModifyDate = System.DateTime.UtcNow
            };
            _context.Constants.Add(constant);
            
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<List<Entities.Constant>> GetConstants()
        {
            return _context.Constants.ToListAsync();
        }

        public Task<Entities.Constant> GetConstant(string name)
        {
            return _context.Constants.FirstOrDefaultAsync(c=> c.Name == name);
        }
    }
}