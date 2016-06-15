using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestCRUDApp.Models;
using Dapper;
using System.Web;
using Newtonsoft.Json.Linq;

namespace TestCRUDApp.Controllers
{
    [RoutePrefix("api/casestatus")]
    public class CaseStatusController : ApiController
    {
        private String connStr = ConfigurationManager.ConnectionStrings["CaseManagementAzure"].ToString();

        /// <summary>
        /// This is the method that use Entity Framework
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/v1/{id}")]
        public tbl_Status GetByIdV1(int id)
        {
            CaseManagement cm = new CaseManagement();
            var status=cm.tbl_Status.FirstOrDefault();
            return status;
        }

        [HttpGet]
        [Route("getAll/v1")]
        public IEnumerable<tbl_Status> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                var result = conn.Query<tbl_Status>("select * from tbl_status");
                return result;
            }
        }

        [HttpGet]
        [Route("getbyid/v2/{id}")]
        public tbl_Status GetByIdV2(Guid id)
        {
            
            using (IDbConnection conn = new SqlConnection(connStr))
            {

                var result=conn.Query<tbl_Status>("select * from tbl_status where status_id=@id",new {id=id});
                var status=result.FirstOrDefault();
                return status;
            }
        }

        [HttpGet]
        [Route("deletebyid/v1/{id}")]
        public HttpResponseMessage DeleteByIdV1(String id)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {

                var statusCode = conn.Execute(@"delete from tbl_status where status_id=@statusId", new { statusId =id});
                if (statusCode == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "This is OK Response");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured");
            }
        }

        [HttpPost]
        [Route("create/v1")]
        public  HttpResponseMessage CreateRecord([FromBody]JObject JData)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
               var statusCode=conn.Execute(@"insert into tbl_status values(NEWID(),@statusName)", new { statusName = JData["statusName"].Value<String>() });
                if (statusCode == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "This is OK Response");
                }
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured");
        }

        [HttpPost]
        [Route("createWithResult/v1")]
        public object CreateRecordWithResult([FromBody]JObject JData)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string statusId = Guid.NewGuid().ToString();
                string statusName = JData["statusName"].Value<String>();
                var statusCode = conn.Execute(@"insert into tbl_status values(@statusId,@statusname)", new { statusId = statusId, statusName = statusName });
                if (statusCode == 1)
                {
                    return new tbl_Status { Status_Id=new Guid(statusId), Status_Name=statusName };
                }
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured");
        }

        [HttpPost]
        [Route("edit/v1")]
        public HttpResponseMessage EditRecord([FromBody] JObject JData)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                var statusCode = conn.Execute(@"update tbl_status set status_name=@statusName where status_id=@id", new { statusName = JData["statusName"].Value<String>(), id=JData["statusId"].Value<String>()});
                if (statusCode == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "This is OK Response");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured");
            }
        }
    }
}
