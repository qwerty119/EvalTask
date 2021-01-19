using System.Collections.Generic;

namespace EvalTask.Dto
{
    public class ImportResultDto
    {
        public long FilesUploadedQuantity { get; set; }
        
        public long FilesNotUploadedQuantity { get; set; }

        public List<string> NamesNotUploadedFiles { get; set; }
    }
}