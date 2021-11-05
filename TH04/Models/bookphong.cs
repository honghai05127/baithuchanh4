using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class bookphong
    {
        string matiec;
        string maphong;
        string slnuocuong;

        public string Slnuocuong { get => slnuocuong; set => slnuocuong = value; }
        [Key]
        public string Maphong { get => maphong; set => maphong = value; }
        [Key]
        public string Matiec { get => matiec; set => matiec = value; }

        [ForeignKey("Maphong")]
        public phong ph { get; set; }
        [ForeignKey("Matiec")]
        public tiec tc { get; set; }
    }
}
