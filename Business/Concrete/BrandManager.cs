using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
   public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandsDal)
         {
            _brandDal= brandsDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded); 
            
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<List<Brand>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.Id == id));
        }

        public IDataResult<List<Brand>> GetCarsByBrandId()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {

                return new SuccessResult(Messages.BrandUpdated);
            }
            _brandDal.Update(brand);
            
                return new ErrorResult(Messages.BrandNameInvalid);
            
        }   

        

        

        
   }
}
