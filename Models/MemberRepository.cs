﻿using CsvHelper;
using GaaClub.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Member> Members
        {
            get
            {
                return _context.Members.Include(f => f.FeeType);
            }
        }

        public async Task CreateMember(Member member)
        {
            _context.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMember(int? memberId)
        {
            var member = await GetMemberByIdAsync(memberId);
            if (member != null)
            {
                _context.Remove(member);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<Member> GetMemberByIdAsync(int? memberId)
        {
            return await _context.Members
                .Include(f => f.FeeType)
                .SingleOrDefaultAsync(x => x.ID == memberId);
        }

        public async Task UpdateMember(Member member)
        {
            _context.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task UploadMembers(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    //full path to file in temp location
                    var filePath = Path.GetTempFileName();
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    var sr = new StreamReader(filePath);
                    var csvReader = new CsvReader(sr);
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.MissingFieldFound = null;
                    var members = csvReader.GetRecords<Member>().ToList();

                    if (members.Count() > 0)
                    {
                        foreach (var item in members)
                        {
                            var currentMember = _context.Members.FirstOrDefault(m => m.ID == item.ID);
                            if (currentMember == null)
                            {
                                await CreateMember(item);
                            }
                        }
                    }
                }
            }
        }

        public SelectList PopulateFeeTypeDropDownList(object selectedFeeType = null)
        {
            var feeTypeQuery = from f in _context.FeeTypes
                               orderby f.Type
                               select f;
            var feeSelectList = new SelectList(feeTypeQuery, "FeeID", "Type", selectedFeeType);

            return feeSelectList;
        }
    }
}
