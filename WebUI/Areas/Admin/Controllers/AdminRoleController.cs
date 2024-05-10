using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager) : Controller
    {
        private readonly RoleManager<AppRole> _roleManager = roleManager;
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpGet]
        public IActionResult Index()
        {
            var vals = _roleManager.Roles.ToList();
            return View(vals);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.name
                };
                var res = await _roleManager.CreateAsync(role);
                if (res.Succeeded)
                {
                    return Redirect("/admin/adminrole/index");
                }
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var vals = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            RoleUpdateModel model = new RoleUpdateModel
            {
                Id = vals.Id,
                Name = vals.Name
            };

            return View(vals);
        }

        public async Task<IActionResult> UpdateRole(RoleUpdateModel model)
        {
            var vals = await _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            vals.Name = model.Name;
            var res = await _roleManager.UpdateAsync(vals);
            if (res.Succeeded)
            {
                return Redirect("/admin/adminrole/index");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var vals = await _roleManager.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            var res = await _roleManager.DeleteAsync(vals);
            if (res.Succeeded)
            {
                return Redirect("/admin/adminrole/index");
            }
            return View();
        }

        public async Task<IActionResult> UserRoleList()
        {
            var vals = await _userManager.Users.ToListAsync();
            return View(vals);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var person = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var roles = await _roleManager.Roles.ToListAsync();

            TempData["UserId"] = person.Id;
            var userRole = await _userManager.GetRolesAsync(person);
            List<RoleAssignViewModel> list = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel a = new RoleAssignViewModel();
                a.RoleId = role.Id;
                a.Name = role.Name;
                a.Exist = userRole.Contains(role.Name);
                list.Add(a);
            }
            return View(list);
        }

        [HttpPost]
        [Route("/updateuserrole")]
        public async Task<IActionResult> UpdateUserRole(List<RoleAssignViewModel>? modelList)
        {
            return Redirect("/admin/adminrole/index");
        }
    }
}
