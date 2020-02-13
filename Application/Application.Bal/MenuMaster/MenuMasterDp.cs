using Application.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bal.MenuMaster
{
    public static class MenuMasterDp
    {
        static HMSEntities _db;
        static MenuMasterDp()
        {
            new HMSEntities();
        }
        public static IEnumerable<PROC_Menu_Select_Result> MenuSelect(string menuId, string menuName)
        {
            return _db.PROC_Menu_Select(menuId, menuName).AsEnumerable();
        }
        public static IEnumerable<PROC_UserRoles_Select_Result> GetUserRole(string userRole)
        {
            return _db.PROC_UserRoles_Select(userRole).AsEnumerable();
        }
        public static IQueryable<A_U_MenuMaster> GetA_U_Menu()
        {
            return _db.A_U_MenuMaster;
        }
        public static IEnumerable<PROC_MenubyUserRole_Select_Result> GetMenuByRole(string userRole)
        {
            return _db.PROC_MenubyUserRole_Select(userRole).AsEnumerable();
        }
        public static IEnumerable<string> InsertingMenu(string menuId, string menuName, string parentMenuId, int userRole, string menuFileName, string menuUrl, string useYn)
        {
            return _db.PROC_Menu_Insert(menuId, menuName, parentMenuId, userRole, menuFileName, menuUrl, useYn).AsEnumerable();
        }
        public static IEnumerable<string> UpdatingMenu(int menuIdentity, string menuId, string menuName, string parentMenuId, int userRole, string menuFileName, string menuUrl, string useYn)
        {
            return _db.PROC_Menu_Update(menuIdentity, menuId, menuName, parentMenuId, userRole, menuFileName, menuUrl, useYn).AsEnumerable();
        }
        public static string Deletingmenu(int menuIdentity)
        {
            _db.PROC_Menu_Delete(menuIdentity);
            _db.SaveChanges();
            return "deleted";
        }
    }
}
