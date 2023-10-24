using AutoMapper;
using BookInfo.API.Models;
using BookInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookInfoRepository bookInfoRepository,
            IMapper mapper)
        {
            _bookInfoRepository = bookInfoRepository ?? 
                throw new ArgumentNullException(nameof(bookInfoRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithoutPointsOfInterestDto>>> GetBooks()
        {
            var bookEntities = await _bookInfoRepository.GetBooksAsync();

            return Ok(_mapper.Map<IEnumerable<BookWithoutPointsOfInterestDto>>(bookEntities));
        
        }

        // the URI to this resource is api/cities/Id but the first part "api/cities is already
        // handled by the route attribute, accept the id
        // To work with parameters in routing templates, curly brackets are used.

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id, bool includePointsOfInterest = false) // accept the id of the city that is to be returned as parameter
        {
            var book = await _bookInfoRepository.GetBookAsync(id, includePointsOfInterest);

            if (book == null)
            {
                return NotFound();
            } 

            if (includePointsOfInterest) 
            { 
                return Ok(_mapper.Map<BookDto>(book));
            }

            return Ok(_mapper.Map<BookWithoutPointsOfInterestDto>(book)); // return the book with 200 status code
        }
    }
}
