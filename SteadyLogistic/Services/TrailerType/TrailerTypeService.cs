namespace SteadyLogistic.Services.TrailerType
{
    using System.Collections.Generic;
    using System.Linq;
    using SteadyLogistic.Data;

    public class TrailerTypeService : ITrailerTypeService
    {
        private readonly SteadyLogisticDbContext data;

        public TrailerTypeService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }
        public ICollection<string> AllTrailerTypeNames()
        {
            return this.data
                .TrailerTypes
                .Select(a => a.Name)
                .OrderBy(b => b)
                .ToList();
        }

        public ICollection<TrailerTypeServiceModel> AllTrailerTypes()
        {
            return this.data
                .TrailerTypes
                .Select(a => new TrailerTypeServiceModel
                {
                    Id = a.Id,
                    Name = a.Name
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
