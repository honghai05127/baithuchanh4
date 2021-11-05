using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH04.Models;

namespace TH04.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext>
        options) : base(options)
        {
        }

        public DbSet<khachhang> KhachHangs { get; set; }
        public DbSet<tiec> Tiecs { get; set; }
        public DbSet<bookphong> BookPhongs { get; set; }
        public DbSet<phong> Phongs { get; set; }
        public DbSet<sanh> Sanhs { get; set; }
        public DbSet<nhanvien> NhanViens { get; set; }

        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            modelBuilder.Entity<khachhang>().ToTable("khachhang").
             HasKey(c => c.Makh);
            modelBuilder.Entity<tiec>().ToTable("tiec").
            HasKey(c => c.Matiec);
            modelBuilder.Entity<bookphong>().ToTable("bookphong").
            HasKey(c => new {
                c.Matiec,
                c.Maphong
            }); ;
            modelBuilder.Entity<phong>().ToTable("phong").
            HasKey(c => c.Maphong);
            modelBuilder.Entity<sanh>().ToTable("sanh").
            HasKey(c => c.Masanh);
            modelBuilder.Entity<nhanvien>().ToTable("nhanvien");        }

    }
}
