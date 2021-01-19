using System;
using System.Collections.Generic;
using EvalTask.Dto;
using EvalTask.Features.UploadServices.Base;
using EvalTask.Features.UploadServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EvalTask.Features.UploadServices
{
    public class UploadStarter
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUploader _uploader;

        public UploadStarter(IServiceProvider serviceProvider, IUploader uploader)
        {
            _serviceProvider = serviceProvider;
            _uploader = uploader;
        }
        public void StartUpload<T>(List<ImportFile> list) where T : class
        {
            var entries = new List<T>();
            foreach (var importFile in list)
            {
                var service = GetService<T>(importFile);
                var entry = service.ParseFile(importFile);
                entries.Add(entry);
            }

            _uploader.Upload<T>(entries);
        }

        private IFileParser<T> GetService<T>(ImportFile importFile)
        {
            if (typeof(T).FullName == typeof(Domain.Entities.Product).FullName)
            {
                if (importFile.FileType == "application/json")
                {
                    return _serviceProvider.GetService<IJsonFileParser<T>>();
                        
                } 
            }

            throw new NotImplementedException();
        }
    }
}