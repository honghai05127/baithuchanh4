using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class khachhang
    {
        string makh;
        string tenkh;
        DateTime ngaysinh;
        string diachi;
        [Key]
        public string Makh { get => makh; set => makh = value; }
        [Column("tenk")]
        public string Tenkh { get => tenkh; set => tenkh = value; }
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        public ICollection<tiec> tiecs { get; set; }
    }
}
