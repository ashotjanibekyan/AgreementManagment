using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using AgreementManagment.Data;
using AgreementManagment.Models;
using AgreementManagment.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AgreementManagment.Controllers
{
    [Authorize]
    public class AgreementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AgreementsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Agreements
        public async Task<IActionResult> Index()
        {
            if (_context.Agreement != null)
            {
                List<AgreementReadViewModel> agreementReadVMs = await _context.Agreement.Select(
                    agreement => new AgreementReadViewModel
                    {
                        Id = agreement.Id,
                        EffectiveDate = agreement.EffectiveDate,
                        ExpirationDate = agreement.ExpirationDate,
                        Username = _userManager.Users.First(user => user.Id == agreement.UserId).UserName,
                        GroupCode = agreement.Group.Code,
                        ProductPrice = agreement.ProductPrice,
                        NewPrice = agreement.NewPrice,
                        Number = agreement.Product.Number
                    }
                ).ToListAsync();

                return View(agreementReadVMs);
            }
            return Problem("Internal server error.");
        }

        // GET: Agreements/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = _context.Groups != null ? await _context.Groups.ToListAsync() : new List<Group>();
            ViewBag.Products = _context.Products != null ? await _context.Products.ToListAsync() : new List<Product>();
            return View();
        }

        // POST: Agreements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("GroupId,ProductId,EffectiveDate,ExpirationDate,NewPrice,IsActive")] AgreementCreateOrEditViewModel agreementViewModel)
        {
            Agreement agreement = await AgreementCreateOrEditViewModelToAgreement(agreementViewModel);

            _context.Add(agreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Agreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agreement == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreement.FindAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }
            ViewBag.Groups = _context.Groups != null ? await _context.Groups.ToListAsync() : new List<Group>();
            ViewBag.Products = _context.Products != null ? await _context.Products.ToListAsync() : new List<Product>();
            AgreementCreateOrEditViewModel agreementCreateOrEditVM = AgreementToAgreementCreateOrEditViewModel(agreement);
            return View(agreementCreateOrEditVM);
        }

        // POST: Agreements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("Id,GroupId,ProductId,EffectiveDate,ExpirationDate,NewPrice,IsActive")] AgreementCreateOrEditViewModel agreementViewModel)
        {
            Agreement agreement = await AgreementCreateOrEditViewModelToAgreement(agreementViewModel);
            if (id != agreement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgreementExists(agreement.Id))
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
            return View(agreement);
        }

        // GET: Agreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agreement == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            return View(agreement);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agreement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agreement'  is null.");
            }
            var agreement = await _context.Agreement.FindAsync(id);
            if (agreement != null)
            {
                _context.Agreement.Remove(agreement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgreementExists(int id)
        {
          return (_context.Agreement?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<Agreement> AgreementCreateOrEditViewModelToAgreement(AgreementCreateOrEditViewModel vm)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var group = await _context.Groups.FirstAsync(g => g.Id == vm.GroupId);
            var product = await _context.Products.FirstAsync(g => g.Id == vm.ProductId);


            return new Agreement()
            {
                Id = vm.Id ?? 0,
                UserId = user,
                Group = group,
                Product = product,
                EffectiveDate = vm.EffectiveDate,
                ExpirationDate = vm.ExpirationDate,
                ProductPrice = product.Price,
                NewPrice = vm.NewPrice,
            };
        }

        private AgreementCreateOrEditViewModel AgreementToAgreementCreateOrEditViewModel(Agreement agreement)
        {
            return new AgreementCreateOrEditViewModel()
            {
                Id=agreement.Id,
                EffectiveDate = agreement.EffectiveDate,
                ExpirationDate = agreement.ExpirationDate,
                GroupId = agreement.Group.Id,
                ProductId = agreement.Product.Id,
                NewPrice = agreement.ProductPrice,
            };
        }
    }
}
