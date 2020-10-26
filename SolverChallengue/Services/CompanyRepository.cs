using SolverChallengue.DataAccess;
using SolverChallengue.DataAccess.DbContext;
using SolverChallengue.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolverChallengue.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _context;
        public CompanyRepository(CompanyContext context)
        {
            _context = context;
        }

        public void CreateRecord(string record)
        {
            var newRecord = new Record();
            newRecord.RecordId = Guid.NewGuid();
            newRecord.ExecDate = DateTimeOffset.Now;
            newRecord.DocumentId = int.Parse(record);
            _context.Records.Add(newRecord);
            _context.SaveChanges();           
        }

        public IEnumerable<Record> GetRecords()
        {
            return _context.Records.OrderByDescending(x => x.ExecDate).ToList<Record>();
        }

        public IEnumerable<Record> GetRecord(int documentId)
        {
            return _context.Records.Where(x => x.DocumentId == documentId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
