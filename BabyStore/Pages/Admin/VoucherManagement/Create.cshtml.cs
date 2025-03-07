﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BOs;
using BOs.Entities;
using Services.Interfaces;

namespace BabyStore.Pages.Admin.VoucherManagement
{
    public class CreateModel : PageModel
    {
        private readonly IVoucherService _voucher;

        public CreateModel(IVoucherService voucher)
        {
            _voucher = voucher;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Voucher Voucher { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Voucher.CreatedBy = HttpContext.Session.GetString("username");
                await _voucher.AddVoucher(Voucher);
                TempData["message"] = "Add Voucher Successful";
                TempData["messageType"] = "success";
                return RedirectToPage("./Voucher");
            }
            catch (Exception ex)
            {
                TempData["message"] = "Add Voucher Failed";
                TempData["messageType"] = "error";
                return RedirectToPage("./Voucher");
            }
        }
    }
}
