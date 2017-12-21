using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.Localization
{
    public class TranslatorView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [StringLength(190)]
        public string Scope { get; set; }

        public const int MaxLang = 10;

        public string Lang1 { get; set; }

        public string Lang2 { get; set; }

        public string Lang3 { get; set; }

        public string Lang4 { get; set; }

        public string Lang5 { get; set; }

        public string Lang6 { get; set; }

        public string Lang7 { get; set; }

        public string Lang8 { get; set; }

        public string Lang9 { get; set; }

        public string Lang10 { get; set; }
    }
}
