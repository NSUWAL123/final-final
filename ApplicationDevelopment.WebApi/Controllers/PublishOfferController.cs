using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApplicationDevelopment.Infrastructure.Persistence;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Application.DTOS;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishOfferController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PublishOfferController (ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetOffers")]
        public async Task<IEnumerable<OfferDTO>> GetOffers()
        {
            //var offers = await _context.Offer.Include(o => o.Car).ToListAsync();

            var offerDTOs = _context.Offer.Select(offer => new OfferDTO
            {
                Id = offer.Id,
                OfferTitle = offer.OfferTitle,
                OfferDescription = offer.OfferDescription,
                OfferStart = offer.OfferStart,
                OfferEnd = offer.OfferEnd,
                CarId = offer.CarId
            });

            return offerDTOs;
        }

        [HttpPost]
        public async Task<ActionResult<OfferDTO>> PostOffer(OfferDTO offerDTO)
        {
            if (_context.Offer == null)
            {
                return Problem("Entity set 'AppDataContext.Offers' is null.");
            }

            Offer offer = new Offer()
            {
                OfferTitle = offerDTO.OfferTitle,
                OfferDescription = offerDTO.OfferDescription,
                OfferStart = offerDTO.OfferStart,
                OfferEnd = offerDTO.OfferEnd,
                CarId=offerDTO.CarId
            };

            await _context.Offer.AddAsync(offer);
            await _context.SaveChangesAsync();

            offerDTO.Id = offer.Id;

            return offerDTO;
        }


    }
}
