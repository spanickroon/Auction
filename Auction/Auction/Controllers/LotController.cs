using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data.Models;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Auction.Data.Interfaces;
using System.IO;
using Auction.Services;
using Microsoft.Extensions.Configuration;

namespace Auction.Controllers
{
    public class LotController : Controller
    {
        UserManager<User> _userManager;
        private readonly IUser _user;
        private readonly ILot _lot;

        public LotController(UserManager<User> userManager, IUser iUser, ILot iLot)
        {
            _user = iUser;
            _lot = iLot;
            _userManager = userManager;
        }
        public IActionResult CreateLot()
        {
            return View();
        }
        public async Task<IActionResult> CurrentLot(int id)
        {
            Lot lot = _lot.GetLotDB(id);

            if (lot == null)
            {
                return NotFound();
            }
            return View(lot);
        }

        public IActionResult AllLots()
        {
            return View(_lot.AllLots());
        }

        [HttpGet]
        public IActionResult MyLots()
        {
            return View(_lot.MyLot(_user.GetUserDB(_userManager.GetUserId(User))));
        }

        [HttpPost]
        public IActionResult CreateLot(LotViewModel model)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(model.AvatarLot.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.AvatarLot.Length);
            }

            string a = _userManager.GetUserId(User);

            Lot lot = new Lot
            {
                LotName = model.LotName,
                Discription = model.Discription,
                StartCost = model.StartCost,
                AvatarLot = imageData,
                User = _user.GetUserDB(_userManager.GetUserId(User)),
            };
            _lot.AddLotDB(lot);

            return RedirectToAction("MyLots", "Lot");
        }

        [HttpGet]
        public async Task<IActionResult> EditLot(int id)
        {
            Lot lot = _lot.GetLotDB(id);

            if (lot == null)
            {
                return NotFound();
            }

            LotViewModel model = new LotViewModel
            {
                Id = lot.Id,
                LotName = lot.LotName,
                Discription = lot.Discription,
                StartCost = lot.StartCost
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLot(LotViewModel model)
        {
            if (ModelState.IsValid)
            {
                Lot lot = _lot.GetLotDB(model.Id);
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(model.AvatarLot.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.AvatarLot.Length);
                }

                if (lot != null)
                {
                    lot.LotName = model.LotName;
                    lot.Discription = model.Discription;
                    lot.StartCost = model.StartCost;
                    lot.AvatarLot = imageData;
                    _lot.UpdateLot(lot);

                    return RedirectToAction("MyLots", "Lot");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteLot(int id)
        {
            Lot lot = _lot.GetLotDB(id);
            if (lot != null)
            {
                _lot.DeleteLot(lot);

            }
            return RedirectToAction("MyLots", "Lot");
        }
    }
}