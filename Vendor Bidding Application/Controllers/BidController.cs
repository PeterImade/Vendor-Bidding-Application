using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Controllers
{
    [Route("api/bids")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public BidController(IBidRepository bidRepository, IMapper mapper)
        {
            this._bidRepository = bidRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<BidDTO>> CreateBidAsync([FromBody] CreateBidDTO bidDTO)
        {
            if (bidDTO == null)
            {
                return UnprocessableEntity("Invalid data!");
            }

            var entity = _mapper.Map<Bid>(bidDTO);

            var bid = await _bidRepository.AddAsync(entity);
            
            var obj = _mapper.Map<BidDTO>(bid);
            
            return CreatedAtAction(nameof(GetBidByIdAsync), new {id = obj.Id}, obj);
        }

        [HttpGet("{vendorId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BidDTO>> GetBidByIdAsync([FromRoute] int vendorId)
        {
            if (vendorId <= 0)
            {
                return BadRequest("Invalid Id!");
            }

            var bid = await _bidRepository.GetAsync(vendorId);

            if (bid == null)
            {
                return NotFound($"Bid with vendor id {vendorId} not found!");
            }

            var bidDTO = _mapper.Map<BidDTO>(bid);
            
            return Ok(bidDTO);
        }
    }
}
