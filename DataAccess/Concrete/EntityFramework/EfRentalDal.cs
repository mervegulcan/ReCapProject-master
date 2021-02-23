using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NewTableCarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (NewTableCarContext context = new NewTableCarContext())
            {

         
            var result = from c in context.Rentals
                         join cr in context.Cars
                         on c.CarId equals cr.Id
                         join cus in context.Customers
                         on c.CustomerId equals cus.Id
                         join us in context.Users
                        on cus.UserId equals us.Id
                         select new RentalDetailsDto
                         {
                             Id = c.Id,
                             CarId = c.Id,
                             CarName = cr.Name,
                             CustomerName = cus.CompanyName,
                             RentDate = c.RentDate,
                             ReturnDate = c.ReturnDate,
                             UserName = us.FirstName+" "+us.LastName
                             

                         };
            return result.ToList();
            }
        }
    }
}
