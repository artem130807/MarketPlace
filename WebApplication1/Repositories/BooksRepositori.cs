using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.Models;
using WebApplication1.ModelsFiltr;

namespace WebApplication1.Repositories
{
    public class BooksRepositori : IBooksRepository
    {
        private readonly MarketPlaceDbContext _context;
        public BooksRepositori(MarketPlaceDbContext context)
        {
            _context = context;
        }
        public async Task<Books> AddBook(Books books)
        {
            _context.Books.Add(books);           
            await _context.SaveChangesAsync();
            return books;
        }

        public async Task DeleteBook(int id)
        {
            var deletebook = await _context.Books.FindAsync(id);
            if (deletebook != null)
            {
               _context.Books.Remove(deletebook);
            }
        }

        public async Task<Books> GetBookById(int id)
        {
            var book = await _context.Books.Include(x => x.Author).Include(x => x.Publisher).FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                throw new Exception("Ошибка");
            }
            return book;
        }

        public async Task<List<Books>> GetBooks()
        {
            return await _context.Books.Include(x => x.Author).Include(x => x.Publisher).ToListAsync();
        }

        public async Task<List<Books>> GetBooksFiltr(BooksQueryParametr booksQueryParametr)
        {
            var query = _context.Books.Include(x => x.Author).Include(x => x.Publisher).AsQueryable();
            if (!string.IsNullOrWhiteSpace(booksQueryParametr.Title))           
                query = query.Where(x => x.Title.Contains(booksQueryParametr.Title));
            
            if (booksQueryParametr.MinPrice.HasValue)           
                query = query.Where(x => x.Price >= booksQueryParametr.MinPrice.Value);
            
            if (booksQueryParametr.MaxPrice.HasValue)           
                query = query.Where(x => x.Price <= booksQueryParametr.MaxPrice.Value);
            
            if (!string.IsNullOrWhiteSpace(booksQueryParametr.AuthorLastName))
                query = query.Where(x => x.Author.LastName.Contains(booksQueryParametr.AuthorLastName));

            if (!string.IsNullOrWhiteSpace(booksQueryParametr.PublisherName))
                query = query.Where(x => x.Publisher.Name.Contains(booksQueryParametr.PublisherName));
            return await query.ToListAsync();
        }
       
        public async Task<Books> UpdateBook(int id, Books books)
        {
            var updatebook = await _context.Books.FindAsync(id);
            if (updatebook != null)
            {
                _context.Books.Update(updatebook);
                await _context.SaveChangesAsync();              
            }
            return books;
        }
    }
}
