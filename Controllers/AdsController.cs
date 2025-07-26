using Microsoft.AspNetCore.Mvc;
using AdsApiSQLite.Data;
using AdsApiSQLite.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdsApiSQLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly AdsDbContext _context;

        public AdsController(AdsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ad>> GetAll() => _context.Ads.ToList();

        [HttpGet("{id}")]
        public ActionResult<Ad> Get(int id)
        {
            var ad = _context.Ads.Find(id);
            return ad == null ? NotFound() : ad;
        }

        [HttpPost]
        public IActionResult Create(Ad ad)
        {
            _context.Ads.Add(ad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = ad.Id }, ad);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ad ad)
        {
            var existingAd = _context.Ads.Find(id);
            if (existingAd == null) return NotFound();

            existingAd.Title = ad.Title;
            existingAd.Description = ad.Description;
            existingAd.Location = ad.Location;
            existingAd.Price = ad.Price;
            existingAd.Images = ad.Images;
            existingAd.Phone = ad.Phone;
            existingAd.Category = ad.Category;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ad = _context.Ads.Find(id);
            if (ad == null) return NotFound();

            _context.Ads.Remove(ad);
            _context.SaveChanges();
            return Ok(new { message = "Ad deleted successfully" });
        }
    }
}