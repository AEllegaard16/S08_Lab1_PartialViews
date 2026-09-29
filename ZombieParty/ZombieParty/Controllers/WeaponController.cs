using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public WeaponController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<Weapon> weapons = _baseDonnees.Weapons.ToList();
            return View(weapons);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == 0 || id == null)
            {
                return View(new Weapon()); // rempli new Weapon() après avoir consulté doc
            }
            else return View(_baseDonnees.Weapons.Find(id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Upsert(Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                // bon, mais deux dernière lignes redondantes
                if (weapon.WeaponId == 0)
                {
                    _baseDonnees.Weapons.Add(weapon);
                    TempData["Success"] = $"{weapon.Name} weapon added";
                    _baseDonnees.SaveChanges();
                    return this.RedirectToAction("Index");
                }
                else
                {
                    _baseDonnees.Weapons.Update(weapon);
                    TempData["Success"] = $"{weapon.Name} weapon has been modified";
                    _baseDonnees.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View(weapon);
        }
    }
}
