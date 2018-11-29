namespace Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("listoforder.Order")]
    public partial class OrderList
    {
        [Key]
        [StringLength(12)]
        public string OrderId { get; set; }

        [StringLength(20)]
        public string ClientName { get; set; }

        [StringLength(11)]
        public string ClientPhoneNumber { get; set; }

        [Column(TypeName = "usmallint")]
        public int? ProductCategory { get; set; }

        [Column(TypeName = "uint")]
        public long? TotalPrice { get; set; }

        public List<OrderDetails> ListOfDetails { get; set; }

        public OrderList()
        {
            ListOfDetails = new List<OrderDetails>();
        }

        public OrderList(string id, string name, string pnum, int cate, List<OrderDetails> details)
        {
            OrderId = id;
            ClientName = name;
            ClientPhoneNumber = pnum;
            ProductCategory = cate;
            ListOfDetails = details;
        }
    }
}
