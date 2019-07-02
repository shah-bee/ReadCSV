using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadTSV
{
    public sealed class ProjectModelMapper : ClassMap<ProjectModel>
    {
        public ProjectModelMapper()
        {
            Map(m => m.ProjectId).Name("Project");
            Map(m => m.Description).Name("Description");
            Map(m => m.StartDate).Name("Start date");
            Map(m => m.Category).Name("Category");
            Map(m => m.Responsible).Name("Responsible");
            Map(m => m.SavingsAmount).Name("Savings amount");
            Map(m => m.Currency).Name("Currency");
            Map(m => m.Complexity).Name("Complexity");
        }
    }
}

