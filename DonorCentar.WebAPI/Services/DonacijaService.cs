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


    public class DonacijaService : BaseCRUDService<Model.Donacija, Database.Donacija, DonacijaSearchRequest, DonacijaInsertRequest, DonacijaInsertRequest>, IDonacijaService
    {
        public DonacijaService(BazaPodataka context, IMapper mapper)
            : base(context, mapper)
        {
        }


        public override IEnumerable<Model.Donacija> Get(DonacijaSearchRequest search = null)
        {

            var query = Context.Donacija.AsQueryable();
            query = query.Include(x => x.TipDonacije).Include(x => x.Donor.LicniPodaci).Include(x => x.Informacije).Include(x => x.Primalac.LicniPodaci).Include(x => x.Status).Include(x => x.Transport.LicniPodaci).Include(x => x.VrstaDonacije);

            if (!string.IsNullOrWhiteSpace(search?.Tip))
            {
                query = query.Where(x => x.TipDonacije.Tip.ToLower().Contains(search.Tip.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search?.Vrsta))
            {
                query = query.Where(x => x.VrstaDonacije.Vrsta.ToLower().Contains(search.Vrsta.ToLower()));
            }

            if(search?.PrimalacId!=null)
            {
                query = query.Where(x => x.PrimalacId==search.PrimalacId);
            }

            if (search?.DonorId != null)
            {
                query = query.Where(x => x.DonorId == search.DonorId);
            }

            if (search?.PartnerId != null)
            {
                query = query.Where(x => x.TransportId == search.PartnerId);
            }


            var entities = query.ToList();


            var result = _mapper.Map<IList<Model.Donacija>>(entities);



            return result;
        }


    }
}