﻿using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using Quiz.Domain.Repositories;

namespace Quiz.Infrastructure.Persistence;

public class GameRepository : RepositoryBase<Game>, IGameRepository
{
    public GameRepository(DbContext context) : base(context)
    {
    }

    public async Task CreateGame(Game game) => await CreateAsync(game);

    public async Task DeleteGame(Game game) => await DeleteAsync(game);

    public async Task UpdateGame(Game game) => await UpdateAsync(game);

    public async Task<Game?> GetGameByIdAsync(Guid id, bool trackChanges) => await FindByCondition(g => g.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

    
}