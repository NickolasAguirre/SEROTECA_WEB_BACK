using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Services
{

    public interface IOrdenPortaMuestraService
    {
        public Task<List<OrdenPortaMuestraDA>> GetAll();
        public Task<OrdenPortaMuestraPosicionesDA> Find(int numero);
        public Task<OrdenPortaMuestra> Post(OrdenPortaMuestraDA command);

    }
    public class OrdenPortaMuestraService : IOrdenPortaMuestraService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        public OrdenPortaMuestraService(IMapper mapper,DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<OrdenPortaMuestraDA>> GetAll()
        {
            try
            {
               var response = await  _context.OrdenPortaMuestra.ToListAsync();
               var ordenPortaMuestraDA = _mapper.Map<List<OrdenPortaMuestraDA>>(response);
               return ordenPortaMuestraDA;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrdenPortaMuestraPosicionesDA> Find(int numero)
        {
            try
            {
                var response = await _context.OrdenPortaMuestra.FirstOrDefaultAsync(x=>x.Numero==numero);
                var ordenPortaMuestraDA = _mapper.Map<OrdenPortaMuestraPosicionesDA>(response);
                return ordenPortaMuestraDA;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrdenPortaMuestra> Post(OrdenPortaMuestraDA command)
        {

            try
            {
                PortaMuestra portaMuestraLimits = await _context.PortaMuestra.FirstOrDefaultAsync(x => x.IdPortaMuestra == command.IdPortaMuestra);

                OrdenPortaMuestra ordenPortaMuestra = _mapper.Map<OrdenPortaMuestra>(command);

                int TotalReg = await _context.OrdenPortaMuestra
                                      .Where(opm => opm.IdPortaMuestra == command.IdPortaMuestra)
                                      .CountAsync();

                int ColumSig = (TotalReg % portaMuestraLimits.Columnas) + 1;
                int? FilaSig  = (TotalReg / portaMuestraLimits.Filas) + 1;

                ordenPortaMuestra.PosicionColumna = ColumSig;
                ordenPortaMuestra.PosicionFila = FilaSig;
                ordenPortaMuestra.OrdenPortaMuestraId = Ulid.NewUlid().ToString();
                _context.Add<OrdenPortaMuestra>(ordenPortaMuestra);
                await _context.SaveChangesAsync();

                return ordenPortaMuestra;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
