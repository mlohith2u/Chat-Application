using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Managemenu.Controllers
{
    public class MenuMasterController : ApiController
    {
        private readonly srichidacademyEntities _db = new srichidacademyEntities();
        // to Search Menu Details and display the result

        [HttpGet]
        public IEnumerable<PROC_Menu_Select_Result> GetMenuCrudSelect(string menuId, string menuName)
        {
            if (menuId == null)
                menuId = "";
            if (menuName == null)
                menuName = "";
            return _db.PROC_Menu_Select(menuId, menuName).AsEnumerable();
        }
        // To get all user role from ASPNETRoels Table
        [HttpGet]
        public IEnumerable<PROC_UserRoles_Select_Result> GetUserRoleDetails(string userRole)
        {
            if (userRole == null)
                userRole = "";
            return _db.PROC_UserRoles_Select(userRole).AsEnumerable();
        }
        [HttpGet]
        public IQueryable<A_U_MenuMaster> GetA_U_MenuMaster()
        {
            return _db.A_U_MenuMaster;
        }

        [ResponseType(typeof(A_U_MenuMaster))]
        public async Task<IHttpActionResult> GetOneMenu(int id)
        {
            A_U_MenuMaster menuMaster = await _db.A_U_MenuMaster.FindAsync(id);
            if (menuMaster == null)
            {
                return NotFound();
            }

            return Ok(menuMaster);
          
        }

        [HttpGet]
        
        [ResponseType(typeof(A_U_MenuMaster))]
        public async Task<IHttpActionResult> GetMenuMaster(int id)
        {
            var menu = _db.A_U_MenuMaster.Where(c => c.User_Roll == id && c.MenuID != "masters").ToList();

            return Ok(menu);
        }

        [HttpGet]

        [ResponseType(typeof(A_U_MenuMaster))]
        public async Task<IHttpActionResult> GetMasterMenus(int id)
        {
            var menu = _db.A_U_MenuMaster.Where(c => c.User_Roll == id && c.MenuID == "masters").ToList();

            return Ok(menu);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetA_U_Menu(int id)
        {

            var info = _db.A_U_MenuMaster.Where(c => c.MenuIdentity == id).FirstOrDefault();
            return Ok(info);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutA_U_Menu(A_U_MenuMaster menuMaster)
        {
            var id = menuMaster.MenuIdentity;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuMaster.MenuIdentity)
            {
                return BadRequest();
            }

           

            try
            {
                _db.Entry(menuMaster).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
                //if (!A_U_MenuMasterExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool A_U_MenuMasterExists(int id)
        {
            return _db.A_U_MenuMaster.Count(e => e.MenuIdentity == id) > 0;
        }

        [HttpGet]
        public IEnumerable<PROC_MenubyUserRole_Select_Result> GetMenubyUserRole(string userRole)
            {
            if (userRole == null)
                userRole = "";
            return _db.PROC_MenubyUserRole_Select(userRole).AsEnumerable();
        }

        // POST: api/A_U_MenuMaster
        [ResponseType(typeof(A_U_MenuMaster))]
        public async Task<IHttpActionResult> PostA_U_MenuMaster(A_U_MenuMaster aUMenueMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.A_U_MenuMaster.Add(aUMenueMaster);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aUMenueMaster.MenuIdentity }, aUMenueMaster);
        }

        // DELETE: api/A_U_MenuMaster/5
        [ResponseType(typeof(A_U_MenuMaster))]
        public async Task<IHttpActionResult> DeleteA_U_MenuMaster(int id)
        {
            A_U_MenuMaster aUMenuMaster = _db.A_U_MenuMaster.Where(c => c.MenuIdentity == id).FirstOrDefault();
           // A_U_MenuMaster aUMenuMaster = await _db.A_U_MenuMaster.FindAsync(id);
            if (aUMenuMaster == null)
            {
                return NotFound();
            }

            _db.A_U_MenuMaster.Remove(aUMenuMaster);
            await _db.SaveChangesAsync();

            return Ok(aUMenuMaster);
        }

        // To Insert new Menu Details
        [HttpPost]
        public IEnumerable<string> InsertMenu(string menuId, string menuName, string parentMenuId, int userRole, string menuFileName, string menuUrl, string useYn)
        {
            return _db.PROC_Menu_Insert(menuId, menuName, parentMenuId, userRole, menuFileName, menuUrl, useYn).AsEnumerable();
        }
        //to Update Menu Details  
        [HttpGet]
        public IEnumerable<string> UpdateMenu(int menuIdentity, string menuId, string menuName, string parentMenuId, int userRole, string menuFileName, string menuUrl, string useYn)
        {
           return  _db.PROC_Menu_Update(menuIdentity, menuId, menuName, parentMenuId, userRole, menuFileName, menuUrl, useYn).AsEnumerable(); 
        }
        //to Delete Menu Details  
        [HttpDelete]
        public virtual string DeleteMenu(int menuIdentity)
        {
            _db.PROC_Menu_Delete(menuIdentity);
            _db.SaveChanges();
            return "deleted";
        }
    }
}
