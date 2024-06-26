﻿using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly BookAppDataBaseContext _dbContext;

        public BookRepository(IGenericRepository<Book> bookRepository, BookAppDataBaseContext dbContext)
        {
            _bookRepository = bookRepository;
            _dbContext = dbContext;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            return await (_bookRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_bookRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await (_bookRepository.GetAllAsync());
        }

        public Task<(IEnumerable<Book> T, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await (_dbContext.Books.Where(x => x.BookCategoryId == categoryId).ToListAsync());
        }

        public async Task<(IEnumerable<Book> Books, int TotalCount)> GetBooksIsHomePageWithPaginationAsync(PaginationModel paginationModel)
        {
            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;
            var tablesOnPage = await _dbContext.Books
            .Where(x => x.IsDeleted == false && x.IsActive != false && x.IsHomePage == true && x.IsApproved == true)
            .Include(x => x.BookCategory)
            .Skip(startIndex)
            .Take(paginationModel.PageSize)
            .ToListAsync();

            var totalCount = await _dbContext.Books
            .CountAsync(x => x.IsDeleted == false && x.IsActive != false && x.IsHomePage == true && x.IsApproved == true);

            return (tablesOnPage, totalCount);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await (_bookRepository.GetByIdAsync(id));
        }

        public async Task SaveAsync()
        {
            await (_bookRepository.SaveAsync());
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            return await (_bookRepository.UpdateAsync(entity));
        }
    }
}
