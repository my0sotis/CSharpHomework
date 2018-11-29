namespace Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("listoforder.OrderDetails")]
    public partial class OrderDetails
    {
        [StringLength(20)]
        public string ProductName { get; set; }

        [Column(TypeName = "uint")]
        public long? PriceOfProduct { get; set; }

        [Column(TypeName = "uint")]
        public long? NumOfProduct { get; set; }

        [Key]
        [StringLength(11)]
        public string orderid { get; set; }

        public OrderDetails()
        {
            orderid = Guid.NewGuid().ToString();
        }

        public OrderDetails(string Id, string name, int price, int num)
        {
            orderid = Id;
            ProductName = name;
            PriceOfProduct = price;
            NumOfProduct = num;
        }
    }
}
