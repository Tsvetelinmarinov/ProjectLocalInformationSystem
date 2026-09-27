using AutoMapper;

using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;

using static LocalInformationSystem.Services.Common.Constants;

namespace LocalInformationSystem.Services.BusinessServices
{
    /// <summary>
    ///  Communicates with the repository and server CitiesController.
    /// </summary>
    public class CitiesService : ICitiesService
    {
        #region Private Fields

        // Repository.
        private readonly IRepository _database;

        // Auto mapper for Entity -> EntityDTO.
        private readonly IMapper _mapper;

        #endregion
        #region Constructor

        public CitiesService(IRepository database, IMapper autoMapper)
        {
            this._database = database;
            this._mapper = autoMapper;
        }

        #endregion

        /// <summary>
        ///  Retrieves all the cities from the database.
        /// </summary>
        /// <returns>
        ///  Collection of the cities.
        /// </returns>
        public IEnumerable<CityDTO> GetAllCities()
        {
            var result = this._database
                .GetAllCities();

            if (result is null || result.Any() is false)
            {
                throw new InvalidOperationException(NoCitiesFromDb);
            }

            //=> Since the repository provides IQueryable here, we can project with AutoMapper.
            var citiesDTOs = this._mapper.Map<IEnumerable<CityDTO>>(result);
                
            if (citiesDTOs is null || citiesDTOs.Any() is false)
            {
                throw new InvalidOperationException(NoCitiesFromDb);
            }

            return citiesDTOs;
        }

        /// <summary>
        ///  Retrieves City from the database by its ID.
        /// </summary>
        /// <param name="id">
        ///  The ID of the city.
        /// </param>
        /// <returns>
        ///  The City with the specified ID.
        /// </returns>
        public CityDTO FindCityById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InvalidCityID);
            }

            var entity = this._database.FindCityById(id);

            var cityDTO = this._mapper.Map<CityDTO>(entity)
                  ?? throw new InvalidOperationException(CannotMapCityToCityDTO);

            return cityDTO;
        }
    }
}