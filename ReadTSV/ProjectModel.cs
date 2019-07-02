using System;

namespace ReadTSV
{
    public class ProjectModel
    {
        public string ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Category { get; set; }
        public string Responsible { get; set; }
        public string SavingsAmount { get; set; }
        public string Currency { get; set; }
        public Complexity Complexity { get; set; }
    }
}
