using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaProject.Models
{
    public class Order
    {

        public virtual int Id { get; set; }

        [DisplayName("Имя заказчика")]
        [Required]
        public virtual string CustomerName { get; set; }

        [Required]
        [DisplayName("Дата оформления")]
        public virtual DateTime Date { get; set; }

        [DisplayName("Адрес доставки")]
        [Required]
        public virtual string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Телефон")]
        [Required]
        public virtual string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Пицца")]
        public virtual int PizzaId { get; set; }

        [DisplayName("Стоимость")]
        public virtual int Price { get; set; }
    }
}