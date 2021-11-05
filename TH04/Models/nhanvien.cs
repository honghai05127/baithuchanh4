using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class nhanvien
    {
        int manv;
        string tennv;

        public string Tennv { get => tennv; set => tennv = value; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Manv { get => manv; set => manv = value; }
    }
}
