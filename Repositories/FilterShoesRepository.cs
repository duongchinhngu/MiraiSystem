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
            var entities = SearchAvailableShoes(filter);

            entities.Where(s => QueryByGender(filter, s));

            entities.Where(s => QueryBySize(filter, s));

            GetShoeListContainsLowestPriceForEachSize(ref entities);

            entities = SortHelper<Shoes>.ApplySort(entities, filter.OrderBy, filter.SortBy);

            entities.Select( s => s.GetShoes(s.ProductImages)).ToList();

            return PagedList<Shoes>.ToPagedList(entities, filter.PageNumber, filter.PageSize);
        }

        private static bool QueryBySize(ShoesFilter filter, Shoes s)
        {
            return filter.Size == 0 ? true : s.Size == filter.Size;
        }

        private bool QueryByGender(ShoesFilter filter, Shoes s)
        {
            return Shoes.IsLegalFashionGender(filter.Gender) ? s.Gender.Equals(filter.Gender, StringComparison.OrdinalIgnoreCase) : true;
        }

        void GetShoeListContainsLowestPriceForEachSize(ref IQueryable<Shoes> entities)
        {
            IQueryable<Shoes> entitiesQueryable = GetPairOfStyleCodeAndLowestPriceList(entities);
            IEnumerable<Shoes> pairOfStyleCodeAndLowestPriceList = entitiesQueryable.ToList<Shoes>();
            List<Shoes> resultEntitiesQueryable = new List<Shoes>();
            foreach (var pairOfStyleCodeAndLowestPrice in pairOfStyleCodeAndLowestPriceList)
            {
                Shoes tmpShoe = GetSingleLowestPriceShoe(entities, pairOfStyleCodeAndLowestPrice.ModelCode, pairOfStyleCodeAndLowestPrice.Price);
                resultEntitiesQueryable.Add(tmpShoe);
            }
            entities = resultEntitiesQueryable.AsQueryable<Shoes>();


            static IQueryable<Shoes> GetPairOfStyleCodeAndLowestPriceList(IQueryable<Shoes> entities)
            {
                return (IQueryable<Shoes>)entities
                                  .GroupBy(s => s.ModelCode)
                                  .Select(a => new Shoes
                                  {
                                      ModelCode = a.Key,
                                      Price = a.Min(b => b.Price),
                                  });
            }


            Shoes GetSingleLowestPriceShoe(IQueryable<Shoes> entities, string model, double price)
            {
                return entities.Where(s => s.ModelCode.Equals(model)
                && s.Price == price).FirstOrDefault();
            }
        }

        private IQueryable<Shoes> SearchAvailableShoes(ShoesFilter filter)
        {
            return _context.Shoes
                            .Where(s => s.Quantity > 0 && s.Status.Equals(Shoes.INSTOCK_STATUS))
                            .Where(s => s.Name.Contains(filter.Search));
        }
    }
}
