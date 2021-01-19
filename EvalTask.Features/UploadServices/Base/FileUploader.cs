using System;
using System.Collections.Generic;
using EvalTask.Data;
using EvalTask.Domain.Enums;
using EvalTask.Dto;
using EvalTask.Features.UploadServices.Interfaces;
using EvalTask.Features.UploadServices.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EvalTask.Features.UploadServices.Base
{
    public class FileUploader : IUploader
    {
        private readonly EvalTaskContext _context;
    
        public FileUploader(EvalTaskContext context)
        {
            _context = context;
        }

        public bool Upload<T>(List<T> list) where T : class
        {
            foreach (var entry in list)
            {
                _context.Set<T>().Add(entry);
            }
            
            //save changes
            throw new System.NotImplementedException();
        }
    
        // private IFileParser GetParser(EUploadFileType fileType, Type type, ImportFile form)
        // {
        //     if (fileType == EUploadFileType.Json)
        //     {
        //         // return new JsonProductParseService();
        //     }
        //
        //     throw new NotImplementedException();
        // }
    }
}