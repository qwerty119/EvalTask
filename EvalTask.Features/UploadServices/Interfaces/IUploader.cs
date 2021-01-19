using System.Collections.Generic;
using EvalTask.Dto;
using Microsoft.AspNetCore.Http;

namespace EvalTask.Features.UploadServices.Interfaces
{
    public interface IUploader
    {
        bool Upload<T>(List<T> list) where T : class;
    }
}