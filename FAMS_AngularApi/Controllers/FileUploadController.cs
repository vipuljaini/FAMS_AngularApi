using BusinessLibrary;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using FAMS_AngularApi.Models.FileUpload;

namespace FAMS_AngularApi.Controllers
{
    public class FileUploadController : ApiController
    {
        DataTable dt; SplitCsv csv = new SplitCsv();
        [HttpPost]
        [Route("api/FileUpload/ReadCSV")]
        public Dictionary<string, object> ReadCSV()
        {
          
            FAMSEntities context = new FAMSEntities();
            try
            {
                System.Data.DataTable dt1 = new System.Data.DataTable();
                System.Data.DataTable dt2 = new System.Data.DataTable();
                DataTable totaltable = new DataTable();
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet excelRecords = new DataSet();
                var y = 0;
                var z = 0;

                if (httpRequest.Files.Count > 0)
                {
                    HttpPostedFile file = httpRequest.Files[0];
                    Stream stream = file.InputStream;


                    string FileName = Path.GetFileName(file.FileName);
                    string Extension = Path.GetExtension(file.FileName);


                    string FolderPath = HttpContext.Current.Server.MapPath("/ExportedFiles");
                    string FilePath = FolderPath + '/' + FileName;
                    if (!Directory.Exists(FolderPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                    {
                        Directory.CreateDirectory(FolderPath);
                    }

                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }
                    file.SaveAs(FilePath);

                    if (FileName.Contains("BANK BOOK") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertBankBook(FilePath);
                    }
                    if (FileName.Contains("Statement of Dividend") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertStatementOfDividend(FilePath);
                    }
                    if (FileName.Contains("Statement of Expenses") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertStatementOfExpenses(FilePath);
                    }
                    if (FileName.Contains("Transaction Statement") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertTransactionStatement(FilePath);
                    }
                    if (FileName.Contains("Statement of Capital Gain") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertCapitalStatement(FilePath);
                    }
                    if (FileName.Contains("Current Portfolio") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertCurrentPortfolio(FilePath);
                    }
                    if (FileName.Contains("Performance Appraisal") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertPerformanceAppraisal(FilePath);
                    }
                    if (FileName.Contains("Portfolio Appraisal") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertPortfolioAppraisal(FilePath);
                    }
                    if (FileName.Contains("Portfolio Fact Sheet") == true)
                    {
                        DataAccessLayer Obj = new DataAccessLayer();
                        return Obj.ReadAndInsertPortfolioFactSheet(FilePath);
                    }
                }
                return ClsJson.JsonMethods.ToJson(dt);
            }
            catch (Exception ex) { throw ex; }
        }

        }
    }
