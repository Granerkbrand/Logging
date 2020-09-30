namespace Logging.Core.Output
{
    public sealed class CallerInfo
    {
        public string Origin { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
    }
}
