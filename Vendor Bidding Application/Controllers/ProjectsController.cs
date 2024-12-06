using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Controllers
{
    //[Authorize]
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private APIResponse _apiResponse;
        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            this._projectRepository = projectRepository;
            this._mapper = mapper;
            this._apiResponse = new();
        }
         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetProjects()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                var projectDTOs = _mapper.Map<List<ProjectDTO>>(projects);

                _apiResponse.Data = projectDTOs;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                _apiResponse.Errors.Add(ex.Message);
                return _apiResponse;
            }
        }
 
        [HttpGet("{id:int}", Name = nameof(GetProjectByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetProjectByIdAsync([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid Id!");
                }
                var project = await _projectRepository.GetAsync(id);

                if (project == null)
                {
                    return NotFound($"Project with the id {id} not found!");
                }

                var projectDTO = _mapper.Map<ProjectDTO>(project);

                _apiResponse.Data = projectDTO;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                _apiResponse.Errors.Add(ex.Message);
                return _apiResponse;
            }
        }
    }
}
