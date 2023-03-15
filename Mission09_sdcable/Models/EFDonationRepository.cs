using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission09_sdcable.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private BookstoreContext context;

        public EFDonationRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Donation> Donations => context.Donation.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Book));

            if (donation.DonationId == 0)
            {
                context.Donation.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
