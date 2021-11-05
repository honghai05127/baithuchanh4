using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class tiec
    {
        string matiec;
        string tentiec;
        DateTime ngaydat;
        string makh;
        [Key]
        public string Matiec { get => matiec; set => matiec = value; }
        public string Tentiec { get => tentiec; set => tentiec = value; }
        public DateTime Ngaydat { get => ngaydat; set => ngaydat = value; }
        public string Makh { get => makh; set => makh = value; }

        [ForeignKey("Makh")]
        public khachhang kh { get; set; }
        public ICollection<bookphong> bookphongs { get; set; }
    }
}
