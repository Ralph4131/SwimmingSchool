using Microsoft.AspNetCore.Mvc;
using Session; 
using System.Linq;
using System.Threading.Tasks;

public class SwimmerProfileController : Controller
{
    private readonly ApplicationDbContext _dbContext; 
    public SwimmerProfileController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> MyProfile(int id)
    {
        var swimmer = await _dbContext.Swimmers.FindAsync(id);

        if (swimmer == null)
        {
            return NotFound();
        }

        return View(swimmer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MyProfile(int id, [Bind("Id,Name,PhoneNumber")] Swimmer updatedSwimmer)
    {
        if (id != updatedSwimmer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _dbContext.Update(updatedSwimmer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(MyProfile), new { id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Swimmers.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(updatedSwimmer);
    }
}
