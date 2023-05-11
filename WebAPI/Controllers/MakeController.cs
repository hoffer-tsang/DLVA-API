/*==============================================================================
 *
 * Make Controller for Make related API
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using EntityFrameWorkModel;
using System.Data.Entity;
using System.Runtime.ConstrainedExecution;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Make Controller class that contain all api control for make.
    /// </summary>
    [Route("api/v1/make")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        /// <summary>
        /// Get all the car make 
        /// </summary>
        /// <returns> a list of car make </returns>
        [HttpGet]
        public ActionResult<List<Makes>> GetMake()
        {
            using (var context = new DVLAEntities())
            {
                var makes = context.Makes;
                var makeList = new List<Makes>();
                foreach(var make in makes)
                {
                    makeList.Add(MakeToMakeModel(make));
                }
                return makeList;
            }
        }
        /// <summary>
        /// get the make detail of the specific make Id
        /// </summary>
        /// <param name="id"> make id of the make </param>
        /// <returns> the make details with corresponding make id </returns>
        //GET: api/v1/make/{MakeId}
        [HttpGet("{id}")]
        public ActionResult<Makes> GetMake(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var make = context.Makes.Find(id);
                if (make == null)
                {
                    return NotFound();
                }
                return MakeToMakeModel(make);
            }
        }
        /// <summary>
        /// Return all the related models for the specific make id 
        /// </summary>
        /// <param name="id"> make id </param>
        /// <returns> list of models </returns>
        [HttpGet("{id}/models")]
        public ActionResult<List<Models.Models>> GetMakeModel(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var make = context.Makes.Find(id);
                if (make == null)
                {
                    return NotFound();
                }
                var models = make.Models;
                var modelList = new List<Models.Models>();
                foreach( var model in models)
                {
                    modelList.Add(ModelToModelAPIModel(model));
                }
                return modelList;
            }
        }
        /// <summary>
        /// Convert Make to API output Make Model
        /// </summary>
        /// <param name="make"> entity framework make model </param>
        /// <returns> API output make model </returns>
        private Makes MakeToMakeModel(Make make)
        {
            return new Makes
            {
                MakeId = make.MakeId,
                MakeName = make.Name
            };
        }
        /// <summary>
        /// Convert Model To API output Model
        /// </summary>
        /// <param name="model"> entity framework model </param>
        /// <returns> Model API Output</returns>
        private Models.Models ModelToModelAPIModel(Model model)
        {
            return new WebAPI.Models.Models
            {
                ModelId = model.ModelId,
                ModelName = model.Name
            };
        }
    }
}
