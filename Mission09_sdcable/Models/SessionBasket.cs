using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_sdcable.Infrastructure;

namespace Mission09_sdcable.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //If there's a session, pass in the basket stuff. If not, create a new session.
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book boo, int qty)
        {
            base.AddItem(boo, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book boo)
        {
            base.RemoveItem(boo);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
