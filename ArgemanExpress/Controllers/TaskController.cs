﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;

namespace ArgemanExpress.Controllers
{   [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Task")]
    //[Authorize(Roles =]
    public class TaskController : ApiController
    {
        [Route("AddTask")]// לבדוק איך קוראים בר
        public IHttpActionResult AddTask([FromBody]TaskDTO dt)
        {
            bool b = Bl.TaskBL.AddTask(dt);
            if (b == true)
                return Ok();
            return BadRequest();
        }
        [Route("UpdateTask")]
        public IHttpActionResult UpdateTask([FromBody]TaskDTO pd)
        {
            if (Bl.TaskBL.UpdateTask(pd))
                return Ok();
            return BadRequest();
        }
        [Route("Search")]
        public IHttpActionResult Search(Nullable<int> TaskTypeId, Nullable<int> PropertyID, Nullable<int> ClassificationID, Nullable<System.DateTime> ReportDate, System.DateTime DateForHandling, Nullable<bool> IsHandled, Nullable<System.DateTime> HandlingDate)
        {
            return Ok(Bl.TaskBL.Search(TaskTypeId, PropertyID, ClassificationID, ReportDate, DateForHandling, IsHandled, HandlingDate));
        }
        [Route("GetAllTasks")]
        public IHttpActionResult GetAllTasks()
        {
            return Ok(Bl.TaskBL.GetAllTasks());
        }
        [Route("GetTypeName")]
        public IHttpActionResult GetTypeName(int id)
        {
            return Ok(Bl.TaskBL.GetTypeName(id));
        }
        
        //[Route("IsTakala")]
        //public IHttpActionResult IsTakala(int id)
        //{
        //    return Ok(Bl.TaskBL.IsTakala(id));
        //}
        [Route("GetClassificationName")]
        //public IHttpActionResult GetClassificationName(int id)
        //{
        //    return Ok(Bl.TaskBL.GetClassificationName(id));
        //}
        [Route("GetAllClassificationTypes")]
        public IHttpActionResult GetAllClassificationTypes()
        {
            return Ok(Bl.TaskBL.GetAllClassificationTypes());
        }
        [Route("GetAllTaskTypes")]
        public IHttpActionResult GetAllTaskTypes()
        {
            return Ok(Bl.TaskBL.GetAllTaskTypes());
        }

    }
}
