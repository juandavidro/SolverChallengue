using Microsoft.AspNetCore.Mvc;
using SolverChallengue.DataAccess;
using SolverChallengue.DataAccess.Entities;
using SolverChallengue.Models;
using SolverChallengue.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverChallengue.Controllers
{
    [ApiController]
    [Route("api/records")]
    public class RecordController : ControllerBase
    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly IDataProcessingService _DataProcessing;
        public RecordController(ICompanyRepository companyRepository, IDataProcessingService processingService)
        {
            _CompanyRepository = companyRepository;
            _DataProcessing = processingService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Record>> GetRecords()
        {
            try
            {
            var RecordsFromRepo = _CompanyRepository.GetRecords();
            return Ok(RecordsFromRepo);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateRecord([FromForm] FileModel req)
        {
            List<int> inputData = new List<int>();
            
            try
            {
                inputData = _DataProcessing.getInputData(req);
                _CompanyRepository.CreateRecord(req.DocumentId);
            }catch
            {
                return BadRequest("Verifique el archivo o los datos de entrada");
            }

            var outPut = _DataProcessing.getOutPutData(inputData);
            string fileResponse = _DataProcessing.getOutPutString(outPut);

            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            tw.WriteLine(fileResponse);
            tw.Flush();
            tw.Close();

            return File(memoryStream.GetBuffer(), "text/plain", "file.txt");
        }
    }
}
