namespace phr.Models
{
    public class OutstandingException
    {

        public int Id { get; set; }

        public string SignalCode { get; set; }

        public string Uwi { get; set; }

        public string StringCode { get; set; }

        public string StringName { get; set; }

        public string StatusWell { get; set; }

        public string CurrentWellStatus { get; set; }

        public string SignalRemark { get; set; }

        public int? TotalException { get; set; } // Nullable int

        public string ListException { get; set; }

        public DateTime LastWtDate { get; set; } // Assuming this is a DateTime

        public int LastBopd { get; set; }

        public int DeltaBopd { get; set; }

        public int LastBfpd { get; set; }

        public int DeltaBfpd { get; set; }

        public string SubProductionUnitCode { get; set; }

        public string AreaCode { get; set; }

        public string SubAreaCode { get; set; }

        public string AsetArea { get; set; }

        public DateTime Field { get; set; } // Assuming this is a DateTime

        public string Area { get; set; }

        public DateTime Arse { get; set; } // Assuming this is a DateTime

        public string Fcty1Code { get; set; }

        public string Fcty2Code { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public string TypeData { get; set; }

        public string ExceptCode { get; set; }

        public string ExceptName { get; set; }

        public string PumpType { get; set; }

        public string AltName { get; set; }

        public string GridName { get; set; }

        public string WtTrain { get; set; }

        public string NewManifold { get; set; }

        public string CommingleList { get; set; }

        public double? FluidAbovePump { get; set; } // Nullable double

        public string ProdStringType { get; set; }
    }
}
