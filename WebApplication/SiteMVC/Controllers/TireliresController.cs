﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Repositories;

namespace SiteMVC.Controllers {
    public class TireliresController : Controller {
        IRepository<Produit> _repository;

        public TireliresController(IRepository<Produit> produitRepository) {
            _repository = produitRepository;
        }

        // GET: Tirelires
        public IActionResult Index() {
            //var tireliresContext = _context.Produit.Include(p => p.IdCategorieNavigation).Include(p => p.IdCouleurNavigation).Include(p => p.IdFabricantNavigation).Include(p => p.IdFournisseurNavigation);
            var liste = _repository.GetList();
            return View(liste);
        }


        public ActionResult Details(int id) {
            return View(_repository.GetById(id));
        }


        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit) {
            try {
                _repository.Create(produit);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public ActionResult Edit(int id) {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
