﻿using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Data.Repository.UserBookRepository
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly IGenericRepository<UserBook> _userBookRepository;

        public UserBookRepository(IGenericRepository<UserBook> userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<UserBook> CreateAsync(UserBook entity)
        {
            return await (_userBookRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_userBookRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<UserBook>> GetAllAsync()
        {
            return await (_userBookRepository.GetAllAsync());
        }

        public Task<(IEnumerable<UserBook> T, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBook> GetByIdAsync(int id)
        {
            return await (_userBookRepository.GetByIdAsync(id));
        }

        public async Task SaveAsync()
        {
            await (_userBookRepository.SaveAsync());
        }

        public async Task<UserBook> UpdateAsync(UserBook entity)
        {
            return await (_userBookRepository.UpdateAsync(entity));
        }
    }
}
