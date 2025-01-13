﻿namespace phr.Models
{
    public class WellLastInfo
    {
        public int? Id { get; set; }
        public DateTime? StatusStartDate { get; set; }
        public DateTime? PisDate { get; set; }
        public string Uwi { get; set; }
        public string StringCode { get; set; }
        public string StringName { get; set; }
        public string GridName { get; set; }
        public string AltName { get; set; }
        public string SubProductionUnitCode { get; set; }
        public string Field { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set; }
        public string Arse { get; set; }
        public string SubAreaCode { get; set; }
        public string Fcty1Code { get; set; }
        public string Fcty2Code { get; set; }
        public string DrillType { get; set; }
        public string ProdStringType { get; set; }
        public string StatusType { get; set; }
        public string Status { get; set; }
        public int? AwtTier { get; set; }
        public int? GlobalTier { get; set; }
        public string Sand { get; set; }
        public string CompletionType { get; set; }
        public string CommingleStatus { get; set; }
        public string AssetArea { get; set; }
        public DateTime? WtDate { get; set; }
        public double? AvgAllocBfpd3Mo { get; set; }
        public double? AvgAllocBopd3Mo { get; set; }
        public double? AvgAllocBwpd3Mo { get; set; }
        public double? AvgAllocGas3Mo { get; set; }
        public double? AvgTheorBfpd3Mo { get; set; }
        public double? AvgTheorBopd3Mo { get; set; }
        public double? AvgTheorBwpd3Mo { get; set; }
        public double? AvgTheorGas3Mo { get; set; }
        public double? AvgWtBfpd3Mo { get; set; }
        public double? AvgWtBopd3Mo { get; set; }
        public double? AvgWtBwpd3Mo { get; set; }
        public double? AvgWtWc3Mo { get; set; }
        public double? AvgWtGas3Mo { get; set; }
        public double? Avg5WtBfBopd { get; set; }
        public double? Avg5WtBfBfpd { get; set; }
        public double? Avg5WtBfBwpd { get; set; }
        public double? AllocBfpd { get; set; }
        public double? AllocBopd { get; set; }
        public double? AllocBwpd { get; set; }
        public double? AllocGas { get; set; }
        public double? TheorBfpd { get; set; }
        public double? TheorBopd { get; set; }
        public double? TheorBwpd { get; set; }
        public double? TheorGas { get; set; }
        public double? WtBfpd { get; set; }
        public double? WtBopd { get; set; }
        public double? WtBwpd { get; set; }
        public double? WtWc { get; set; }
        public double? Gor { get; set; }
        public string LowisAlarm { get; set; }
        public DateTime? LowisScandate { get; set; }
        public string WtTrain { get; set; }
        public string CommingleList { get; set; }
        public string Manifold { get; set; }
        public DateTime? DynoTestDate { get; set; }
        public double? AvgPfill3Mo { get; set; }
        public double? AvgPslip3Mo { get; set; }
        public double? AvgGrossDisp3Mo { get; set; }
        public double? AvgNetDisp3Mo { get; set; }
        public double? AvgPumpSpeed3Mo { get; set; }
        public double? AvgPstroke3Mo { get; set; }
        public double? AvgWht3Mo { get; set; }
        public double? AvgTbgpUp3Mo { get; set; }
        public double? AvgTbgpDown3Mo { get; set; }
        public double? AvgCsgpDn3Mo { get; set; }
        public double? PumpFill { get; set; }
        public double? PumpSlip { get; set; }
        public double? GrossDisplacement { get; set; }
        public double? NetDisplacement { get; set; }
        public double? PumpSpeed { get; set; }
        public double? PumpStroke { get; set; }
        public double? DynoWht { get; set; }
        public double? TubingPressUp { get; set; }
        public double? TubingPressDown { get; set; }
        public double? CsgPressDn { get; set; }
        public DateTime? InstallDate { get; set; }
        public double? PumpType { get; set; }
        public string PumpInfo { get; set; }
        public double? PumpSize { get; set; }
        public double? PlugBackDepth { get; set; }
        public double? PumpDepth { get; set; }
        public double? TubingSize { get; set; }
        public double? PrdcsgOd { get; set; }
        public double? PrdcsgBott { get; set; }
        public double? ScrlinerOd { get; set; }
        public double? ScrlinerTop { get; set; }
        public double? ScrlinerBott { get; set; }
        public DateTime? DownDate { get; set; }
        public double? HrsSinceOff { get; set; }
        public double? DaysSinceOff { get; set; }
        public double? BopdDefered { get; set; }
        public double? TotalDownOil { get; set; }
        public double? SorSS { get; set; }
        public string ProactOrReact { get; set; }
        public string EventCategory { get; set; }
        public string EventReason { get; set; }
        public string EventSystem { get; set; }
        public string DownRemark { get; set; }
        public string ComplJobNumber { get; set; }
        public DateTime? ComplJobStartDate { get; set; }
        public DateTime? ComplJobEndDate { get; set; }
        public string ComplJobStatus { get; set; }
        public string ComplJobCode { get; set; }
        public string ComplJobDesc { get; set; }
        public string ComplJobCategory { get; set; }
        public string ComplJobType { get; set; }
        public string PlanJobNumber { get; set; }
        public DateTime? PlanRequestDate { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public string PlanJobStatus { get; set; }
        public string PlanJobCode { get; set; }
        public string PlanJobDesc { get; set; }
        public string PlanJobCategory { get; set; }
        public string PlanJobType { get; set; }
        public DateTime? SonologDate { get; set; }
        public double? AvgStaticFluidLvl3Mo { get; set; }
        public double? AvgWorkingFluidLvl3Mo { get; set; }
        public double? AvgFluidAbovePump3Mo { get; set; }
        public double? AvgAmpereReading3Mo { get; set; }
        public double? AvgTbgp3Mo { get; set; }
        public double? AvgHdrPress3Mo { get; set; }
        public double? StaticFluidLvl { get; set; }
        public double? WorkingFluidLvl { get; set; }
        public double? FluidAbovePump { get; set; }
        public double? AmpereReading { get; set; }
        public double? TubingPress { get; set; }
        public double? HdrPress { get; set; }
        public double? PumpStages { get; set; }
        public string ProtectorType { get; set; }
        public double? MotorHp { get; set; }
        public double? DesignRate { get; set; }
        public double? MotorVoltage { get; set; }
        public double? MotorAmps { get; set; }
        public string ProductionCasing { get; set; }
        public string FaName { get; set; }
        public double? PidodKvaMax { get; set; }
        public double? PidodSecondaryVolt { get; set; }
        public double? PidodTapPosition { get; set; }
        public double? InjGas { get; set; }
        public double? AvgInjGas3Mo { get; set; }
        public double? TheorGasTs { get; set; }
        public double? InjGasTs { get; set; }
        public double? AvgTheorGas3MoTs { get; set; }
        public double? AvgInjGas3MoTs { get; set; }
        public string OilType { get; set; }
        public string SclinhibitorInj { get; set; }
        public double? PotentialBfpd { get; set; }
        public double? PotentialBopd { get; set; }
        public double? PotentialWc { get; set; }
        public double? PotentialGas { get; set; }
        public DateTime? PotentialDate { get; set; }
        public double? DynoCsgTemp { get; set; }
        public string CompJobRemark { get; set; }
        public string PumpSet { get; set; }
        public string OnOffTimer { get; set; }
        public double? GasRate { get; set; }
        public double? RunLife { get; set; }
    }
}
