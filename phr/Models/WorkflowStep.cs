namespace phr.Models
{
    public class WorkflowStep
    {
        public int Id { get; set; }

        public int ActionId { get; set; }

        public string? ActionCode { get; set; }

        public int? StepNumber { get; set; }

        public int? RoleId { get; set; }

        public string? StepDesc { get; set; }

        public string? RoleName { get; set; }

        public string? RoleDesc { get; set; }

        public string? ActionTaken { get; set; }

        public string? WorkflowStatus { get; set; }

        public string? Remark { get; set; }

        public string? InputedBy { get; set; }

        public DateTime? InputedDate { get; set; }

        public int? WorkflowId { get; set; }

        public string? BfActionTaken { get; set; }

        public string? Filename { get; set; }

        public string? Files { get; set; }

        public int? AttachmentId { get; set; }
    }
}
