using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using komite.Models;

namespace komite.Data
{
    public class komiteContext : DbContext
    {
        public komiteContext(DbContextOptions<komiteContext> options)
            : base(options)
        {
        }

        public DbSet<komite.Models.user>? user { get; set; } = default!;
        public DbSet<komite.Models.never>? never { get; set; }
        public DbSet<komite.Models.v_nbt_sms2>? v_nbt_sms2 { get; set; }
        public DbSet<komite.Models.v_nbt_sms1>? v_nbt_sms1 { get; set; }
        public DbSet<komite.Models.onvan_komite> onvan_komite { get; set; }
        public DbSet<komite.Models.sabt> sabt { get; set; }
        public DbSet<komite.Models.vaziat> vaziat { get; set; }
        public DbSet<komite.Models.v_sabt> v_sabt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<v_nbt_sms3>()
            //.ToView(nameof(v_nbt_sms2))
            //.HasNoKey();

           // modelBuilder.Entity<v_nbt_sms2>()
           //.ToView(nameof(v_nbt_sms2))
           //.HasNoKey();

        }



        

    }
}
