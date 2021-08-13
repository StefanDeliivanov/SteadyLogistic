namespace SteadyLogistic.Services.TrailerType
{
    using System.Linq;
    using System.Collections.Generic;
    using SteadyLogistic.Data;

    public class TrailerTypeService : ITrailerTypeService
    {
        private readonly SteadyLogisticDbContext data;

        public TrailerTypeService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public ICollection<TrailerTypeServiceModel> AllTrailerTypes()
        {
            return this.data
                        .TrailerTypes
                        .Select(x => new TrailerTypeServiceModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();
        }

        public bool Exists(int trailerTypeId)
        {
            return this.data
                        .TrailerTypes
                        .Any(a => a.Id == trailerTypeId);
        }
    }
}
