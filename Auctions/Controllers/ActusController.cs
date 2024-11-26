using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auctions.Data;
using Auctions.Models;
using Auctions.Data.Services;

namespace Auctions.Controllers
{
    public class ActusController : Controller
    {
        private readonly IActuService _actuService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        

        public ActusController(IActuService actuService, IWebHostEnvironment webHostEnvironment)
        {
            _actuService = actuService;
            _webHostEnvironment = webHostEnvironment;
        }

       
        // GET: Actus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _actuService.GetAll();
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActuVM actu)
        {
            if (actu.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string fileName = actu.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await actu.Image.CopyToAsync(fileStream);
                }

                var listObj = new Actu
                {
                    Titre = actu.Titre,
                    Contenu = actu.Contenu,
                    Auteur = actu.Auteur,
                    ImagePath = fileName,
                    IdentityUserId = actu.IdentityUserId
                };
                await _actuService.Add(listObj);
                return RedirectToAction(nameof(Index));
            }
            return View(actu);
        }

        // GET: Actus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actu = await _actuService.GetById(id.Value);
            if (actu == null)
            {
                return NotFound();
            }

            return View(actu);
        }

        //// GET: Actus/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var actu = await _context.Actus
        //        .Include(a => a.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (actu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(actu);
        //}

        //// GET: Actus/Create
        //public IActionResult Create()
        //{
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        //// POST: Actus/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Titre,Contenu,DatePublication,Auteur,ImageUrl,VideoUrl,IdentityUserId")] Actu actu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(actu);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", actu.IdentityUserId);
        //    return View(actu);
        //}

        //// GET: Actus/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var actu = await _context.Actus.FindAsync(id);
        //    if (actu == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", actu.IdentityUserId);
        //    return View(actu);
        //}

        //// POST: Actus/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Contenu,DatePublication,Auteur,ImageUrl,VideoUrl,IdentityUserId")] Actu actu)
        //{
        //    if (id != actu.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(actu);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ActuExists(actu.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", actu.IdentityUserId);
        //    return View(actu);
        //}

        //// GET: Actus/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var actu = await _context.Actus
        //        .Include(a => a.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (actu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(actu);
        //}

        //// POST: Actus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var actu = await _context.Actus.FindAsync(id);
        //    if (actu != null)
        //    {
        //        _context.Actus.Remove(actu);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ActuExists(int id)
        //{
        //    return _context.Actus.Any(e => e.Id == id);
        //}
    }
}
