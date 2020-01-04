using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public interface IFeeTypeRepository
    {
        IEnumerable<FeeType> FeeTypes { get; }
        Task CreateFeeType(FeeType feeType);

        Task UpdateFeeType(FeeType feeType);

        Task DeleteFeeType(int? feeId);
    }
}
