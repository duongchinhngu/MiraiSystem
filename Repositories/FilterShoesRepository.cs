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
            var entities = SearchAvailableShoes(filter.Search);
            //refactor here-----------------------------------------------------------------------------------
            entities = entities.Where(s =>
                    Shoes.IsLegalFashionGender(filter.Gender) ? 
                        s.Gender.Equals(filter.Gender, StringComparison.OrdinalIgnoreCase) : true);

            entities = entities.Where(s => filter.Size == 0.0m ? true : s.Size == filter.Size);

            entities = entities.Where(s =>
                        String.IsNullOrEmpty(filter.ModelCode) ? true :
                            s.ModelCode.Equals(filter.ModelCode, StringComparison.OrdinalIgnoreCase));
            //-------------------------------------------------------------------------------------------------
            GetShoeListContainsLowestPriceForEachSize(ref entities);

            entities = SortHelper<Shoes>.ApplySort(entities, filter.OrderBy, filter.SortBy);

            return PagedList<Shoes>.ToPagedList(entities, filter.PageNumber, filter.PageSize);
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

        public IQueryable<Shoes> SearchAvailableShoes(string search)
        {
            return _context.Shoes
                            .Where(s => s.Quantity > 0 && s.Status.Equals(Shoes.INSTOCK_STATUS))
                            .Where(s => s.Name.Contains(search));
        }
    }
}
