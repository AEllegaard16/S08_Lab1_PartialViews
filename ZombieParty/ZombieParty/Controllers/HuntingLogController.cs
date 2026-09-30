
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

    public async Task<IActionResult> Index()
    {
        List<HuntingLog> huntingLogs = _context.HuntingLogs.ToList();
        return View(huntingLogs);
    }

    public IActionResult Upsert(int? id)
    {
        if (id == 0 || id == null)
        {
            return View(new HuntingLog());
        }
        else return View(_context.HuntingLogs.Find(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(HuntingLog huntinglog)
    {
        if (ModelState.IsValid)
        {
            // bon, mais deux dernière lignes redondantes
            if (huntinglog.Id == 0)
            {
                _context.HuntingLogs.Add(huntinglog);
                TempData["Success"] = $"{huntinglog.Title} log added";
            }
            else
            {
                _context.HuntingLogs.Update(huntinglog);
                TempData["Success"] = $"{huntinglog.Title} has been modified";
            }
            _context.SaveChanges();
            return this.RedirectToAction("Index");
        }

        return this.View(huntinglog);
    }
}
