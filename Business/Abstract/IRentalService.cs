using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService:IEntityService<Rental>
    {
        IResult GetRentalByCarId(int carId);
        IResult GetRentalByCustomerId(int customerId);
    }
}
