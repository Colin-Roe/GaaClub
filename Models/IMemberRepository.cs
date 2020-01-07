using GaaClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public interface IMemberRepository
    {
        IQueryable<Member> Members { get; }

        Task<Member> GetMemberByIdAsync(int? memberId);

        Task CreateMember(Member member);

        Task UpdateMember(Member member);

        Task DeleteMember(int? memberId);

        Task UploadMembers(List<IFormFile> files);

        SelectList PopulateFeeTypeDropDownList(object selectedFeeType = null);
    }
}
