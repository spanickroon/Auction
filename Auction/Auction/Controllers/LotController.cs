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
        private readonly IPurchase _purchase;

        public LotController(UserManager<User> userManager, IUser iUser, ILot iLot, IPurchase iPurchase)
        {
            _user = iUser;
            _lot = iLot;
            _userManager = userManager;
            _purchase = iPurchase;
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
        public IActionResult MyPurchases()
        {
            return View(_purchase.MyPurchase(_user.GetUserDB(_userManager.GetUserId(User))));
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransaction(int id)
        {
            Lot lot = _lot.GetLotDB(id);
            User seller = await _userManager.FindByIdAsync(lot.UserId);
            User customer = await _userManager.FindByIdAsync(lot.CustomerId);
        
            string a = _userManager.GetUserId(User);

            Purchase purchase = new Purchase
            {
                PurchaseName = lot.LotName,
                Discription = lot.Discription,
                StartCost = lot.StartCost,
                CurrentCost = lot.CurrentCost,
                AvatarPurchase = lot.AvatarLot,
                Seller = lot.OwnerName,
                UserId = lot.CustomerId,
                OwnerName = lot.CustomerName,
                Status = false,
            };
            seller.Balance += lot.CurrentCost;
            customer.Balance -= lot.CurrentCost;
            lot.Status = false;
            _lot.UpdateLot(lot);
            _purchase.AddPurchaseDB(purchase);
            _purchase.UpdatePurchase(purchase);

            await _userManager.UpdateAsync(seller);
            await _userManager.UpdateAsync(customer);

            return RedirectToAction("MyLots", "Lot");
        }

        [HttpPost]
        public IActionResult MakeBet(int id)
        {
            Lot lot = _lot.GetLotDB(id);
            User seller = _user.GetUserDB(lot.UserId);
           
            lot.CurrentCost += (lot.StartCost / 10);
            lot.CustomerId = _userManager.GetUserId(User);
            lot.CustomerName = User.Identity.Name;
            _lot.UpdateLot(lot);

            return RedirectToAction("AllLots", "");
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
                CurrentCost = model.StartCost,
                AvatarLot = imageData,
                User = _user.GetUserDB(_userManager.GetUserId(User)),
                UserId = _userManager.GetUserId(User),
                OwnerName = User.Identity.Name,
                Status = true,
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
                StartCost = lot.StartCost,
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