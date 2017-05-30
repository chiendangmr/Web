using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblNasTable
    {
        public int NasId { get; set; }
        public string NasIp { get; set; }
        public long NasSize { get; set; }
        public long NasRemain { get; set; }
        public string NasDiscription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int IsAlive { get; set; }
        public string Data1Directory { get; set; }
        public string Data2Directory { get; set; }
        public string Data3Directory { get; set; }
        public string Data4Directory { get; set; }
        public string UncbasePathData1 { get; set; }
        public string UncbasePathData2 { get; set; }
        public string UncbasePathData3 { get; set; }
        public string UncbasePathData4 { get; set; }
        public string ConfigIpAddress { get; set; }
        public int? ConfigPort { get; set; }
        public string ConfigUserName { get; set; }
        public string ConfigPassword { get; set; }
        public string SerialNumber { get; set; }
        public int? NumberOfDisk { get; set; }
        public DateTime AssembleDate { get; set; }
        public int CurrentConnectedSession { get; set; }
        public int? DeviceType { get; set; }
        public int PowerfulFactor { get; set; }
        public bool UseInBackup { get; set; }
        public int? ReportError { get; set; }
    }
}
