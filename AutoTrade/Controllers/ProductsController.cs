using AutoMapper;
using AutoTrade.Models;
using Data.AutoTrade;
using Data.AutoTrade.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTrade.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public ProductsController(EFContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] ProductAddViewModel model)
        {
            try
            {
                string fileName = String.Empty;
                var product = _mapper.Map<ProductEntity>(model);

                if (model.Image != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.Image.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
                    fileName = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(fileName))
                    {
                        model.Image.CopyTo(file);
                    }
                    product.Image = randomFilename;
                }
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                Thread.Sleep(2000);
                var model = await _context.Products
                    .Select(x => _mapper.Map<ProductItemViewModel>(x)).ToListAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }
    }
}
