using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;

using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiraiSystem.Repositories
{
    public partial class ShoesRepository
    {
        public PagedList<Shoes> Filter(ShoesFilter filter)
        {
            IQueryable<Shoes> entities = _context.Shoes.AsQueryable();

            filter.ApplySearch(ref entities);

            filter.ApplyFilter(ref entities);

            if (!filter.IsLoadAll)
            {
                GetShoeListContainsLowestPriceForEachSize(ref entities);
            }

            filter.ApplySort(ref entities);

            return filter.ApplyPaging(entities);
        }

        void GetShoeListContainsLowestPriceForEachSize(ref IQueryable<Shoes> entities)
        {
            IEnumerable<Shoes> pairOfStyleCodeAndLowestPriceList = GetPairOfStyleCodeAndLowestPriceList(entities);
            List<Shoes> resultEntitiesQueryable = new List<Shoes>();
            foreach (var pairOfStyleCodeAndLowestPrice in pairOfStyleCodeAndLowestPriceList)
            {
                Shoes tmpShoe = GetSingleLowestPriceShoe(entities, pairOfStyleCodeAndLowestPrice.ModelCode, pairOfStyleCodeAndLowestPrice.Price);
                resultEntitiesQueryable.Add(tmpShoe);
            }
            entities = resultEntitiesQueryable.AsQueryable<Shoes>();

            static IEnumerable<Shoes> GetPairOfStyleCodeAndLowestPriceList(IQueryable<Shoes> entities)
            {
                return entities
                                  .GroupBy(s => s.ModelCode)
                                  .Select(a => new Shoes
                                  {
                                      ModelCode = a.Key,
                                      Price = a.Min(b => b.Price),
                                  }).ToList();
            }

            Shoes GetSingleLowestPriceShoe(IQueryable<Shoes> entities, string model, double price)
            {
                return entities.Where(s => s.ModelCode.Equals(model)
                && s.Price == price).FirstOrDefault();
            }
        }
    }
}
