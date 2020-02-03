using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using MVC_LoginRegister.Models;

namespace MVC_LoginRegister.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }

        public async Task<ActionResult> GetDataRoles()
        {
            var result = await sqlConn.QueryAsync<RoleVM>("EXEC SP_Retrieve_Roles ");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRow = await sqlConn.ExecuteAsync("EXEC SP_Insert_Role @Name", new { Name = roleVM.Name });
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> Edit(int id,RoleVM roleVM)
        {
            var result = await sqlConn.ExecuteAsync("EXEC SP_Update_Role @id,@Name", new { Id=id, Name = roleVM.Name });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var result = await sqlConn.ExecuteAsync("EXEC SP_Delete_Role @id" , new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var result = await sqlConn.QueryAsync<RoleVM>("EXEC SP_Get_RoleById @Id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);

        }

        
    }
}