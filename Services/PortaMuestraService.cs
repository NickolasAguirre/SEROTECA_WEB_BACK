using Azure;
using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.Models;

namespace SEROTECA_WEB_BACK.Services
{

    public interface IPortaMuestraService
    {
        public Task<PortaMuestra> GetLimits(int id);
    }

    public class PortaMuestraService: IPortaMuestraService
    {
        private readonly DatabaseContext _context;

        public PortaMuestraService(DatabaseContext databaseContext) {
            _context = databaseContext;
        }

        public async Task<PortaMuestra> GetLimits(int id)
        {
            try
            {
                var data = await _context.PortaMuestra.FirstOrDefaultAsync(pm => pm.IdPortaMuestra == id);
                return data;
            }catch (Exception ex)
            {
                return null;
            }
           
        }
    }
}
