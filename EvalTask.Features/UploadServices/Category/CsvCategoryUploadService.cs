// using EvalTask.Data;
// using EvalTask.Dto;
// using EvalTask.Features.UploadServices.Base;
//
// namespace EvalTask.Features.UploadServices.Category
// {
//     public class CsvCategoryUploadService : FileUploader<Domain.Entities.Category>
//     {
//         public CsvCategoryUploadService(EvalTaskContext context) : base(context)
//         {
//         }
//
//         protected override Domain.Entities.Category Parse(ImportFile file)
//         {
//             throw new System.NotImplementedException();
//         }
//     }
//     
//     public class JsonCategoryUploadService : FileUploader<Domain.Entities.Category>
//     {
//         public JsonCategoryUploadService(EvalTaskContext context) : base(context)
//         {
//         }
//
//         protected override Domain.Entities.Category Parse(ImportFile file)
//         {
//             throw new System.NotImplementedException();
//         }
//     }
// }