using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Services.Common.Constants;


using AutoMapper;

namespace LocalInformationSystem.Services.BusinessServices
{
    /// <summary>
    ///  Communicate with the Database layer via repository and serves the ProvinceController.
    /// </summary>
    public class ProvinceService : IProvinceService
    {
        #region Private Fields And Constructor

        // Database repository.
        private readonly IRepository _base;

        // Auto mapper for mapping Entity -> ServiceDTO.
        private readonly IMapper _mapper;


        /// <summary>
        ///  Constructs new ProvinceService with the specified repository.
        /// </summary>
        /// <param name="database">The repository</param>
#pragma warning disable IDE0290 // Use primary constructor.
        public ProvinceService(IRepository database, IMapper mapper)
        {
            this._base = database;
            this._mapper = mapper;
        }
#pragma warning restore IDE0290

        #endregion
        #region Functionality

        /// <summary>
        ///  Retrieves all the provinces from the database.
        /// </summary>
        /// <returns>
        ///  <see cref="IEnumerable{ProvinceDTO}"/> with all the provinces.
        /// </returns>
        public IEnumerable<ProvinceDTO> GetAllProvinces()
        {
            var provinceEntities = this._base
                .GetAllProvinces() 
                ?? throw new InvalidOperationException(ProvinceError);

            var provinceDTOs = this._mapper.Map<List<ProvinceDTO>>(provinceEntities);
            
            if (provinceDTOs.Count is 0)
            {
                throw new InvalidOperationException(UnsuccessfullyMappingOfProvince);
            }

            return provinceDTOs;
        }

        #endregion
    }
}