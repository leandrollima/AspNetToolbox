using Toolbox.Domain;
using Toolbox.Dto.Response;

namespace Toolbox.Mapper
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMapsTo(typeof(WeatherForecast), typeof(WeatherForecastResponse));
        }

        /// <summary>
        /// Cria o conversor do mapper entre Entidade, DTO Request e DTOo Response
        /// </summary>
        /// <param name="entityType">entidade do banco de dados</param>
        /// <param name="dtoRequestType">DTO Request</param>
        /// <param name="dtoResponseType">DTO Response</param>
        private void CreateMapsTo(Type entityType, Type dtoRequestType, Type dtoResponseType)
        {
            CreateMap(entityType, dtoRequestType);
            CreateMap(dtoRequestType, entityType);

            CreateMap(entityType, dtoResponseType);
            CreateMap(dtoResponseType, entityType);
        }

        /// <summary>
        /// Cria o conversor do mapper entre Entidade e DTO
        /// </summary>
        /// <param name="entityType">entidade do banco de dados</param>
        /// <param name="dtoType">DTO model</param>
        private void CreateMapsTo(Type entityType, Type dtoType)
        {
            CreateMap(entityType, dtoType);
            CreateMap(dtoType, entityType);
        }

    }
}
