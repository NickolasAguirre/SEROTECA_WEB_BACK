using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Services
{

    public interface IPortaMuestraService
    {
        public Task<PortaMuestraDA> GetLimits(string id);

        public Task<PortaMuestra> Post(PortaMuestraCommandDA command);
    }



    public class PortaMuestraService: IPortaMuestraService
    {

        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public PortaMuestraService(DatabaseContext databaseContext, IMapper mapper )
        {
            _context = databaseContext;
            _mapper = mapper;
        }



        public async Task<PortaMuestraDA> GetLimits(string id)
        {
            try
            {
                var data = await _context.PortaMuestra.FirstOrDefaultAsync(pm => pm.IdPortaMuestra == id);
                PortaMuestraDA portaMuestraDA = new PortaMuestraDA();
                portaMuestraDA.Columnas = data.Columnas;
                portaMuestraDA.Filas = data.Filas;
                return portaMuestraDA;
            }catch (Exception ex)
            {
                return null;
            }
           
        }

        public async Task<PortaMuestra> Post(PortaMuestraCommandDA command)
        {
            try
            {
                PortaMuestra portaMuestra = _mapper.Map<PortaMuestra>(command);
                portaMuestra.IdPortaMuestra = Ulid.NewUlid().ToString();
                _context.Add<PortaMuestra>(portaMuestra);
                _context.SaveChanges();
                return portaMuestra;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
