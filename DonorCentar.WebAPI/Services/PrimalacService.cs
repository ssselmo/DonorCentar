﻿using AutoMapper;
using DonorCentar.Model.Requests;
using DonorCentar.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.WebAPI.Services
{
    public class PrimalacService : BaseReadService<Model.Primalac, Database.Primalac, PrimalacSearchRequest>, IPrimalacService
    {
        public PrimalacService(BazaPodataka context, IMapper mapper) : base(context, mapper)
        {
        }




        public Model.Primalac Verifikuj(int id)
        {
            var entity = Context.Primalac.Find(id);
            entity.Verifikovan = true;




            Context.SaveChanges();
            return _mapper.Map<Model.Primalac>(entity);
        }



        public override IEnumerable<Model.Primalac> Get(PrimalacSearchRequest search)
        {
            var query = Context.Primalac.Where(x => x.Korisnik.Izbrisan == false).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                search.ImePrezime = search.ImePrezime.ToLower();
                query = query.Where(x => x.Korisnik.LicniPodaci.Ime.ToLower().Contains(search.ImePrezime) || x.Korisnik.LicniPodaci.Prezime.ToLower().Contains(search.ImePrezime) || (x.Korisnik.LicniPodaci.Ime + " " + x.Korisnik.LicniPodaci.Prezime).ToLower().Contains(search.ImePrezime));

            }

          

            query = query.Include(x => x.Korisnik.Grad.Kanton);
            query = query.Include(x => x.Korisnik.LicniPodaci);
            query = query.Include(x => x.Korisnik.TipKorisnika);
            query = query.Include(x => x.Korisnik.LoginPodaci);

            var entities = query.ToList();


            var result = _mapper.Map<IEnumerable<Model.Primalac>>(entities);



            return result;
        }
    }
}
