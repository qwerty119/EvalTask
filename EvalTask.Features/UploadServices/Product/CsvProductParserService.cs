using System;
using System.Collections.Generic;
using EvalTask.Data;
using EvalTask.Dto;
using EvalTask.Features.UploadServices.Base;
using EvalTask.Features.UploadServices.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EvalTask.Features.UploadServices.Product
{
    public class CsvProductParserService : ICsvFileParser<Domain.Entities.Product>
    {
        public Domain.Entities.Product ParseFile(ImportFile form)
        {
            return new Domain.Entities.Product("1234", Guid.NewGuid(), Guid.NewGuid().ToString());
        }
    }
}