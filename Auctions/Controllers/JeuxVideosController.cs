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
using Microsoft.AspNetCore.Hosting;

namespace Auctions.Controllers
{
    public class JeuxVideosController : Controller
    {
        private readonly IJeuxVideoService _jeuxVideoService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public JeuxVideosController(IJeuxVideoService jeuxVideoService, IWebHostEnvironment webHostEnvironment)
        {
            _jeuxVideoService = jeuxVideoService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: JeuxVideos      
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var applicationDbContext = _jeuxVideoService.GetAll();
            int pageSize = 3;
           
            return View(await PaginatedList<JeuxVideo>
                .CreateAsync(applicationDbContext
                .AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        //// GET: JeuxVideos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jeuxVideo = await _context.JeuxVideos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jeuxVideo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(jeuxVideo);
        //}

        // GET: JeuxVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JeuxVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JeuxVideoVM jeuxVideo)
        {
            if (jeuxVideo.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string fileName = jeuxVideo.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await jeuxVideo.Image.CopyToAsync(fileStream);
                }

                var listObj = new JeuxVideo
                {
                    Titre = jeuxVideo.Titre,
                    Description = jeuxVideo.Description,
                    ImagePath = fileName
                };
                await _jeuxVideoService.Add(listObj);
                return RedirectToAction(nameof(Index));
            }
            return View(jeuxVideo);
        }

        //// GET: JeuxVideos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jeuxVideo = await _context.JeuxVideos.FindAsync(id);
        //    if (jeuxVideo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(jeuxVideo);
        //}

        //// POST: JeuxVideos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,ImagePath")] JeuxVideo jeuxVideo)
        //{
        //    if (id != jeuxVideo.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(jeuxVideo);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!JeuxVideoExists(jeuxVideo.Id))
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
        //    return View(jeuxVideo);
        //}

        //// GET: JeuxVideos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jeuxVideo = await _context.JeuxVideos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jeuxVideo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(jeuxVideo);
        //}

        //// POST: JeuxVideos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var jeuxVideo = await _context.JeuxVideos.FindAsync(id);
        //    if (jeuxVideo != null)
        //    {
        //        _context.JeuxVideos.Remove(jeuxVideo);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool JeuxVideoExists(int id)
        //{
        //    return _context.JeuxVideos.Any(e => e.Id == id);
        //}
    }
}
