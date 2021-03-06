﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


using Dto;
using Microsoft.Build.Framework;
using Serilog;

namespace ArgemanExpress.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Property")]//לכאן להוסיף את הניתוב לריאקט

    public class PropertyController : ApiController
    {
        [HttpPost]
        [Route("AddProperty")]// לבדוק איך קוראים בר
        public IHttpActionResult AddProperties([FromBody]PropertyDTO dt)
        {
            bool b = Bl.PropertyBL.AddProperty(dt);
            if (b == true)
                return Ok();
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteProperty")]// לבדוק איך קוראים בר
        public IHttpActionResult DeleteProperty(IdDto id)
        {
            bool b = Bl.PropertyBL.DeleteProperty(id.id);
            if (b == true)
                return Ok();
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdateProperty")]
        public IHttpActionResult UpdateProperty([FromBody]PropertyDTO pd)
        {
            if (Bl.PropertyBL.UpdateProperty(pd))
                return Ok();
            return BadRequest();
        }
        [HttpPost]
        [Route("Search")]
       
        public IHttpActionResult Search(PropertyDTO pd)
        {
            return Ok(Bl.PropertyBL.Search(pd.CityName, pd.StreetName,pd.Number,pd.Floor,pd.IsRented));
        }
        [Route("GetAllProperties")]
        public IHttpActionResult GetAllProperties()
        {
            System.Diagnostics.Trace.TraceInformation("come in GetAllProperties controller");

            return Ok(Bl.PropertyBL.GetAllProperties());
        }
        [HttpPost]
        [Route("GetPropertyByID")]
        public IHttpActionResult GetPropertyByID([FromBody] IdDto id)
        {
            return Ok(Bl.PropertyBL.GetPropertyByID(id.id));
        }
        //[HttpPost]
        //[Route("GetRentalByPropertyID")]
        //public IHttpActionResult GetRentalByPropertyID([FromBody]int id)
        //{
        //    return Ok(Bl.PropertyBL.GetRentalByPropertyID(id));
        //}
        //[HttpPost]
        //[Route("GetRentalBySubPropertyID")]
        //public IHttpActionResult GetRentalBySubPropertyID([FromBody] IdDto id)
        //{
        //    return Ok(Bl.PropertyBL.GetRentalBySubPropertyID(id.id));
        //}
        [HttpGet]
        [Route("hello")]
        public IHttpActionResult hello()
        {
             //Log.Logger = new LoggerConfiguration()
             //  .MinimumLevel.Debug()
             //  .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "\\logs\\logs--" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ".log", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}", shared: true)
             //  .CreateLogger();
            System.Diagnostics.Trace.WriteLine("My message!");
            System.Diagnostics.Trace.TraceInformation("My message!");

            return Ok("hello");
           
        }
        [HttpPost]
        [Route("AddCity")]// לבדוק איך קוראים בר
        public IHttpActionResult AddCity([FromBody]NameDto name)
        {
            bool b = Bl.PropertyBL.AddCity(name.name);
            if (b == true)
                return Ok();
            return BadRequest();
        }
        [Route("GetAllCities")]
        public IHttpActionResult GetAllCities()
        {
            return Ok(Bl.PropertyBL.GetAllCities());
        }
        [HttpPost]
        [Route("AddStreet")]// לבדוק איך קוראים בר
        public IHttpActionResult AddStreet([FromBody]StreetDTO sDTO)
        {
            bool b = Bl.PropertyBL.AddStreet(sDTO);
            if (b == true)
                return Ok();
            return BadRequest();
        }
        [HttpPost]
        [Route("GetStreetsByCityID")]// לבדוק איך קוראים בר
        public IHttpActionResult GetStreetsByCityID([FromBody]IdDto CityId)
        {
            return Ok(Bl.PropertyBL.GetStreetsByCityID(CityId.id));
        }
        
        [Route("GetAllStreets")]// לבדוק איך קוראים בר
        public IHttpActionResult GetAllStreets()
        {
            return Ok(Bl.PropertyBL.GetAllStreets());
        }
        //[HttpPost]
        //[Route("GetStreetByID")]// לבדוק איך קוראים בר
        //public IHttpActionResult GetStreetByID([FromBody]IdDto streetId)
        //{
        //    return Ok(Bl.PropertyBL.GetStreetByID(streetId.id));
        //}
        [Route("GetAllExclusivityPoeple")]// לבדוק איך קוראים בר
        public IHttpActionResult GetAllExclusivityPoeple()
        {
            return Ok(Bl.PropertyBL.GetAllExclusivityPoeple());
        }
        [HttpPost]
        [Route("AddExclusivityPerson")]
        public IHttpActionResult AddExclusivityPerson([FromBody]NameDto name)
        {
            bool b = Bl.PropertyBL.AddExclusivityPerson(name.name);
            if (b == true)
                return Ok();
            return BadRequest();
        }
    }
}
