using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeastHub;
using FeastHub.Auth;
using Microsoft.AspNetCore.Authorization;

namespace FoodDeliveryApplication.Controllers
{
  //  [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendor()
        {
          if (_context.Vendor == null)
          {
              return NotFound();
            }
            // .Include("Lodgings")
            //var test1 = (from c in _context.Vendor
            //             join e in _context.menu.Emails
            //                 on c.id equals e.id_contact
            //             join t in db.Tags
            //             on c.id equals t.id_contact
            //             join p in db.Phones on c.id equals p.id_contact
            //             select new
            //             {
            //                 id = c.id,
            //                 phones = p.number,
            //                 emails = e.email1,
            //                 tags = t.tag1,
            //                 firstname = c.firstname,
            //                 lastname = c.lastname,
            //                 address = c.address,
            //                 city = c.city,
            //                 bookmarked = c.bookmarked,
            //                 notes = c.notes
            //             }).ToList();
            // var getdeatils = VendorContext.Vendors;
            // _context.Vendor.Menus
            var vendors = VendorContext.Vendors;
            return  vendors;
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
          if (_context.Vendor == null)
          {
              return NotFound();
          }
            var vendor = await _context.Vendor.FindAsync(id);
            vendor = VendorContext.Vendors.FirstOrDefault(x=>x.Id == id);
           // return vendors;
            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
          if (_context.Vendor == null)
          {
              return Problem("Entity set 'AppDbContext.Vendor'  is null.");
          }
            _context.Vendor.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            if (_context.Vendor == null)
            {
                return NotFound();
            }
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(int id)
        {
            return (_context.Vendor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       
    }
    public class VendorContext
    {
        public static List<Vendor> Vendors = new()
            {
                    new Vendor(){ Id=1,Name="Dindigul Thalappakatti Restaurant",
                        Menus=new(){ 
                            new Menu(){ MenuId=1,Name="Jeera Pulao",Price=161},
                           new Menu() { MenuId=2,Name="Mutton Biryani",Price=320},
                            new Menu(){ MenuId=3,Name="JChicken Biryani",Price=220}
                        },
                        OperatingHours=new(){new OperatingHours() { DayOfWeek=DayOfWeek.Sunday,OpeningTime= "7:00 AM",ClosingTime= "11:30 PM" ,OperatingHoursId=1 } ,
                        new OperatingHours() { DayOfWeek=DayOfWeek.Monday,OpeningTime= "8:00 AM",ClosingTime= "11:00 PM" ,OperatingHoursId=2},
                        new OperatingHours() { DayOfWeek=DayOfWeek.Tuesday,OpeningTime= "8:00 AM",ClosingTime= "11:00 PM", OperatingHoursId = 3},
                        new OperatingHours() { DayOfWeek=DayOfWeek.Wednesday,OpeningTime= "8:00 AM",ClosingTime= "11:00 PM", OperatingHoursId = 4},
                        new OperatingHours() { DayOfWeek=DayOfWeek.Thursday,OpeningTime= "8:00 AM",ClosingTime= "11:00 PM" , OperatingHoursId = 5},
                        new OperatingHours() { DayOfWeek=DayOfWeek.Friday,OpeningTime= "8:00 AM",ClosingTime= "11:00 PM" , OperatingHoursId = 6},
                        new OperatingHours() { DayOfWeek=DayOfWeek.Saturday,OpeningTime= "7:00 AM",ClosingTime= "11:30 PM"  , OperatingHoursId = 7}
                        },

            }
        };
    }
    
}
