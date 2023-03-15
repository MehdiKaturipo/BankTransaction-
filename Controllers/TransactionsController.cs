using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PassBook.Models;

namespace PassBook.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionsController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Transactions.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Rapport(int? id) 
        {

            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Create  METHODE 1
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TransactionId,AccountNumber,BenificiaryName,BankName,SWIFTCode,Amount,Date")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        transaction.Date = DateTime.Now; 
        //        _context.Add(transaction);
        //        await _context.SaveChangesAsync();
        //        TempData["success"] = "Transaction created successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transaction);
        //}


        // POST: Transactions/Create METHODE 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction obj)
        {
            if (obj.BenificiaryName == obj.AccountNumber.ToString())
            {
                ModelState.AddModelError("BenificiaryName", "The AccountNumber cannot exactly match the BenificiaryName.");
            }
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Transacton created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Transactions/Edit/5  METHODE 1
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transactions.FindAsync(id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(transaction);
        //}


        //GET METHODE 2 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TransactionFromDb = _context.Transactions.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (TransactionFromDb == null)
            {
                return NotFound();
            }

            return View(TransactionFromDb);
        }


        // POST: Transactions/Edit/5    METHODE 1 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TransactionId,AccountNumber,BenificiaryName,BankName,SWIFTCode,Amount,Date")] Transaction transaction)
        //{
        //    if (id != transaction.TransactionId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            transaction.Date = DateTime.Now;
        //            _context.Update(transaction);
        //            await _context.SaveChangesAsync();
        //            TempData["success"] = "Transacton Updated successfully";
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TransactionExists(transaction.TransactionId))
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
        //    return View(transaction);
        //}

       //POST  METHODE 2 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Transaction obj)
        {
            if (obj.BenificiaryName == obj.AccountNumber.ToString())
            {
                ModelState.AddModelError("BenificiaryName", "The AccountNumber cannot exactly match the BenificiaryName.");
            }
            if (ModelState.IsValid)
            {
                _context.Transactions.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Transaction Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }





        // POST: Transactions/Delete/5  METHODE 1
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Transactions == null)
        //    {
        //        return Problem("Entity set 'TransactionDbContext.Transactions'  is null.");
        //    }
        //    var transaction = await _context.Transactions.FindAsync(id);
        //    if (transaction != null)
        //    {
        //        _context.Transactions.Remove(transaction);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    TempData["success"] = "Transacton Deleted successfully";
        //    return RedirectToAction(nameof(Index));
        //}
        // DELETE METHODE 2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Transactions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Transaction deleted successfully";
            return RedirectToAction("Index");

        }


        private bool TransactionExists(int id)
        {
          return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
