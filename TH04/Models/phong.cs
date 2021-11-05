using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class phong
    {
        string maphong;
        string tenphong;
        int succhua;
        string loaiphong;
        string masanh;
        [Key]
        public string Maphong { get => maphong; set => maphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public int Succhua { get => succhua; set => succhua = value; }
        public string Loaiphong { get => loaiphong; set => loaiphong = value; }
        public string Masanh { get => masanh; set => masanh = value; }

        [ForeignKey("Masanh")]
        public sanh sanh { get; set; }
        public ICollection<bookphong> bookphongs { get; set; }
    }
}
