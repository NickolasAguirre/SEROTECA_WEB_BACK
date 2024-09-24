using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Services
{

    public interface IOrdenPortaMuestraService
    {
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

        public async Task<OrdenPortaMuestra> Post(OrdenPortaMuestraDA command)
        {
            
            try
            {
                PortaMuestra portaMuestraLimits = await _context.PortaMuestra.FirstOrDefaultAsync(x => x.IdPortaMuestra == command.IdPortaMuestra);

                OrdenPortaMuestra ordenPortaMuestra = _mapper.Map<OrdenPortaMuestra>(command);

                var columnasFilas = await (from opm in _context.OrdenPortaMuestra
                                           join pm in _context.PortaMuestra on opm.IdPortaMuestra equals pm.IdPortaMuestra
                                           where pm.IdPortaMuestra == command.IdPortaMuestra
                                           select new OrdenPortaMuestraPosicionesDA
                                           {
                                               Columna = opm.PosicionColumna ,
                                               Fila = opm.PosicionFila 
                                           }).ToListAsync();

                var ultimaPosicion = columnasFilas.OrderByDescending(cf => cf.Fila)
                                                   .ThenByDescending(cf => cf.Columna)
                                                   .FirstOrDefault();

                int maxColumna = (int)(ultimaPosicion.Columna ?? 0);
                int maxFila = (int)(ultimaPosicion.Fila ?? 0);

                if (columnasFilas == null)
                {
                    maxColumna = 1;
                    maxFila = 1;
                }
                else
                {
                    if (maxColumna > portaMuestraLimits.Columnas)
                    {
                        maxColumna = 1;
                        maxFila += 1;
                    }
                    ordenPortaMuestra.PosicionColumna = maxColumna+1;
                    ordenPortaMuestra.PosicionFila = maxFila;
                }

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
