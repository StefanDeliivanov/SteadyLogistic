namespace SteadyLogistic.Services.TrailerType
{
    using System.Collections.Generic;

    public interface ITrailerTypeService
    {

        public ICollection<TrailerTypeServiceModel> AllTrailerTypes();

        public bool Exists(int trailerTypeId);
    }
}