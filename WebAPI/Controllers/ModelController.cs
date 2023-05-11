/*==============================================================================
 *
 * Model Controller for Model related API
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
    /// Model Controller class that contain all api control for model.
    /// </summary>
    [Route("api/v1/models")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        /// <summary>
        /// Get all the car model
        /// </summary>
        /// <returns> a list of car model </returns>
        [HttpGet]
        public ActionResult<List<Models.Models>> GetModel()
        {
            using (var context = new DVLAEntities())
            {
                var models = context.Models;
                var modelList = new List<Models.Models>();
                foreach (var model in models)
                {
                    modelList.Add(ModelToModelAPIModel(model));
                }
                return modelList;
            }
        }
        /// <summary>
        /// get the model detail of the specific model Id
        /// </summary>
        /// <param name="id"> model id of the model </param>
        /// <returns> the model details with corresponding model id </returns>
        //GET: api/v1/model/{ModelId}
        [HttpGet("{id}")]
        public ActionResult<Models.Models> GetModel(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var model = context.Models.Find(id);
                if (model == null)
                {
                    return NotFound();
                }
                return ModelToModelAPIModel(model);
            }
        }
        /// <summary>
        /// Return make for the specific model id 
        /// </summary>
        /// <param name="id"> model id </param>
        /// <returns> make </returns>
        [HttpGet("{id}/make")]
        public ActionResult<Makes> GetModelMake (int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var model = context.Models.Find(id);
                if (model == null)
                {
                    return NotFound();
                }
                var make = model.Make;
                return MakeToMakeModel(make);
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
