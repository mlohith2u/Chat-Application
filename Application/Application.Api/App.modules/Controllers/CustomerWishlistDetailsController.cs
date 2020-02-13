using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Bal.Viewmodels;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Controllers
{
    public class CustomerWishlistDetailsController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/CustomerWishlistDetails
        public IQueryable<CustomerWishlistDetail> GetCustomerWishlistDetails()
        {
            return db.CustomerWishlistDetails;
        }

        //public IHttpActionResult GetWishlist()
        //{
        //    CartDetails dd = new CartDetails();
        //    var MachineID = GenerateMachineId();
        //    var aa = db.CustomerWishlistDetails.Where(c => c.MachineId == MachineID).ToList();
        //    foreach(var item in aa)
        //    {

        //    }
        //    return Ok(aa);
        //}

        // GET: api/CustomerWishlistDetails/5
        [ResponseType(typeof(CustomerWishlistDetail))]
        public async Task<IHttpActionResult> GetCustomerWishlistDetail(int id)
        {
            CustomerWishlistDetail customerWishlistDetail = await db.CustomerWishlistDetails.FindAsync(id);
            if (customerWishlistDetail == null)
            {
                return NotFound();
            }

            return Ok(customerWishlistDetail);
        }

        // PUT: api/CustomerWishlistDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerWishlistDetail(int id, CustomerWishlistDetail customerWishlistDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerWishlistDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(customerWishlistDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerWishlistDetailExists(id))
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

        public IHttpActionResult GetWishlist()
        {
            List<WishlistDetails> data = new List<WishlistDetails>();
            var MachineID = GenerateMachineId();
            var aa = db.CustomerWishlistDetails.Where(c => c.MachineId == MachineID && c.IsMovedtoCart == false).ToList();
            foreach (var item in aa)
            {
                WishlistDetails _pdd = new WishlistDetails
                {
                    CustomerId = item.CustomerId,
                    Id = item.Id,
                    IsMovedtoCart = item.IsMovedtoCart,
                    ItemId = item.ItemId,
                    LastUpdated = item.LastUpdated,
                    MachineId = item.MachineId,
                    Image = db.MenuCategories.Where(c=>c.MenuId== item.ItemId).Select(c=>c.Image).FirstOrDefault(),
                    MenuName = db.MenuCategories.Where(c => c.MenuId == item.ItemId).Select(c => c.MenuName).FirstOrDefault(),
                    Quantity = item.Quantity,
                    RatePerItem = item.RatePerItem,
                    TotalAmount = item.TotalAmount
                };
                data.Add(_pdd);
            }
            return Ok(data);
        }

        public string GetImage(string id)
        {
            var Img = string.Empty;
            const string queryString = "SELECT *  FROM  [dbo].[MenuCategory] WHERE MenuId = @ID";
            const string connectionString = "Server=DESKTOP-LJNGLOU;Database=MaterialGrid;User Id=sa;Password=sa@123;";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Img = Convert.ToString(reader["Image"]);
                    //byte[] Bytes = (byte[])SQLreader("ImageList");
                }
                reader.Close();
                return Img;
            }
        }

        public string GenerateMachineId()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }

        // POST: api/CustomerWishlistDetails
        [ResponseType(typeof(CustomerWishlistDetail))]
        public async Task<IHttpActionResult> PostCustomerWishlistDetail(CustomerWishlistDetail customerWishlistDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerWishlistDetails.Add(customerWishlistDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerWishlistDetail.Id }, customerWishlistDetail);
        }

        // DELETE: api/CustomerWishlistDetails/5
        [ResponseType(typeof(CustomerWishlistDetail))]
        public async Task<IHttpActionResult> DeleteCustomerWishlistDetail(int id)
        {
            CustomerWishlistDetail customerWishlistDetail = await db.CustomerWishlistDetails.FindAsync(id);
            if (customerWishlistDetail == null)
            {
                return NotFound();
            }

            db.CustomerWishlistDetails.Remove(customerWishlistDetail);
            await db.SaveChangesAsync();

            return Ok(customerWishlistDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerWishlistDetailExists(int id)
        {
            return db.CustomerWishlistDetails.Count(e => e.Id == id) > 0;
        }

    }
}