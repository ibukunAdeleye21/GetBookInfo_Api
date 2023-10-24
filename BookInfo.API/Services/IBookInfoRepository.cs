using BookInfo.API.Entities;

namespace BookInfo.API.Services
{
    public interface IBookInfoRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book?> GetBookAsync(int bookId, bool includePointsOfInterest);

        Task<bool> BookExistsAsync(int bookId);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForBookAsync(int bookId);
        Task<PointOfInterest?> GetPointOfInterestForBookAsync(int bookId,
            int pointOfInterestId);
        Task AddPointOfInterestForBookAsync(int bookId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
    }
}
