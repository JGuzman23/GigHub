using GitHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GitHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendances.Any(a => a.AttendeeId == userId
            && a.GigId == gigId);
            if (exists)
            {
                return BadRequest("Ya existe");
            }

            var atendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(atendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
