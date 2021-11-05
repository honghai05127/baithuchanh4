using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TH04.Models
{
    public class sanh
    {
        string masanh;
        string tensanh;
        [Key]
        public string Masanh { get => masanh; set => masanh = value; }
        public string Tensanh { get => tensanh; set => tensanh = value; }

        public ICollection<phong> phongs { get; set; }
    }
}
