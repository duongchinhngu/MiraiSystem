using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class User
    {
        public User()
        {
            CreatedBrands = new HashSet<Brand>();
            UpdatedBrands = new HashSet<Brand>();
            CreatedCategories = new HashSet<Category>();
            UpdatedCategories = new HashSet<Category>();
            OrderItems = new HashSet<OrderItem>();
            Orders = new HashSet<Order>();
            CreatedPermissions = new HashSet<Permission>();
            UpdatedPermissions = new HashSet<Permission>();
            CreatedShoesList = new HashSet<Shoes>();
            CreatedProductImages = new HashSet<ProductImage>();
            UpdatedProductImages = new HashSet<ProductImage>();
            UpdatedShoesList = new HashSet<Shoes>();
            CreatedRoles = new HashSet<Role>();
            CreatedRolePermissions = new HashSet<RolePermission>();
            UpdatedRolePermissions = new HashSet<RolePermission>();
            UpdatedRoles = new HashSet<Role>();
        }

        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string RoleId { get; set; }
        public string Phone { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime RegisteredAt { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Brand> CreatedBrands { get; set; }
        public virtual ICollection<Brand> UpdatedBrands { get; set; }
        public virtual ICollection<Category> CreatedCategories { get; set; }
        public virtual ICollection<Category> UpdatedCategories { get; set; }
        public virtual ICollection<Membership> CreatedMemberships { get; set; }
        public virtual ICollection<Membership> UpdatedMemberships { get; set; }
        public virtual ICollection<MembershipPrivilege> CreatedMembershipPrivileges { get; set; }
        public virtual ICollection<MembershipPrivilege> UpdatedMembershipPrivileges { get; set; }
        public virtual ICollection<Privilege> CreatedPrivileges { get; set; }
        public virtual ICollection<Privilege> UpdatedPrivileges { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Permission> CreatedPermissions { get; set; }
        public virtual ICollection<Permission> UpdatedPermissions { get; set; }
        public virtual ICollection<Shoes> CreatedShoesList { get; set; }
        public virtual ICollection<ProductImage> CreatedProductImages { get; set; }
        public virtual ICollection<ProductImage> UpdatedProductImages { get; set; }
        public virtual ICollection<Shoes> UpdatedShoesList { get; set; }
        public virtual ICollection<Role> CreatedRoles { get; set; }
        public virtual ICollection<RolePermission> CreatedRolePermissions { get; set; }
        public virtual ICollection<RolePermission> UpdatedRolePermissions { get; set; }
        public virtual ICollection<Role> UpdatedRoles { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
