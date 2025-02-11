﻿using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Domain.Entities;
using Quiz.Domain.Repositories;
using Quiz.Infrastructure.Models;
using Quiz.Infrastructure.Persistence;

namespace Quiz.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("quizDbConnectionString")));
        
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IQuestionPackRepository, QuestionPackRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        return services;
    }
}