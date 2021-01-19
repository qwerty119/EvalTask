using EvalTask.Dto;
using Microsoft.AspNetCore.Http;

namespace EvalTask.Features.UploadServices.Interfaces
{
    public interface IFileParser<T>
    {
        T ParseFile(ImportFile file);
    }
    
    public interface IJsonFileParser<T> : IFileParser<T>
    {
    }
    
    public interface ICsvFileParser<T> : IFileParser<T>
    {
    }
}