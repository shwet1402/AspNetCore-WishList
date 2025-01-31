﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WishList.Data;
using WishList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _context;
       

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
           var model = _context.Items.ToList();

            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {

            _context.Items.Add(item);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item item = _context.Items.FirstOrDefault(x => x.Id == id);

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
