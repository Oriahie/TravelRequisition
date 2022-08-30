using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelRequisition.Core.Entities;
using TravelRequisition.Core.Interface.Repositories;
using TravelRequisition.Core.Utilities;

namespace TravelRequisition.Infrastructure.Repositories
{
    public class TravelRequestRepository : ITravelRequestRepository
    {
        private readonly DbContext _dbContext;
        public TravelRequestRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TravelRequest> Create(TravelRequest model)
        {
            var record = await _dbContext.Set<TravelRequest>()
                                         .FirstOrDefaultAsync(x => x.ProposedDeparture == model.ProposedDeparture
                                                                && x.SourceCountry == model.SourceCountry
                                                                && x.SourceLocation == model.SourceLocation
                                                                && x.Destination == model.Destination
                                                                && x.Country == model.Country);
            if (record != null) throw new Exception("Record Already Exists");
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();


            model.RequisitionNumber = Helpers.GenerateRequisitionNumber(model.Id);
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();


            return model;
        }
               
        public async Task<bool> Delete(long reqNumber)
        {
            var record = await _dbContext.Set<TravelRequest>()
                                         .FirstOrDefaultAsync(x => x.RequisitionNumber == reqNumber);

            if (record == null) 
                throw new Exception("Record Not Found");
            
            if (record.RequisitionStatus == RequisitionStatus.Booked) 
                throw new Exception("Unable to delete an already booked request");
            
            _dbContext.Remove(record);
            await _dbContext.SaveChangesAsync();
            return true;
        }
               
        public async Task<List<TravelRequest>> GetAll()
        {
            return await _dbContext.Set<TravelRequest>().ToListAsync();
        }
               
        public async Task<TravelRequest> GetById(long id)
        {
            var record = await _dbContext.Set<TravelRequest>()
                                         .FirstOrDefaultAsync(x => x.Id == id);

            if (record == null) throw new Exception("Record Not Found");

            return record;
        }

        public async Task<TravelRequest> GetByRequisitionNumber(long reqNumber)
        {
            var record = await _dbContext.Set<TravelRequest>()
                                        .FirstOrDefaultAsync(x => x.RequisitionNumber == reqNumber);

            if (record == null) throw new Exception("Record Not Found");

            return record;
        }
               
        public async Task<TravelRequest> Update(TravelRequest model)
        {
            var record = await _dbContext.Set<TravelRequest>()
                                         .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (record == null) throw new Exception("Record Not Found");

            if (record.RequisitionStatus == RequisitionStatus.Booked)
                throw new Exception("Unable to update an already booked request");

            record.Name = model.Name ?? record.Name;
            record.ProposedDeparture = model.ProposedDeparture;
            record.ModifiedDate = DateTime.Now;
            record.RequisitionStatus = model.RequisitionStatus;
            record.SourceCountry = model.SourceCountry;
            record.SourceLocation = model.SourceLocation;
            record.TravelClass = model.TravelClass;
            record.TripType = model.TripType;
            record.ChargeCode = model.ChargeCode;
            record.Country = model.Country;
            record.Destination = model.Destination;

            await _dbContext.SaveChangesAsync();
            return record;
        }
    }
}
