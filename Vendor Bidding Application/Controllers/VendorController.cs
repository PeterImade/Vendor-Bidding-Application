using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Controllers
{
    [Route("api/vendors")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorController(IVendorRepository vendorRepository, IMapper mapper)
        {
            this._vendorRepository = vendorRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetVendorByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> GetVendorByIdAsync([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid Id!");
                }
                var vendor = await _vendorRepository.GetAsync(id);

                if (vendor == null)
                {
                    return NotFound($"Vendor with id {id} not found!");
                }
                var vendorDTO = _mapper.Map<VendorDTO>(vendor);

                return Ok(vendorDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"An error occurred while retrieving a vendor: {ex.Message}" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VendorDTO>> CreateVendorAsync([FromBody] CreateVendorDTO vendorDTO)
        {
            try
            {
                if (vendorDTO.Password.Length < 6)
                {
                    ModelState.AddModelError("Password", "Password must be at least 6 characters long.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = _mapper.Map<Vendor>(vendorDTO);


                var vendor = await _vendorRepository.AddAsync(entity);

                var obj = _mapper.Map<VendorDTO>(vendor);

                return CreatedAtAction(nameof(GetVendorByIdAsync), new { id = obj.Id }, obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"An error occurred while creating a project: {ex.Message}" });
            }
        }
    }
}
