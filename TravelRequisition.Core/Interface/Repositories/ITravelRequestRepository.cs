using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelRequisition.Core.Entities;

namespace TravelRequisition.Core.Interface.Repositories
{
    public interface ITravelRequestRepository
    {
        Task<TravelRequest> Create(TravelRequest model);
        Task<TravelRequest> Update(TravelRequest model);
        Task<bool> Delete(long reqNumber);
        Task<TravelRequest> GetById(long id);
        Task<TravelRequest> GetByRequisitionNumber(long reqNumber);
        Task<List<TravelRequest>> GetAll();
        
    }
}
