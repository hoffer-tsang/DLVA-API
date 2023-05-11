/*==============================================================================
 *
 * Colour Controller for colour related API
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
    /// Colour Controller class that contain all api control for colour.
    /// </summary>
    [Route("api/v1/colours")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        /// <summary>
        /// Get all the colour model
        /// </summary>
        /// <returns> a list of colour model </returns>
        [HttpGet]
        public ActionResult<List<Colours>> GetColour()
        {
            using (var context = new DVLAEntities())
            {
                var colours = context.Colours;
                var colourList = new List<Colours>();
                foreach (var colour in colours)
                {
                    colourList.Add(ColourToColourModel(colour));
                }
                return colourList;
            }
        }
        /// <summary>
        /// get the colour detail of the specific colour Id
        /// </summary>
        /// <param name="id">colour id of the colour </param>
        /// <returns> the colour details with corresponding colour id </returns>
        //GET: api/v1/colour/{ColourId}
        [HttpGet("{id}")]
        public ActionResult<Colours> GetColour(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var colour = context.Colours.Find(id);
                if (colour == null)
                {
                    return NotFound();
                }
                return ColourToColourModel(colour);
            }
        }
        /// <summary>
        /// Convert Colour to API output Colour Model
        /// </summary>
        /// <param name="colour"> entity framework colour model </param>
        /// <returns> API output colour model </returns>
        private Colours ColourToColourModel(Colour colour)
        {
            return new Colours
            {
                ColourId = colour.ColourId,
                ColourName = colour.Name
            };
        }
    }
}
