namespace Order
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrderDB : DbContext
    {
        public OrderDB()
            : base("name=OrderDB")
        {
        }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderList> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.orderid)
                .IsUnicode(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.OrderId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.ClientPhoneNumber)
                .IsUnicode(false);
        }
    }
}
