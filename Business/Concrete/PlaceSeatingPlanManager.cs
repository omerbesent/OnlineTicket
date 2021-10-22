using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PlaceSeatingPlanManager : IPlaceSeatingPlanService
    {
        private IPlaceSeatingPlanDal _placeSeatingPlanDal;
        public PlaceSeatingPlanManager(IPlaceSeatingPlanDal placeSeatingPlanDal)
        {
            _placeSeatingPlanDal = placeSeatingPlanDal;
        }

        public IResult Add(PlaceSeatingPlan placeSeatingPlan)
        {
            _placeSeatingPlanDal.Add(placeSeatingPlan);
            return new SuccessResult(Messages.PlaceSeatingPlanAdded);
        }

        [TransactionScopeAspect]
        public IResult AddAll(PlaceSeatingPlan[] placeSeatingPlansSave, PlaceSeatingPlan[] placeSeatingPlansDelete)
        {
            _placeSeatingPlanDal.DeleteAll(placeSeatingPlansDelete);
            _placeSeatingPlanDal.AddAll(placeSeatingPlansSave);
            return new SuccessResult(Messages.PlaceSeatingPlanAdded);
        }

        public IResult Delete(int placeSeatingPlanId)
        {
            _placeSeatingPlanDal.Delete(new PlaceSeatingPlan { PlaceSeatingPlanId = placeSeatingPlanId });
            return new SuccessResult(Messages.PlaceSeatingPlanDeleted);
        }

        public IResult DeleteAll(PlaceSeatingPlan[] placeSeatingPlansDelete)
        {
            _placeSeatingPlanDal.DeleteAll(placeSeatingPlansDelete);
            return new SuccessResult(Messages.PlaceSeatingPlanDeleted);
        }

        public IDataResult<PlaceSeatingPlan> Get(int placeSeatingPlanId)
        {
            return new SuccessDataResult<PlaceSeatingPlan>(_placeSeatingPlanDal.Get(x => x.PlaceSeatingPlanId == placeSeatingPlanId), Messages.PlaceSeatingPlanListed);
        }

        public IDataResult<List<PlaceSeatingPlan>> GetAll()
        {
            return new SuccessDataResult<List<PlaceSeatingPlan>>(_placeSeatingPlanDal.GetList(), Messages.PlaceSeatingPlanListed);
        }

        public IDataResult<List<PlaceSeatingPlan>> GetByPlace(int placeId)
        {
            return new SuccessDataResult<List<PlaceSeatingPlan>>(_placeSeatingPlanDal.GetList(x => x.PlaceId == placeId), Messages.PlaceSeatingPlanListed);
        }

        public IResult Update(PlaceSeatingPlan placeSeatingPlan)
        {
            _placeSeatingPlanDal.Update(placeSeatingPlan);
            return new SuccessResult(Messages.PlaceSeatingPlanUpdated);
        }
         
    }
}
