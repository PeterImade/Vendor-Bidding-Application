using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private APIResponse _apiResponse;
        public VendorController(IVendorRepository vendorRepository, IMapper mapper)
        {
            this._vendorRepository = vendorRepository;
            this._mapper = mapper;
            this._apiResponse = new();
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetVendorByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetVendorByIdAsync([FromRoute] int id)
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

                _apiResponse.Data = vendorDTO;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVendorAsync([FromBody] CreateVendorDTO vendorDTO)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = _mapper.Map<Vendor>(vendorDTO);


                var vendor = await _vendorRepository.AddAsync(entity);

                var obj = _mapper.Map<VendorDTO>(vendor);

                _apiResponse.StatusCode = HttpStatusCode.Created;
                _apiResponse.Status = true;
                _apiResponse.Data = obj;

                return CreatedAtRoute(nameof(GetVendorByIdAsync), new { id = obj.Id }, _apiResponse);
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
