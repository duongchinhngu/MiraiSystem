using Microsoft.EntityFrameworkCore;
using MiraiSystem.Helpers.ConstantsHelpers;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using MiraiSystem.Models.ExtendedModels;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class ShoesRepository : GenericRepository<Shoes>, IShoesRepository
    {
        private readonly MiraiDBContext _context;
        public ShoesRepository(MiraiDBContext context) : base(context)
        {
            _context = context;
        }

        //quantity > 0; available in stock; sortby and sort
        public async Task<PagedList<ExtendedConcreteShoes>> Filter(ShoesFilter filter)
        {
            //select available shoes
            IEnumerable<ExtendedConcreteShoes> entities = await SelectAvailableExtended();

            if (filter.Gender == "all")
            {
                if (filter.Size == 0)
                {
                    entities = await GetConcreteShoesListContainsLowestPriceForEachSize(entities);
                }
                else
                {
                    entities = entities.Where(c => c.Size == filter.Size).ToList();
                }
            }
            else
            {
                //select available shoes
                if (filter.Size == 0)
                {
                    entities = entities.Where(s => s.Gender.Equals(filter.Gender, StringComparison.OrdinalIgnoreCase)).ToList();
                    entities = await GetConcreteShoesListContainsLowestPriceForEachSize(entities);
                }
                else
                {
                    entities = entities.Where(c => c.Gender.Equals(filter.Gender, StringComparison.OrdinalIgnoreCase) && c.Size == filter.Size).ToList();
                }
            }
            entities =  SortAnEntityList(entities, filter.SortBy, filter.OrderBy);
            return PagedList<ExtendedConcreteShoes>.ToPagedList(entities, filter.PageNumber, filter.PageSize);
        }

        private async Task<IEnumerable<ExtendedConcreteShoes>> GetConcreteShoesListContainsLowestPriceForEachSize
                                                                (IEnumerable<ExtendedConcreteShoes> entities)
        {
            IEnumerable<ExtendedConcreteShoes> pairOfShoesIdAndLowestPriceList = GetPairOfShoesIdAndLowestPriceList(entities);
            //
            List<ExtendedConcreteShoes> resultEntities = new List<ExtendedConcreteShoes>();
            foreach (var pairOfShoesIdAndLowestPrice in pairOfShoesIdAndLowestPriceList)
            {
                ExtendedConcreteShoes tmpEntity = await GetResultExtendedConcreteShoes(pairOfShoesIdAndLowestPrice);
                resultEntities.Add(tmpEntity);
            }
            //
            return resultEntities;

            IEnumerable<ExtendedConcreteShoes> GetPairOfShoesIdAndLowestPriceList
                                                                    (IEnumerable<ExtendedConcreteShoes> entities)
            {
                return entities.GroupBy(s => s.ShoesId)
                                .Select(a => new ExtendedConcreteShoes
                                {
                                    ShoesId = a.Key,
                                    Price = a.Min(b => b.Price),
                                }).ToList();
            }

            async Task<ExtendedConcreteShoes> GetResultExtendedConcreteShoes(ExtendedConcreteShoes i)
            {
                return await _context.ConcreteShoes
                                    .Where(e => e.ShoesId == i.ShoesId
                               && e.Price == i.Price).Select(s => new ExtendedConcreteShoes
                               {
                                   Id = s.Id,
                                   Gender = s.Gender,
                                   Size = s.Size,
                                   MainImageUrl = s.Shoes.ShoesImages
                                         .Where(i => i.Purpose == ShoesImageStatusConstants.MAIN_IMAGE_STATUS)
                                         .FirstOrDefault().Url,
                                   Price = i.Price,
                                   Quantity = s.Quantity,
                                   ShoesId = i.ShoesId,
                                   ShoesName = s.Shoes.Name
                               }).FirstOrDefaultAsync();
            }
        }

        private async Task<IEnumerable<ExtendedConcreteShoes>> SelectAvailableExtended()
        {
            return await _context.ConcreteShoes
                             .Where(c => c.Shoes.Status == ShoesStatusConstants.INSTOCK_STATUS
                            && c.Quantity > 0)
                             .Select(s => new ExtendedConcreteShoes
                             {
                                 Id = s.Id,
                                 Gender = s.Gender,
                                 Size = s.Size,
                                 MainImageUrl = s.Shoes.ShoesImages
                                             .Where(i => i.Purpose == ShoesImageStatusConstants.MAIN_IMAGE_STATUS)
                                             .FirstOrDefault().Url,
                                 Price = s.Price,
                                 Quantity = s.Quantity,
                                 ShoesId = s.ShoesId,
                                 ShoesName = s.Shoes.Name
                             })
                             .ToListAsync();
        }

        public static IEnumerable<ExtendedConcreteShoes> SortAnEntityList
                                        (IEnumerable<ExtendedConcreteShoes> entities, string sortBy, string orderBy)
        {
            switch (sortBy)
            {
                case ("price"):
                    switch (orderBy)
                    {
                        case (FilterConstants.ASCENDING_SORT):
                            return entities.OrderBy(e => e.Price);
                        case (FilterConstants.DESCENDING_SORT):
                            return entities.OrderByDescending(e => e.Price);
                        case (FilterConstants.DEFAULT_SORT):
                            break;
                    }
                    break;
            }
            return entities;
        }
    }
}
