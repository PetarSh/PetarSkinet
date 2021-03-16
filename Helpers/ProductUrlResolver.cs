using AutoMapper;
using core1.Entities;
using Microsoft.Extensions.Configuration;
using PetarSkinet.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetarSkinet.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration configuration;
        public ProductUrlResolver(IConfiguration conf)
        {
            configuration = conf;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
