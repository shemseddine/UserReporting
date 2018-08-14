namespace UserReporting.Shared.Tables
{
    public class UserReportRecord
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
