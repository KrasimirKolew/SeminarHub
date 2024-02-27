using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.DataModels;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
        {
            data = context;
        }


        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .AsNoTracking()
                .Select(s => new SeminarsInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,
                    s.DateAndTime,
                    s.Organizer.UserName
                    )).ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {

            DateTime date = DateTime.Now;

            DataFormat(model, date);

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }


            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = date,
                CategoryId = model.CategoryId,
                Duration = model.Duration,
                OrganizerId = GetUserId()
            };

            await data.Seminars.AddAsync(entity);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var e = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (e.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                return RedirectToAction(nameof(All));
            }
            else
            {
                e.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = e.Id,
                    ParticipantId = userId,
                });

                await data.SaveChangesAsync();

                return RedirectToAction(nameof(Joined));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.SeminarsParticipants
                .Where(ep => ep.ParticipantId == userId)
                .AsNoTracking()
                .Select(ep => new SeminarsInfoViewModel(
                    ep.SeminarId,
                    ep.Seminar.Topic,
                    ep.Seminar.Lecturer,
                    ep.Seminar.Category.Name,
                    ep.Seminar.DateAndTime,
                    ep.Seminar.Organizer.UserName
                    ))
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await data.Seminars.FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel()
            {
                Topic = e.Topic,
                Lecturer = e.Lecturer,
                Details = e.Details,
                DateAndTime = e.DateAndTime.ToString(Constants.DateFormat),
                CategoryId = e.CategoryId,
                Duration = e.Duration,
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var e = await data.Seminars.FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime date = DateTime.Now;

            DataFormat(model, date);

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            e.Topic = model.Topic;
            e.Lecturer = model.Lecturer;
            e.Details = model.Details;
            e.DateAndTime = date;
            e.Duration = model.Duration;
            e.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var e = await data.Seminars
               .Where(e => e.Id == id)
               .Include(e => e.SeminarsParticipants)
               .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var ep = e.SeminarsParticipants
                .FirstOrDefault(ep => ep.ParticipantId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            e.SeminarsParticipants.Remove(ep);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new SeminarDetailsView()
                {
                    Id = e.Id,
                    Organizer = e.Organizer.UserName,
                    Details = e.Details,
                    Category = e.Category.Name,
                    Lecturer = e.Lecturer,
                    Duration = e.Duration,
                    Topic = e.Topic,
                    DateAndTime = e.DateAndTime.ToString(Constants.DateFormat),
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Seminars.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new DeleatViewModel()
            {
                Id = task.Id,
                Topic = task.Topic,
                DateAndTime = task.DateAndTime,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleatViewModel model)
        {
            var task = await data.Seminars
                .Where(s => s.Id == model.Id)
                .FirstOrDefaultAsync();

            var sp = await data.SeminarsParticipants
                .Where(sp => sp.SeminarId == model.Id)
                .FirstOrDefaultAsync();

            if (sp != null)
            {
                data.SeminarsParticipants.Remove(sp);
            }

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            data.Seminars.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        //Helper methods
        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private void DataFormat(SeminarFormViewModel model, DateTime data)
        {
            if (!DateTime.TryParseExact(model.DateAndTime,
                Constants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out data))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid Date! Format must be:{Constants.DateFormat}");
            }
        }
    }
}
