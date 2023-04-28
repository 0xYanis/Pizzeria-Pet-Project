using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaProject.Models
{
    public class PizzaDbInitializer: DropCreateDatabaseIfModelChanges<PizzaContext>
    {
        protected override void Seed(PizzaContext context)
        {
            context.Pizza.Add(new Pizza { Name = "Пепперони", Description = "25см, 450г, пепперони, томаты, томатный соус, моцарелла ", Price = 450 });
            context.Pizza.Add(new Pizza { Name = "Грибная", Description = "25см, 650г, тонкое тесто, грибной соус, моцарелла, цыплёнок", Price = 600 });
            context.Pizza.Add(new Pizza { Name = "Гавайская", Description = "25см, 600г, ананасы, моцарелла, цыплёнок, ", Price = 700 });
            context.Pizza.Add(new Pizza { Name = "Карбонара", Description = "30см, 800г, сыр чеддер, сып пармезан, моцарелла, бекон, томаты, лук ", Price = 900 });
            base.Seed(context);
        }
    }
}