namespace Application.Utilities.FileWriter.Models.Interfaces
{
    public interface IFileWriterModel<TContentType>
    {
        public string FilePath { get; init; }

        public TContentType Content { get; init; }
    }
}
