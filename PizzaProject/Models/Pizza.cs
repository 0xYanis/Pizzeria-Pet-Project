using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PizzaProject.Models
{
    public class Pizza
    {
        public virtual int Id { get; set; }

        [DisplayName("Название")]
        public virtual string Name { get; set; }

        [DisplayName("Описание")]
        public virtual string Description { get; set; }

        [DisplayName("Цена")]
        public virtual int Price { get; set; }
    }
}