using Microsoft.AspNetCore.Mvc;

namespace LibraryMsServer2.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    protected readonly ApplicationDatabaseContext  _context;
    public MemberController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Member>> Get()
    {
        return await _context.Members.ToListAsync();
    }
    
    // TODO : Implement get by Idenification number 
    [HttpGet("{identificationNumber}")]
    public async Task<Member> GetById(string identificationNumber)
    {
        return await _context.Members.FirstOrDefaultAsync(m => m.IdentificationNumber == identificationNumber);
    }
    
    [HttpPost]
    public async Task<Member> Post(Member member)
    {
        _context.Members.Add(member);//Add the member object to Members 
        await _context.SaveChangesAsync();// Post members to the database
        return member;
    }
}
