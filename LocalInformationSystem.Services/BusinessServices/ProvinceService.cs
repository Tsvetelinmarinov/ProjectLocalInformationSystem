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

        /// <summary>
        ///  Retrieves province with the specified ID from the database.
        /// </summary>
        /// <param name="id">
        ///  The ID of the province.
        /// </param>
        /// <returns>
        ///  The province with the specified ID.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///  Thrown when the AutoMapper counld not map Province to ProvinceDTO.
        /// </exception>
        /// <exception cref="InvalidDataException">
        ///  Thrown when the ID of the province is invalid.
        /// </exception>
        public ProvinceDTO FindProvinceById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException(InvalidProvinceID);
            }

            var provinceEntity = this._base.FindProvinceById(int);

            var provinceDTO 
                = this._mapper.Map<ProvinceDTO>(provinceEntity)
                  ?? throw new InvalidOperationException(UnsuccessfullyMappingOfProvince);
           
            return provinceDTO;
        }

        #endregion
    }
}