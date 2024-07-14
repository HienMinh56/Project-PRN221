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
using Services;
using Microsoft.Identity.Client.Extensions.Msal;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BabyStore.Pages.Admin.ProductManagement
{
    public class CreateModel : PageModel
    {
        //private readonly Dbprn221Context _context;
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        //private readonly IImageHandle _imageHandle;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public CreateModel(ICategoryService category, IProductService product, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _category = category;
            _product = product;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            InitializeSelectLists();
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [Required(ErrorMessage = "Choose one File!")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,jpeg,jpe,bmp,gif,png")]
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Product.Image = await _product.AddImage(Image, _environment);
                _product.AddProduct(Product);
            }
            catch
            {
                ViewData["Error"] = "Product code already exists!";
                InitializeSelectLists();
                return Page();
            }
            return RedirectToPage("./Index");
        }
        private void InitializeSelectLists()
        {
            ViewData["CategoryId"] = new SelectList(_category.GetCategories(), "CategoryId", "Name");
        }
    }
}
