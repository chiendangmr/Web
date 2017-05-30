using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class InforTape
    {
        public InforTape()
        {
            Hdimport = new HashSet<Hdimport>();
            HdsyncV4InforTape = new HashSet<HdsyncV4InforTape>();
        }

        public long Idclip { get; set; }
        public string Mabang { get; set; }
        public string TcIn { get; set; }
        public string Tcout { get; set; }
        public string Tl { get; set; }
        public string Tenchuongtrinh { get; set; }
        public string Noidung { get; set; }
        public int Isserver { get; set; }
        public int Isvtr { get; set; }
        public int? Isnas { get; set; }
        public int Playtime { get; set; }
        public DateTime? Recorddate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RealTcIn { get; set; }
        public string RealTcOut { get; set; }
        public int Type { get; set; }
        public int Section { get; set; }
        public int Timetolive { get; set; }
        public int Approved { get; set; }
        public string Comment { get; set; }
        public int Userid { get; set; }
        public int? Source { get; set; }
        public int IsRaw { get; set; }
        public int NasId { get; set; }
        public string FileName { get; set; }
        public string Hdclip { get; set; }
        public int AfdType { get; set; }
        public string TemporaryFileName { get; set; }
        public int? ServiceLowResStatus { get; set; }
        public int? ServiceVoiceOverStatus { get; set; }
        public int? ServiceSubtitleStatus { get; set; }
        public int? ServiceRequest { get; set; }
        public int? Rtbchecking { get; set; }
        public int NasIdpreview { get; set; }
        public int NasIdedit { get; set; }
        public int NasIdtemporary { get; set; }
        public int ServicePriority { get; set; }
        public string Version { get; set; }
        public string VideoFormat { get; set; }
        public string TitleOrigin { get; set; }
        public DateTime? StartRights { get; set; }
        public DateTime? EndRights { get; set; }
        public string Runs { get; set; }
        public string Note { get; set; }
        public long? Ltoid { get; set; }
        public DateTime? LastAccessedTime { get; set; }
        public double AudioLevel { get; set; }
        public int RawCheck { get; set; }
        public string RawCheckNote { get; set; }
        public int? UserIdRawCheck { get; set; }
        public int? UserIdDecideService { get; set; }
        public int PostQualityCheck { get; set; }
        public string PostQualityCheckNote { get; set; }
        public int? UserIdPostQualityCheck { get; set; }
        public int PostContentVtvcheck { get; set; }
        public string PostContentVtvcheckNote { get; set; }
        public int? UserIdPostContentVtvcheck { get; set; }
        public int PostContentVstvcheck { get; set; }
        public string PostContentVstvcheckNote { get; set; }
        public int? UserIdPostContentVstvcheck { get; set; }
        public string Keywords { get; set; }
        public int OriginalServiceRequest { get; set; }
        public int UserIdRtbchecking { get; set; }
        public int CanCopy { get; set; }
        public int ClipSourceType { get; set; }
        public string VersionFileDate { get; set; }
        public string ReasonableScences { get; set; }
        public string AspectRatio { get; set; }
        public string Codec { get; set; }
        public int? ApproverUserId { get; set; }
        public string ApproverComment { get; set; }
        public int? MasterClipId { get; set; }
        public int? EpisodeNumber { get; set; }
        public bool AllowArchiving { get; set; }
        public long FileSize { get; set; }
        public int? LiveSourceId { get; set; }
        public int? Changed { get; set; }
        public int CheckOnServer { get; set; }
        public double FrameRate { get; set; }
        public bool? NeedUploadAgain { get; set; }
        public string Loudness { get; set; }
        public Guid SyncId { get; set; }
        public int? ChangedPcd { get; set; }
        public string Cgnow12 { get; set; }
        public string Cgnow { get; set; }
        public int? CgtopNumber { get; set; }
        public string Cgtop { get; set; }

        public virtual ICollection<Hdimport> Hdimport { get; set; }
        public virtual ICollection<HdsyncV4InforTape> HdsyncV4InforTape { get; set; }
    }
}
