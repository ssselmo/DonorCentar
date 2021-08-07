﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DonorCentar.WebAPI.Database
{
    public class BazaPodataka : DbContext
    {
        public BazaPodataka(DbContextOptions<BazaPodataka> options)
            : base(options)
        {}

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Kanton> Kanton { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<LicniPodaci> LicniPodaci { get; set; }
        public DbSet<LoginPodaci> LoginPodaci { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Primalac> Primalac { get; set; }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<TipNotifikacije> TipNotifikacije { get; set; }
        public DbSet<VrstaDonacije> VrstaDonacije { get; set; }
        public DbSet<TipDonacije> TipDonacije { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Donacija> Donacija { get; set; }
        public DbSet<InformacijeTransporta> InformacijeTransporta { get; set; }
        public DbSet<Dojam> Dojam { get; set; }
        public DbSet<DojamKorisnik> DojamKorisnik { get; set; }

        public DbSet<Notifikacija> Notifikacija { get; set; }
        



    }
}
