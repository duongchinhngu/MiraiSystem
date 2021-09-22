using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.SortHelpers;
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
            IQueryable<Shoes> entities = _context.Shoes.Where(s => s.Quantity > 0 && s.Status.Equals(Shoes.INSTOCK_STATUS));

            SearchByName(ref entities, filter.Search);

            filter.ApplyFilter(ref entities);

            if (String.IsNullOrEmpty(filter.ModelCode))
            {
                GetShoeListContainsLowestPriceForEachSize(ref entities);
            }

            filter.ApplySort(ref entities);

            return PagedList<Shoes>.ToPagedList(entities, filter.PageNumber, filter.PageSize);
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

        public void SearchByName(ref IQueryable<Shoes> entities, string search)
        {
            entities = entities.Where(s => s.Name.Contains(search));
        }
    }
}
