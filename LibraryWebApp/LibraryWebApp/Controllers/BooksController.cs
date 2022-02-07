using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books/OrderByName
        public async Task<IActionResult> OrderByName()
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory).OrderBy(b => b.Name);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Books/OrderByNameDescending
        public async Task<IActionResult> OrderByNameDescending()
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory).OrderByDescending(b => b.Name);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Books/OrderByAuthor
        public async Task<IActionResult> OrderByAuthor()
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory).OrderBy(b => b.Author);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Books/OrderByCategory
        public async Task<IActionResult> OrderByCategory()
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory).OrderBy(b => b.BookCategoryId);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Books/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Books/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            var applicationDbContext = _context.Book.Include(b => b.BookCategory).Where(b => b.Name.Contains(SearchPhrase) || b.Author.Contains(SearchPhrase) ||
            b.ISBN.Contains(SearchPhrase));
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategory, "BookCategoryId", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Name,Author,ISBN,BookCategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategory, "BookCategoryId", "Name", book.BookCategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategory, "BookCategoryId", "Name", book.BookCategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Name,Author,ISBN,BookCategoryId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategory, "BookCategoryId", "Name", book.BookCategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }

    }
}
