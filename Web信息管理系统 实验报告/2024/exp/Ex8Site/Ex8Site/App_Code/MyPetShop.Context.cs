﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;

public partial class MyPetShopEntities : DbContext
{
    public MyPetShopEntities()
        : base("name=MyPetShopEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<CartItem> CartItem { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<OrderItem> OrderItem { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<Supplier> Supplier { get; set; }

    public virtual int CategoryInsert(string name, string descn)
    {
        var nameParameter = name != null ?
            new ObjectParameter("Name", name) :
            new ObjectParameter("Name", typeof(string));

        var descnParameter = descn != null ?
            new ObjectParameter("Descn", descn) :
            new ObjectParameter("Descn", typeof(string));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CategoryInsert", nameParameter, descnParameter);
    }
}
