﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolverChallengue.Models
{
    public class FileModel
    {
        public string DocumentId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}