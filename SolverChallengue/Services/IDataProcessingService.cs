using SolverChallengue.Models;
using System.Collections.Generic;
using System.IO;

namespace SolverChallengue.Services
{
    public interface IDataProcessingService
    {
        List<int> getInputData(FileModel inputFile);
        public List<int> getOutPutData(List<int> inputData);
        public string getOutPutString(List<int> inputData);
    }
}