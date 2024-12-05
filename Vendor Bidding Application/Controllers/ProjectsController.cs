using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            this._projectRepository = projectRepository;
            this._mapper = mapper;
        }
         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                var projectDTOs = _mapper.Map<List<ProjectDTO>>(projects);
                return Ok(projectDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"An error occurred while retrieving projects: {ex.Message}" });
            }
        }
 
        [HttpGet("{id:int}", Name = nameof(GetProjectByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDTO>> GetProjectByIdAsync([FromRoute] int id)
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

                return Ok(projectDTO);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"An error occurred while retrieving a project: {ex.Message}" });
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProjectDTO>> PostProjectAsync([FromBody] CreateProjectDTO projectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var model = _mapper.Map<Project>(projectDTO);

                var project = await _projectRepository.AddAsync(model);

                var obj = _mapper.Map<ProjectDTO>(project);

                return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = obj.Id }, obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"An error occurred while creating a project: {ex.Message}" });
            }
        }
    }

}
