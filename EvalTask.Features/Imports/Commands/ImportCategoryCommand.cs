using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Domain.Entities;
using EvalTask.Dto;
using EvalTask.Features.UploadServices;
using EvalTask.Features.UploadServices.Interfaces;
using EvalTask.Features.UploadServices.Product;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EvalTask.Features.Imports.Commands
{
    public class ImportProductCommand : IRequest<long>
    {
        public List<IFormFile> Files { get; set; }
        private UserContext UserContext { get; }

        public ImportProductCommand(List<IFormFile> files, UserContext userContext)
        {
            Files = files;
            UserContext = userContext;
        }
    }
    
    public class ImportProductCommandHandler : IRequestHandler<ImportProductCommand, long>
    {
        public async Task<long> Handle(ImportProductCommand request, CancellationToken cancellationToken)
        {
            var list = new List<ImportFile>();
            foreach (var formFile in request.Files)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var file = new ImportFile()
                    {
                        FileType = formFile.ContentType,
                        FileName = formFile.FileName,
                        Content = fileBytes
                    };
                    list.Add(file);
                }
                
            }
            var jobId = BackgroundJob.Enqueue<UploadStarter>(x => x.StartUpload<Product>(list));
                
            return long.Parse(jobId);
        }
    }
}