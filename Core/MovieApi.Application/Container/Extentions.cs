using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Container
{
    public static class Extentions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            // Identity Configuration
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>()
                .AddDefaultTokenProviders();

            // CQRS Handlers
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();

            services.AddScoped<CreateUserRegisterCommandHandler>();
        }
    }
}
