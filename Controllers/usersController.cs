using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using komite.Models;
using komite.Data;

namespace komite.Controllers
{
    public class usersController : Controller
    {
        private string[] Mobiles;
        private readonly komiteContext _context;

        public usersController(komiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> sendsms()
        {
            //var client = new AmootSMS.AmootSMSWebService2SoapClient(
            //AmootSMS.AmootSMSWebService2SoapClient.EndpointConfiguration.AmootSMSWebService2Soap12,
            //"https://portal.amootsms.com/webservice2.asmx");
            //string UserName = "09127784722";
            //string Password = "@Alireza17439";
            //DateTime SendDateTime = DateTime.Now;
            //string SMSMessageText = "پیامک تستی من";
            //string LineNumber = "Service";
            //string[] Mobiles = new string[]
            //{
            //"09127784722",
            //};

            //// AmootSMS.AmootSMSWebService2SoapClient client = new AmootSMS.AmootSMSWebService2SoapClient("AmootSMSWebService2Soap12");

            //AmootSMS.SendResult result = client.SendSimpleAsync(UserName, Password, SendDateTime, SMSMessageText, LineNumber, Mobiles).Result;

            //if (result.Status == AmootSMS.Status.Success)
            //{
            //    //خروجی
            //}

            //return View("login");
            ////var e = _context.user.AsNoTracking().Where(s => s.id_user == never_asli.id_user).FirstOrDefault();
            ////Int64 id_bakhsh = e.id_bakhsh;
            ////var r = _context.bakhsh.AsNoTracking().Where(s => s.id_bakhsh == id_bakhsh).FirstOrDefault();
            var client = new AmootSMS.AmootSMSWebService2SoapClient(
             AmootSMS.AmootSMSWebService2SoapClient.EndpointConfiguration.AmootSMSWebService2Soap12,
             "https://portal.amootsms.com/webservice2.asmx");
            string UserName = "09127784722";
            string Password = "@Alireza17439";
            DateTime SendDateTime = DateTime.Now;
            int i=0;
            var w = _context.v_nbt_sms2.AsNoTracking().ToList();
            //string[] Mobiles = new string[w.Count];
            string[] Mobiles = new string[1];
            //for (i = 0; i < w.Count; i++)
            //{
            //    Mobiles[i] = w[i].dr_mobile.ToString();
            //}

            Mobiles[0] = "09127784722";
            string SMSMessageText = "تعداد بیماران بستری: " + w[i].count + " بیشتر از ده رو در بیمارستان بستری می باشد";
            string LineNumber = "Service";
            // AmootSMS.AmootSMSWebService2SoapClient client = new AmootSMS.AmootSMSWebService2SoapClient("AmootSMSWebService2Soap12");

            AmootSMS.SendResult result = client.SendSimpleAsync(UserName, Password, SendDateTime, SMSMessageText, LineNumber, Mobiles).Result;

            //if (result.Status == AmootSMS.Status.Success)
            //{
            //    sentsms sentsms = new sentsms();
            //    sentsms.status = "موفق";
            //    sentsms.id_never = never_asli.id_never;
            //    sentsms.id_user = never_asli.id_user;
            //    _context.Add(sentsms);
            //    await _context.SaveChangesAsync();
            //    _context.Entry(sentsms).State = EntityState.Detached;
            //}
            ViewBag.er_sms = "0";
            return View("dashboard1");
            //================================================sms
            
        }




        public async Task<IActionResult> login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> login(string u_name, string u_pass)
        {
            if (string.IsNullOrEmpty(u_name))
            {
                ViewBag.er_auth = "1";
                return View();
            }
            if (string.IsNullOrEmpty(u_pass))
            {
                ViewBag.er_auth = "1";
                return View();
            }
            else
            {
                if (u_name == "admin")
                {
                    if (u_pass == "100292")
                    {
                        return RedirectToAction("Index", "onvan_komite");
                    }
                    else
                    {
                        var q = _context.user.Where(s => s.u_name == u_name).Where(s => s.u_pass == u_pass);
                        if(q.Count() != 0)
                        {
                            HttpContext.Session.SetString("id_user", q.FirstOrDefault().id_user.ToString());
                            return RedirectToAction("Index_User", "onvan_komite");
                        }
                        ViewBag.er_auth = "1";
                        return View();

                    }
                }
                else
                {
                    var q = _context.user.Where(s => s.u_name == u_name).Where(s => s.u_pass == u_pass);
                    if (q.Count() != 0)
                    {
                        HttpContext.Session.SetString("id_user", q.FirstOrDefault().id_user.ToString());
                        return RedirectToAction("Index_User", "onvan_komite");
                    }
                    else
                    {
                    ViewBag.er_auth = "1";
                    return View();
                    }

                }

            }
        }

        public async Task<IActionResult> NoNumber()
        {
            var q = _context.v_nbt_sms2.Where(s=>s.dr_mobile==null||s.dr_mobile.Equals(string.Empty)).ToList();
            return View();
        }

        public async Task<IActionResult> dashboard1()
        {
            ViewBag.dr_name = new SelectList(_context.v_nbt_sms2, "id", "dr_name");

            return View();
        }

        public async Task<IActionResult> dashboard2(int id)
        {
            var q = _context.v_nbt_sms1.Where(s => s.id == id).ToList();
            return View(q);
        }

        public async Task<IActionResult> chart01()
        {
            var q = _context.v_nbt_sms2.AsNoTracking().OrderByDescending(s=>s.count).ToList();
            var count = q.Select(s => s.count).ToArray();
            var dr_name = q.Select(s => s.dr_name).ToList();
            //var dr_name = _context.v_nbt_sms2.AsNoTracking().Select(s => s.dr_name).ToArray();

            string[] backG = new string[count.Count()];
            for (int i = 0; i < count.Count(); i++)
            {
                if (i % 4 == 0)
                {
                    backG[i] = "rgba(255, 99, 132, 0.5)";
                }
                else if (i % 4 == 1)
                {
                    backG[i] = "rgba(75, 192, 192, 0.5)";
                }
                else if (i % 4 == 2)
                {
                    backG[i] = "rgba(153, 102, 255, 0.5)";
                }
                else if (i % 4 == 3)
                {
                    backG[i] = "rgba(255, 159, 64, 0.5)";
                }
                else
                {
                    backG[i] = "rgba(54, 162, 235, 0.5)";
                }
            }

            return new JsonResult(new { myDate = dr_name, count = count, backg = backG });

        }

       
        public async Task<IActionResult> Index()
        {
            //return View();
            return View(await _context.user.ToListAsync());
        }


        // GET: users/Create
        public IActionResult Create()
        {
            //ViewBag.id_bakhsh = new SelectList(_context.bakhsh, "id_bakhsh", "name_bakhsh");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_user,name,u_name,u_pass")] user user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            //ViewBag.id_bakhsh = new SelectList(_context.bakhsh, "id_bakhsh", "name_bakhsh",user.id_bakhsh);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_user,name,u_name,u_pass")] user user)
        {
            if (id != user.id_user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.id_user))
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
            return View(user);
        }

        // GET: users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.id_user == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'komiteContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userExists(long id)
        {
            return (_context.user?.Any(e => e.id_user == id)).GetValueOrDefault();
        }
    }
}
