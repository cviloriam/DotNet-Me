using AIC.Tools.Domain.DTO;
using AIC.Tools.Domain.Entities;
using AIC.Tools.Infraestructure.Query;
using AIC.Tools.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AIC.Tools.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> AxiesDetailsPVP(AxieDetailDTO axieDetailDTO)
        {
            axieDetailDTO = await QryAxiesDetailsAsync(axieDetailDTO);

            if (axieDetailDTO == null)
                return BadRequest();

            return View(axieDetailDTO);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<AxieDetailDTO> QryAxiesDetailsAsync(AxieDetailDTO axieDetailDTO) 
        {
            try
            {
                var listAxiesQry = new List<AxieDetail>() {
                    await GetDetailAxieId.DoIt(axieDetailDTO.axieId1),
                    await GetDetailAxieId.DoIt(axieDetailDTO.axieId2),
                    await GetDetailAxieId.DoIt(axieDetailDTO.axieId3)
                };

                axieDetailDTO.AxiesDetails = listAxiesQry;
                return axieDetailDTO;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
    }
}