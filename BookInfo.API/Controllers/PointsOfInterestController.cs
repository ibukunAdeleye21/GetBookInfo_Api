using AutoMapper;
using BookInfo.API.Models;
using BookInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BookInfo.API.Controllers
{
    [Route("api/books/{bookId}/pointsofinterest")]
    [Authorize]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(IBookInfoRepository bookInfoRepository, 
            IMapper mapper)
        {
            _bookInfoRepository = bookInfoRepository ?? 
                throw new ArgumentNullException(nameof(bookInfoRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int bookId)
        {
            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var pointsOfInterestForBook = await _bookInfoRepository
                .GetPointsOfInterestForBookAsync(bookId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForBook));
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
            int bookId, int pointOfInterestId)
        {
            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var pointOfInterest = await _bookInfoRepository
                .GetPointOfInterestForBookAsync(bookId, pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int bookId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            await _bookInfoRepository.AddPointOfInterestForBookAsync(
                bookId, finalPointOfInterest);

            await _bookInfoRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn = 
                _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

            
            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    bookId = bookId,
                    pointOfInterestId = createdPointOfInterestToReturn.Id
                },
                createdPointOfInterestToReturn);
        }

        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(int bookId, int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _bookInfoRepository  // get to the database through the repository
                .GetPointOfInterestForBookAsync(bookId, pointOfInterestId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointOfInterestEntity);

            await _bookInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{pointofinterestid}")]

        public async Task<ActionResult> PartiallyUpdatePointOfInterest(
            int bookId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _bookInfoRepository
                .GetPointOfInterestForBookAsync(bookId, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(
                pointOfInterestEntity);

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);

            await _bookInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{pointofinterestid}")]
        public async Task<ActionResult> DeletePointOfInterest(int bookId, int pointOfInterestId)
        {

            if (!await _bookInfoRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _bookInfoRepository
                .GetPointOfInterestForBookAsync(bookId, pointOfInterestId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _bookInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            await _bookInfoRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}
