//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using VCardMVC.Models;

//namespace VCardMVC.Views.Card
//{
//    public class CardController : Controller
//    {
//        private readonly vcardContext _context;

//        public CardController(vcardContext context)
//        {
//            _context = context;
//        }

//        // GET: Card
//        public async Task<IActionResult> Index()
//        {
//              return _context.VCards != null ? 
//                          View(await _context.VCards.ToListAsync()) :
//                          Problem("Entity set 'vcardContext.VCards'  is null.");
//        }

//        // GET: Card/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.VCards == null)
//            {
//                return NotFound();
//            }

//            var vCard = await _context.VCards
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (vCard == null)
//            {
//                return NotFound();
//            }

//            return View(vCard);
//        }

//        // GET: Card/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Card/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,First,Last,Email,Phone,Country,City,Gender")] VCard vCard)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(vCard);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(vCard);
//        }

//        // GET: Card/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.VCards == null)
//            {
//                return NotFound();
//            }

//            var vCard = await _context.VCards.FindAsync(id);
//            if (vCard == null)
//            {
//                return NotFound();
//            }
//            return View(vCard);
//        }

//        // POST: Card/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,First,Last,Email,Phone,Country,City,Gender")] VCard vCard)
//        {
//            if (id != vCard.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(vCard);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!VCardExists(vCard.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(vCard);
//        }

//        // GET: Card/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.VCards == null)
//            {
//                return NotFound();
//            }

//            var vCard = await _context.VCards
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (vCard == null)
//            {
//                return NotFound();
//            }

//            return View(vCard);
//        }

//        // POST: Card/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.VCards == null)
//            {
//                return Problem("Entity set 'vcardContext.VCards'  is null.");
//            }
//            var vCard = await _context.VCards.FindAsync(id);
//            if (vCard != null)
//            {
//                _context.VCards.Remove(vCard);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool VCardExists(int id)
//        {
//          return (_context.VCards?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
