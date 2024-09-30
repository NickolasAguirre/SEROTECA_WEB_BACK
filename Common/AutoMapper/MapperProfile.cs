using AutoMapper;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Common.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<PortaMuestraCommandDA, PortaMuestra>();
            CreateMap<OrdenPortaMuestraDA, OrdenPortaMuestra>();
            CreateMap<OrdenPortaMuestra,OrdenPortaMuestraDA>();
            CreateMap<OrdenPortaMuestra, OrdenPortaMuestraPosicionesDA>().ForMember(dest=>dest.Columna,act=>act.MapFrom(src=>src.PosicionColumna))
                                                                         .ForMember(dest=>dest.Fila,act=>act.MapFrom(src=>src.PosicionFila));
        }
        

    }
}
