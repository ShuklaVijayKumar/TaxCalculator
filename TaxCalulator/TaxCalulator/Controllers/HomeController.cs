using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxCalulator.DAL;
using TaxCalulator.Models;

namespace TaxCalulator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Upload()
        {
            var result = new List<UploadFilesResult>();
            var transactionDataContext = new TransactinDataContext();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", savedFileName);

                string query = String.Format("SELECT * from [{0}$]", "Sheet1");
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
                var ds = new DataSet();

                dataAdapter.Fill(ds);

                var transactionData = new TransactionData();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    transactionData.Account = Convert.ToString(dr["Account"]);
                    transactionData.Description = Convert.ToString(dr["Description"]);
                    transactionData.CurrencyCode = Convert.ToString(dr["CurrencyCode"]);
                    transactionData.Amount = Convert.ToInt32(dr["Amount"]);

                    transactionDataContext.TransactionsData.Add(transactionData);
                }

                transactionDataContext.SaveChanges();

                result.Add(new UploadFilesResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + result[0].Name + "\",\"type\":\"" + result[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", result[0].Length) + "\"}", "application/json");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}