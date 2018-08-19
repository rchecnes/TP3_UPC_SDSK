using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class TipoSolucionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            ViewBag.SOL_ID = id;

            return View();
        }

        public ActionResult UploadFile()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string filename = "";
                    string filepath = "";

                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        filename = fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Files/"), fname);
                        file.SaveAs(fname);

                        
                        filepath = fname;
                    }
                    // Returns message that successfully uploaded  
                    //return Json(filename, "ok");

                    string[] test = new string[] { filename, filepath, "success",""};
                    return Json(test, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    //return Json("Error occurred. Error details: " + ex.Message,"error");
                    string[] test = new string[] { "", "", "error", ex.Message };
                    return Json(test, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                string[] test = new string[] { "", "", "error", "No se encontro ninguna imagen"};
                return Json(test, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
