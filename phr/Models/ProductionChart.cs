namespace phr.Models
{
    public class ProductionChart
    {
        public int? Id { get; set; }
        public string? StringCode { get; set; }
        public string? TestDate { get; set; }
        public string? IntTestDate { get; set; }
        public string? PumpFill { get; set; }
        public string? PumpSlip { get; set; }
        public string? GrossDisp { get; set; }
        public string? NetDisp { get; set; }
        public string? SPM { get; set; }
        public string? SL { get; set; }
        public string? TubingPress { get; set; }
        public string? CsgPressUp { get; set; }
        public string? WHT { get; set; }
        public string? TstFluid { get; set; }
        public string? TstOil { get; set; }
        public string? TstWater { get; set; }
        public string? WC { get; set; }
        public string? TstOilNoAcc { get; set; }
        public string? AllocFluid { get; set; }
        public string? AllocOil { get; set; }
        public string? TheorFluid { get; set; }
        public string? TheorOil { get; set; }
        public string? JobCode { get; set; }
        public string? YesTrun { get; set; }
        public string? UpdatedDate { get; set; }
        public string? InferredBfpd { get; set; }
        public string? InferredBwpd { get; set; }
        public string? InferredBopd { get; set; }
        public string? Freq { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? JobStatus { get; set; }
        public string? Remark { get; set; }
        public string? JobDetailDescription { get; set; }
        public string? JobCategory { get; set; }
        public string? RigCode { get; set; }
    }
}