using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthenticationService _authencationService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager,
            IBookLinks bookLinks,
            IAuthenticationService authencationService,
            ICategoryService categoryService,
            IBookService bookService)
        {
            _authencationService = authencationService;
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IBookService BookService => _bookService;
        public ICategoryService CategoryService => _categoryService;
        public IAuthenticationService AuthenticationService => _authencationService;
    }
}
