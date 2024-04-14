using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Web_App.Data;
using Web_App.Interfaces;
using Web_App.Models;
using Web_App.Repository;
using Web_App.ViewModels;

namespace Web_App.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductSupplier()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productViewmodel = await GetProduct(id);

            if (productViewmodel == null)
            {
                return NotFound();
            }

            return View(productViewmodel);
        }

        public async Task<IActionResult> Create()
        {
            var productViewModel = await PopularSuppliers(new ProductViewModel());
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await PopularSuppliers(productViewModel);
            if (!ModelState.IsValid) return View(productViewModel);

            await _productRepository.Add(_mapper.Map<Product>(productViewModel)); // Responsável por adicionar na base de dados

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewmodel = await GetProduct(id);

            if (productViewmodel == null)
            {
                return NotFound();
            }

            return View(productViewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            var productUpdate = await GetProduct(id);
            productUpdate.Supplier = productViewModel.Supplier;

            if (!ModelState.IsValid) return View(productViewModel);

            productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Value = productViewModel.Value;
            productUpdate.Active = productViewModel.Active;

            await _productRepository.Update(_mapper.Map<Product>(productUpdate));
            

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            return RedirectToAction("Index");
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

            return product;
        }
        
        private async Task<ProductViewModel> PopularSuppliers(ProductViewModel product)
        {
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

            return product;
        }

        private async Task<bool> UploadArchive(IFormFile archive, string archivePrefix)
        {
            if (archive.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/archives", archivePrefix + archive.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty,
                    $"{archive.FileName} was already uploaded in past! Try other archive.");
                return false;
            }

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await archive.CopyToAsync(stream);
            }

            return true;
        }
    }
}
