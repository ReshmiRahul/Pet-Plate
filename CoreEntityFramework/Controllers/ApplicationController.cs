using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoption;
using PetAdoption.Models;
using PetAdoption.Interfaces;

namespace PetAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _ApplicationService;

        // dependency injection of service interfaces
        public ApplicationController(IApplicationService ApplicationService)
        {
            _ApplicationService = ApplicationService;
        }


        /// <summary>
        /// Returns a list of Ordered Items, each represented by an ApplicationDto with their associated Pet, Order, and Customer
        /// </summary>
        /// <returns>
        /// 200 OK
        /// [{ApplicationDto},{ApplicationDto},..]
        /// </returns>
        /// <example>
        /// GET: api/Applications/List -> [{ApplicationDto},{ApplicationDto},..]
        /// </example>
        [HttpGet(template: "List")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> ListApplications()
        {
            // returns a list of Account item dtos
            IEnumerable<ApplicationDto> ApplicationDtos = await _ApplicationService.ListApplications();
            // return 200 OK with ApplicationDtos
            return Ok(ApplicationDtos);
        }

        /// <summary>
        /// Returns a single Item specified by its {id}, represented by an Account Item Dto with its associated Pet, Order, and Customer
        /// </summary>
        /// <param name="id">The ordered item id</param>
        /// <returns>
        /// 200 OK
        /// {ApplicationDto}
        /// or
        /// 404 Not Found
        /// </returns>
        /// <example>
        /// GET: api/Applications/Find/1 -> {ApplicationDto}
        /// </example>
        [HttpGet(template: "Find/{id}")]
        public async Task<ActionResult<ApplicationDto>> FindApplication(int id)
        {
            // include will join order(i)tem with 1 Pet, 1 order, 1 customer
            // first or default async will get the first order(i)tem matching the {id}
            var Application = await _ApplicationService.FindApplication(id);

            // if the item could not be located, return 404 Not Found
            if (Application == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Application);
            }
        }

        /// <summary>
        /// Updates an Ordered Item
        /// </summary>
        /// <param name="id">The ID of Order Item to update</param>
        /// <param name="ApplicationDto">The required information to update the ordered item (ApplicationId, ApplicationUnitPrice,ApplicationQty,PetId,OrderId)</param>
        /// <returns>
        /// 400 Bad Request
        /// or
        /// 404 Not Found
        /// or
        /// 204 No Content
        /// </returns>
        [HttpPut(template: "Update/{id}")]
        public async Task<ActionResult> UpdateApplication(int id, ApplicationDto ApplicationDto)
        {
            // {id} in URL must match ApplicationId in POST Body
            if (id != ApplicationDto.ApplicationID)
            {
                //400 Bad Request
                return BadRequest();
            }

            ServiceResponse response = await _ApplicationService.UpdateApplication(ApplicationDto);

            if (response.Status == ServiceResponse.ServiceStatus.NotFound)
            {
                return NotFound(response.Messages);
            }
            else if (response.Status == ServiceResponse.ServiceStatus.Error)
            {
                return StatusCode(500, response.Messages);
            }

            //Status = Updated
            return NoContent();

        }

        /// <summary>
        /// Adds an Order Item
        /// </summary>
        /// <param name="ApplicationDto">The required information to add the ordered item (ApplicationUnitPrice,ApplicationQty,PetId,OrderId)</param>
        /// <example>
        /// POST api/Application/Add
        /// </example>
        /// <returns>
        /// 201 Created
        /// Location: api/Application/Find/{ApplicationId}
        /// {ApplicationDto}
        /// or
        /// 404 Not Found
        /// </returns>
        [HttpPost(template: "Add")]
        public async Task<ActionResult<Application>> AddApplication(ApplicationDto ApplicationDto)
        {
            ServiceResponse response = await _ApplicationService.AddApplication(ApplicationDto);

            if (response.Status == ServiceResponse.ServiceStatus.NotFound)
            {
                return NotFound(response.Messages);
            }
            else if (response.Status == ServiceResponse.ServiceStatus.Error)
            {
                return StatusCode(500, response.Messages);
            }

            // returns 201 Created with Location
            return Created($"api/Application/Find/{response.CreatedId}", ApplicationDto);
        }

        /// <summary>
        /// Deletes the Ordered Item
        /// </summary>
        /// <param name="id">The id of the Order Item to delete</param>
        /// <returns>
        /// 201 No Content
        /// or
        /// 404 Not Found
        /// </returns>
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteApplication(int id)
        {
            ServiceResponse response = await _ApplicationService.DeleteApplication(id);

            if (response.Status == ServiceResponse.ServiceStatus.NotFound)
            {
                return NotFound();
            }
            else if (response.Status == ServiceResponse.ServiceStatus.Error)
            {
                return StatusCode(500, response.Messages);
            }

            return NoContent();

        }


        //ListApplicationsForOrder
        [HttpGet(template: "ListForAccount/{id}")]
        public async Task<IActionResult> ListApplicationsForAccount(int id)
        {
            // empty list of data transfer object ApplicationDto
            IEnumerable<ApplicationDto> ApplicationDtos = await _ApplicationService.ListApplicationsForAccount(id);
            // return 200 OK with ApplicationDtos
            return Ok(ApplicationDtos);
        }


        //ListApplicationsForPet
        [HttpGet(template: "ListForPet/{id}")]
        public async Task<IActionResult> ListApplicationsForPet(int id)
        {
            // empty list of data transfer object ApplicationDto
            IEnumerable<ApplicationDto> ApplicationDtos = await _ApplicationService.ListApplicationsForPet(id);
            // return 200 OK with ApplicationDtos
            return Ok(ApplicationDtos);
        }


    }
}
