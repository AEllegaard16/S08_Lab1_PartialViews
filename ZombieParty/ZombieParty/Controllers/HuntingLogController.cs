
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Models.Data;

public class HuntingLogController : Controller
{
    private readonly ZombiePartyDbContext _context;

    public HuntingLogController(ZombiePartyDbContext context)
    {
        _context = context;
    }

    // GET: HUNTINGLOGS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.HuntingLogs.ToListAsync());
    }

    // GET: HUNTINGLOGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var huntinglog = await _context.HuntingLogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (huntinglog == null)
        {
            return NotFound();
        }

        return View(huntinglog);
    }

    // GET: HUNTINGLOGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HUNTINGLOGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,Zombies")] HuntingLog huntinglog)
    {
        if (ModelState.IsValid)
        {
            _context.Add(huntinglog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(huntinglog);
    }

    // GET: HUNTINGLOGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var huntinglog = await _context.HuntingLogs.FindAsync(id);
        if (huntinglog == null)
        {
            return NotFound();
        }
        return View(huntinglog);
    }

    // POST: HUNTINGLOGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Description,Zombies")] HuntingLog huntinglog)
    {
        if (id != huntinglog.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(huntinglog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuntingLogExists(huntinglog.Id))
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
        return View(huntinglog);
    }

    // GET: HUNTINGLOGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var huntinglog = await _context.HuntingLogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (huntinglog == null)
        {
            return NotFound();
        }

        return View(huntinglog);
    }

    // POST: HUNTINGLOGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var huntinglog = await _context.HuntingLogs.FindAsync(id);
        if (huntinglog != null)
        {
            _context.HuntingLogs.Remove(huntinglog);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HuntingLogExists(int? id)
    {
        return _context.HuntingLogs.Any(e => e.Id == id);
    }
}
