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
   public  class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorsDal)
        {
            _colorDal = colorsDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 3)
            {

                return new SuccessResult(Messages.ColorAdded);
            }

            _colorDal.Add(color);

            return new ErrorResult(Messages.ColorNameInvalid);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new ErrorResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetCarsByColorsId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
