using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers.UserFilters
{
    public class UserFilter : GenericFilter, IFilterHelper<User>
    {
        public string Status { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string RoleId { get; set; }
        public override string SortBy { get; set; } = "Firstname";

        public void ApplyFilter(ref IQueryable<User> entities)
        {
            FilterAction<User>.ApplyFilter(ref entities, this);
        }

        public PagedList<User> ApplyPaging(IQueryable<User> entities)
        {
            return PagedList<User>.ToPagedList(entities, this.PageNumber, this.PageSize);
        }

        public void ApplySearch(ref IQueryable<User> entities)
        {
            entities = entities.Where(u => u.Firstname.Contains(this.Search) || u.Lastname.Contains(this.Search));
        }

        public void ApplySort(ref IQueryable<User> entities)
        {
            FilterAction<User>.ApplySort(ref entities, this.OrderBy, this.SortBy);
        }
    }
}
