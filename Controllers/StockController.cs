using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albumes.Data;
using Albumes.Models;
using Albumes.ViewModels;
using Albumes.Services;

namespace Albumes.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IAlbumService _albumService;

        public StockController(IStockService stockService, IAlbumService albumService)
        {
            _stockService = stockService;
            _albumService = albumService;
        }

        // GET: Stock
        public IActionResult Index()
        {
            var stocks = _stockService.GetAll();
            return stocks != null ? 
                          View(stocks) :
                          Problem("Entity set 'AlbumContext.Stock'  is null.");
        }

        // GET: Stock/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _stockService.GetById(id.Value);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stock/Create
        public IActionResult Create(int id)
        {
            StockCreateViewModel stockCreate = new StockCreateViewModel();
            stockCreate.ArtistId = id;
            stockCreate.Albums = _albumService.GetAll().Albums;
            stockCreate.Stock = new Stock();

            return View(stockCreate);
        }

        // POST: Stock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,AlbumId,ArtistId,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                var stockAlbum = _stockService.GetStockByArtistIdAndAlbumId(stock.ArtistId.Value, stock.AlbumId.Value);
                if(stockAlbum == null){
                    _stockService.Update(stock);                    
                } else{
                    int quantity = stockAlbum.Quantity + stock.Quantity;
                    stockAlbum.Quantity = quantity;
                    _stockService.Update(stockAlbum);
                }

                return RedirectToAction("Stock", "Artist", new { id = stock.ArtistId });
            }
            return View(stock);
        }

        // GET: Stock/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _stockService.GetById(id.Value);

            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Stock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,AlbumId,ArtistId,Quantity")] Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stockService.Update(stock);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Stock", "Artist", new { id = stock.ArtistId });
            }
            return View(stock);
        }

        // GET: Stock/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _stockService.GetById(id.Value);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var stock = _stockService.GetById(id);
            if (stock != null)
            {
                _stockService.Delete(stock);
            }

            return RedirectToAction("Stock", "Artist", new { id = stock.ArtistId });
        }

        private bool StockExists(int id)
        {
          return _stockService.GetById(id) != null;
        }
    }
}
