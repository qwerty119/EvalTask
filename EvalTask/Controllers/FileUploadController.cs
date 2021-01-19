using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EvalTask.Features.Imports.Commands;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    public class FileUploadController : BaseController
    {
        public FileUploadController(ILoggerFactory logger) : base(logger)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductUpload(List<IFormFile> files) => 
            Ok(new {jobId = await Mediator.Send(new ImportProductCommand(files, UserContext))});
    }
}