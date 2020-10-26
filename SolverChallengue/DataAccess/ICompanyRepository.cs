using SolverChallengue.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolverChallengue.DataAccess
{
    public interface ICompanyRepository
    {
        IEnumerable<Record> GetRecords();
        void CreateRecord(string document);
        public IEnumerable<Record> GetRecord(int documentId);
    }
}
