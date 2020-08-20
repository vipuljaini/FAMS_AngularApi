using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net.Http;
using BusinessLibrary;

using EntityDAL;
using Encryptions;
using System.Data;
using FAMS_AngularApi.Models;
using System.Reflection;
using Newtonsoft.Json;
using System.Xml;
using FAMS_AngularApi.Models.AutoReportRequest;

namespace FAMS_AngularApi.Models.AutoReportRequest
{
    public class AutoReportRequest
    {
        FAMSEntities dbcontext = new FAMSEntities();
        public string GetXmlByDatable(DataTable dtObjectforXml)
        {
            if (dtObjectforXml == null)
                return "";
            if (dtObjectforXml.Rows.Count == 0)
                return "";

            if (dtObjectforXml.TableName == "")
                dtObjectforXml.TableName = "dtXml";

            XmlDocument objectXmlDocument = new XmlDocument();
            XmlElement objElement = objectXmlDocument.CreateElement(dtObjectforXml.TableName);

            for (int iRecordCounter = 0; iRecordCounter < dtObjectforXml.Rows.Count; iRecordCounter++)
            {
                // Generate XmlObject and Append Nodes by calling a Child function.
                objElement.AppendChild(BuildXmlElement(dtObjectforXml.Rows[iRecordCounter], objectXmlDocument));
            }

            objectXmlDocument.AppendChild(objElement);
            return objectXmlDocument.OuterXml;
        }

        private XmlElement BuildXmlElement(DataRow drObjectforXml, XmlDocument objectXmlDocument)
        {
            XmlElement XmlElement = objectXmlDocument.CreateElement(drObjectforXml.Table.TableName);
            for (int iColumnCounter = 0; iColumnCounter < drObjectforXml.Table.Columns.Count; iColumnCounter++)
            {
                XmlElement.SetAttribute(drObjectforXml.Table.Columns[iColumnCounter].ColumnName, Convert.ToString(drObjectforXml[iColumnCounter].ToString()));
            }

            return XmlElement;
        }

        public Dictionary<string, object> SaveAutoReportRequest(string EData)
        {
            DataTable dts = (DataTable)JsonConvert.DeserializeObject(EData, (typeof(DataTable)));
            string Insert_MandateID_BulkSMS_xml = GetXmlByDatable(dts);
            //DataTable dt = CommonManger.FillDatatableWithParam("Sp_SendEmail", "@QueryType", "@Insert_MandateID_BulkSMS_xml", "@Activity", "Insert_MandateID_BulkSMS", Insert_MandateID_BulkSMS_xml, ActivityID);

            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<Result>().Execute("@QueryType", "@Insert_MandateID_BulkSMS_xml", "SaveAutoReportRequest", Insert_MandateID_BulkSMS_xml));
            return Result;
        }

        public Dictionary<string, object> BindAutoReportRequest(JsonFields Data)
        {
            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<BindAutoReportRequestData>().Execute("@QueryType", "@CustomerAccount", "BindAutoReportRequest", Data.CustomerAccount));
            return Result;
        }

        public Dictionary<string, object> BindAllAutoReportRequest()
        {
            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<BindAllAutoReportRequestData>().Execute("@QueryType", "BindAllAutoReportRequest"));
            return Result;
        }
    }
}