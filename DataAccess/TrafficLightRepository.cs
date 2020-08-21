using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TraficLightsRazorPages.Models;

namespace TraficLightsRazorPages.Data
{
    public class TrafficLightRepository
    {
        private readonly TraficLightsContext _databaseContext;

        public TrafficLightRepository(TraficLightsContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<TraficLightsEntity> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _databaseContext.Lights.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        }
    }
}
