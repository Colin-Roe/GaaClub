using CsvHelper;
using GaaClub.Data;
using GaaClub.Models;
using GaaClub.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GaaClub.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<MembersController> _logger;

        public MembersController(IMemberRepository memberRepository, ILogger<MembersController> logger)
        {
            _memberRepository = memberRepository;
            _logger = logger;
        }

        [AllowAnonymous]
        // GET: Members
        public async Task<IActionResult> Index()
        {
            IEnumerable<Member> members;
            members = await _memberRepository.Members.ToListAsync();
            return View(members);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }

            _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting Member {id}", id);
            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,UserId,DateOfBirth,Gender,Email,Registered")] Member member)
        {
            if (ModelState.IsValid)
            {
                _logger.LogWarning(LoggingEvents.CREATE_ITEM, "Creating Member: {member}", member.FirstName);
                await _memberRepository.CreateMember(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Import
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadMembers(List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(LoggingEvents.UPLOAD_MEMBERS, "Uploading Members from file");
                await _memberRepository.UploadMembers(files);
            }
            return View(files);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            ViewBag.FeeID = _memberRepository.PopulateFeeTypeDropDownList(member.FeeID);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _memberRepository.UpdateMember(member);
                }
                catch (DbUpdateConcurrencyException)
                {
                    member = await _memberRepository.GetMemberByIdAsync(id);
                    if (member == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                } 
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberRepository.DeleteMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
