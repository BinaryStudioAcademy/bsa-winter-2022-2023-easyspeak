namespace EasySpeak.Core.Common.DTO.UploadFile
{
    public class NewFileDto
    {
        public Stream Stream { get; set; } = null!;
        public string FolderPath { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
