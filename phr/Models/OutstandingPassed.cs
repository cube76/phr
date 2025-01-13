namespace phr.Models
{
    public class OutstandingPassed
    {
        public int Id { get; set; }

        public int ActionId { get; set; }

        public int WorkflowId { get; set; }

        public string Ids { get; set; }

        public string ActionStatus { get; set; }

        public string ActionCode { get; set; }

        public string ActionDesc { get; set; }

        public string Uwi { get; set; }

        public string StringCode { get; set; }

        public string StringName { get; set; }

        public string StatusWell { get; set; }

        public string ActionFlowStep { get; set; }

        public string Percentage { get; set; }

        public string Finding { get; set; }

        public string JobPlan { get; set; }

        public string Remark { get; set; }

        public string? EstBopd { get; set; } 

        public string Dpi { get; set; }

        public string PassedBy { get; set; }

        public DateTime PassedDate { get; set; } // DateTime for passedDate

        public string ActionOriginator { get; set; }

        public DateTime ActionDate { get; set; } // DateTime for actionDate

        public string SubProductionUnitCode { get; set; }

        public string AreaCode { get; set; }

        public string SubAreaCode { get; set; }

        public string AssetArea { get; set; }

        public string Field { get; set; }

        public string Area { get; set; }

        public string Arse { get; set; }

        public string Fcty1Code { get; set; }

        public string Fcty2Code { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public int WorkflowStep { get; set; }

        public int TotalWorkflowStep { get; set; }

        public string AltName { get; set; }

        public string GridName { get; set; }

        public string RoleName { get; set; }

        public string WtTrain { get; set; }

        public string NewManifold { get; set; }

        public string PtmRegion { get; set; }

        public string Zona { get; set; }
    }
}
