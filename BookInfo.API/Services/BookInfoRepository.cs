using BookInfo.API.DbContext;
using BookInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.API.Services
{
    public class BookInfoRepository : IBookInfoRepository
    {
        private readonly BookContextInfo _context;
        public BookInfoRepository(BookContextInfo context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Book?> GetBookAsync(int bookId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return await _context.Books.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == bookId).FirstOrDefaultAsync();
            }

            return await _context.Books
                .Where(c => c.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.OrderBy(c => c.Section).ToListAsync();
        }
        
        public async Task<PointOfInterest?> GetPointOfInterestForBookAsync(
            int bookId, 
            int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.BookId == bookId && p.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForBookAsync(
            int bookId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.BookId == bookId).ToListAsync();
        }

        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await _context.Books.AnyAsync(c => c.Id == bookId);

        }

        public async Task AddPointOfInterestForBookAsync(int bookId, PointOfInterest pointOfInterest)
        {
            var book = await GetBookAsync(bookId, false);

            if (book != null)
            {
                book.PointsOfInterest.Add(pointOfInterest);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
    }
}
