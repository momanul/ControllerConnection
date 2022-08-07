using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStorePro.Context;
using BookStorePro.Models;

namespace BookStorePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FPER3003Controller : ControllerBase
    {
        private readonly FPER3003Context _context;

        public FPER3003Controller(FPER3003Context context)
        {
            _context = context;
        }

        // GET: api/FPER3003
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FPER3003>>> GetFPER3003()
        {
            UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
            if (user.UserId != 0.0m && user.UserName != "")
            {
                return await _context.FPER3003.ToListAsync();
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/FPER3003/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FPER3003>> GetFPER3003(decimal id)
        {
            UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
            var fPER3003 = await _context.FPER3003.FindAsync(id);

            if (user.UserId != 0.0m && user.UserName != "")
            {
                if (fPER3003 == null)
                {
                    return NotFound();
                }

                return fPER3003;
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/FPER3003/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFPER3003(decimal id, FPER3003 fPER3003)
        {
            UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
            if (user.UserId != 0.0m && user.UserName != "")
            {
                if (id != fPER3003.pER_Id)
                {
                    return BadRequest();
                }
                fPER3003.mOD_By = user.UserId;
                fPER3003.mOD_Dat = user.LogIn;
                _context.Entry(fPER3003).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FPER3003Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok("Updated Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/FPER3003
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FPER3003>> PostFPER3003(FPER3003 fPER3003)
        {
            UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
            if (user.UserId != 0.0m && user.UserName != "")
            {
                fPER3003.cRE_By = user.UserId;
                fPER3003.cRE_Dat = user.LogIn;
                fPER3003.mOD_By = user.UserId;
                fPER3003.mOD_Dat = user.LogIn;

                _context.FPER3003.Add(fPER3003);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFPER3003", new { id = fPER3003.pER_Id }, fPER3003);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/FPER3003/5
        [HttpDelete("{id}")]
        public ActionResult<FPER3003> DeleteFPER3003(decimal id)
        {
            UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
            if (user.UserId != 0.0m && user.UserName != "")
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        private bool FPER3003Exists(decimal id)
        {
            return _context.FPER3003.Any(e => e.pER_Id == id);
        }
    }
}
