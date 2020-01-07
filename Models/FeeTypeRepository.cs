using GaaClub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public class FeeTypeRepository : IFeeTypeRepository
    {

        public IEnumerable<FeeType> FeeTypes => throw new NotImplementedException();

        public Task CreateFeeType(FeeType feeType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFeeType(int? feeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFeeType(FeeType feeType)
        {
            throw new NotImplementedException();
        }
    }
}
