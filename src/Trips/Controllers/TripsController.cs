using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trips.Data;

namespace Trips.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private ITripService _service;

        public TripsController(ITripService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IActionResult GetTrip()
        {

            var allTrips = _service.GetAllTrips();

            return Ok(allTrips);
        }

        [HttpGet("{id}")]
        public IActionResult GetTripById(int id)
        {
            var trip = _service.GetTripById(id);
            return Ok(trip);
        }

        [HttpGet("SingleTrip/{id}")]
        public IActionResult SingleTrip(int id)
        {
            var trip = _service.GetTripById(id);
            return Ok(trip);
        }


        [HttpGet("[action]")]
        public IActionResult GetTrips()
        {
            try
            {
                // throw new Exception();
                var allTrips = _service.GetAllTrips();
                return Ok(allTrips);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AddTrip")]
        public IActionResult AddTrip([FromBody] Trip trip)
        {
            //if (trip == null)
            //{
            //    throw new ArgumentNullException(nameof(trip));
            //}

            _service.AddTrip(trip);

            return View();
        }

        [HttpPut("UpdateTrip")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip trip)
        {
            //if (id == 0)
            //{
            //    throw new ArgumentNullException(nameof(id));
            //}

            //if (trip == null)
            //{
            //    throw new ArgumentNullException(nameof(trip));
            //}

            _service.UpdateTrip(id, trip);

            return Ok(trip);
        }

        [HttpDelete("DeleteTrip/{id}")]
        public IActionResult DeleteTrip(int id = 0)
        {
            //if (id == 0)
            //{
            //    throw new ArgumentNullException(nameof(id));
            //}

            _service.DeleteTrip(id);

            return Ok();
        }
    }
}
