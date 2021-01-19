namespace EvalTask.Dto
{
    public class ImportFile
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public byte[] Content { get; set; }
    }
}