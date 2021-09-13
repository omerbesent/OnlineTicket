using Business.Abstract;
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


        public void Add(PlaceSeatingPlan placeSeatingPlan)
        {
            _placeSeatingPlanDal.Add(placeSeatingPlan);
        }

        public void AddAll(PlaceSeatingPlan[] placeSeatingPlansSave, PlaceSeatingPlan[] placeSeatingPlansDelete)
        {
            _placeSeatingPlanDal.AddAll(placeSeatingPlansSave, placeSeatingPlansDelete);
        }

        public void Delete(int placeSeatingPlanId)
        {
            _placeSeatingPlanDal.Delete(new PlaceSeatingPlan { PlaceSeatingPlanId = placeSeatingPlanId });
        }

        public void DeleteAll(PlaceSeatingPlan[] placeSeatingPlansDelete)
        {
            _placeSeatingPlanDal.DeleteAll(placeSeatingPlansDelete);
        }

        public PlaceSeatingPlan Get(int placeId)
        {
            return _placeSeatingPlanDal.Get(x => x.PlaceSeatingPlanId == placeId);
        }

        public List<PlaceSeatingPlan> GetAll()
        {
            return _placeSeatingPlanDal.GetList();
        }

        public List<PlaceSeatingPlan> GetByPlace(int placeId)
        {
            return _placeSeatingPlanDal.GetList(x => x.PlaceId == placeId);
        }

        public void Update(PlaceSeatingPlan placeSeatingPlan)
        {
            _placeSeatingPlanDal.Update(placeSeatingPlan);
        }
    }
}
