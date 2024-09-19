using AutoMapper;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Common.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<PortaMuestraCommandDA, PortaMuestra>();
        }
        

    }
}
