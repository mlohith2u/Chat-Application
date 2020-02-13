using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Masters
{
    public class AuRoleMasterController : ApiController
    {
        private readonly srichidacademyEntities _db = new srichidacademyEntities();

        // GET: api/A_U_RoleMaster
        //public IQueryable<UserRole> GetA_U_RoleMaster()
        //{
        //    return _db.A_U_RoleMaster.Select(c=>new UserRole {  RoleID =c.RoleID , RoleName =c.RoleName ,CreatedBy =c.CreatedBy}).AsQueryable();
        //}

        public IQueryable<A_U_RoleMaster> GetA_U_RoleMaster()
        {
            var roleList = _db.A_U_RoleMaster.ToList();
            return roleList.AsQueryable();
        }

        public UserRole GetRoleDetails(int id)
        {
            return _db.A_U_RoleMaster.Where(u => u.RoleID == id).Select(u=>new UserRole {
             RoleID=u.RoleID , RoleName =u.RoleName , CreatedBy=u.CreatedBy }).FirstOrDefault();
        }

        // GET: api/A_U_RoleMaster/5
        [ResponseType(typeof(A_U_RoleMaster))]
        public async Task<IHttpActionResult> GetA_U_RoleMaster(int id)
        {
            A_U_RoleMaster aURoleMaster = await _db.A_U_RoleMaster.FindAsync(id);
            if (aURoleMaster == null)
            {
                return NotFound();
            }

            return Ok(aURoleMaster);
        }

        // PUT: api/A_U_RoleMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutA_U_RoleMaster(A_U_RoleMaster aURoleMaster)
        {
            var id = aURoleMaster.RoleID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aURoleMaster.RoleID)
            {
                return BadRequest();
            }

            _db.Entry(aURoleMaster).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_U_RoleMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/A_U_RoleMaster
        [ResponseType(typeof(A_U_RoleMaster))]
        public async Task<IHttpActionResult> PostA_U_RoleMaster(A_U_RoleMaster aURoleMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.A_U_RoleMaster.Add(aURoleMaster);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aURoleMaster.RoleID }, aURoleMaster);
        }

        // DELETE: api/A_U_RoleMaster/5
        [ResponseType(typeof(A_U_RoleMaster))]
        public async Task<IHttpActionResult> DeleteA_U_RoleMaster(int id)
        {
            A_U_RoleMaster aURoleMaster = await _db.A_U_RoleMaster.FindAsync(id);
            if (aURoleMaster == null)
            {
                return NotFound();
            }

            _db.A_U_RoleMaster.Remove(aURoleMaster);
            await _db.SaveChangesAsync();

            return Ok(aURoleMaster);
        }

       

        private bool A_U_RoleMasterExists(int id)
        {
            return _db.A_U_RoleMaster.Count(e => e.RoleID == id) > 0;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }

    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
    }
}