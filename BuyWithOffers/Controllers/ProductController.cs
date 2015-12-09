using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyWithOffers.App_Code;
using BuyWithOffers.Models;
namespace BuyWithOffers.Controllers
{

    public class ProductController : Controller
    {
        //
        // GET: /Product/
        Product objProduct = new Product();
        ProductDB objProductDB = new ProductDB();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Product()
        {
            ProductDB objProductDB = new ProductDB();
            List<SelectListItem> driphone6 = new List<SelectListItem>();
            objProduct.Iphone6 = objProductDB.GetIphone6(driphone6, "");
            ViewBag.iphone6data = objProduct.Iphone6;

            List<SelectListItem> driphone5 = new List<SelectListItem>();
            driphone5 = objProductDB.GetIphone5(driphone5, "");
            ViewBag.iphone5data = driphone5;

            List<SelectListItem> driIpad = new List<SelectListItem>();
            driIpad = objProductDB.GetIpad(driIpad, "");
            ViewBag.ipaddata = driIpad;

            List<SelectListItem> drmacbookair = new List<SelectListItem>();
            drmacbookair = objProductDB.GetMacBookAir(drmacbookair, "");
            ViewBag.macbookairdata = drmacbookair;

            List<SelectListItem> macbookpro = new List<SelectListItem>();
            macbookpro = objProductDB.GetMacBookPro(macbookpro, "");
            ViewBag.macbookprodata = macbookpro;


            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Product(string iphone6data, string iphone5data, string ipaddata, string macbookairdata, string macbookprodata)
        {
            List<SelectListItem> driphone6 = new List<SelectListItem>();
            objProduct.Iphone6 = objProductDB.GetIphone6(driphone6, iphone6data);
            ViewBag.iphone6data = objProduct.Iphone6;

            List<SelectListItem> driphone5 = new List<SelectListItem>();
            objProduct.Iphone5 = objProductDB.GetIphone5(driphone5, iphone5data);
            ViewBag.iphone5data = objProduct.Iphone5;

            List<SelectListItem> driIpad = new List<SelectListItem>();
            objProduct.Ipad = objProductDB.GetIpad(driIpad, ipaddata);
            ViewBag.ipaddata = objProduct.Ipad;

            List<SelectListItem> drmacbookair = new List<SelectListItem>();
            objProduct.MacBookAir = objProductDB.GetMacBookAir(drmacbookair, macbookairdata);
            ViewBag.macbookairdata = objProduct.MacBookAir;

            List<SelectListItem> macbookpro = new List<SelectListItem>();
            objProduct.MacBookPro = objProductDB.GetMacBookPro(macbookpro, macbookprodata);
            ViewBag.macbookprodata = objProduct.MacBookPro;

            bool isBrithday = Convert.ToBoolean(Request.Form["birthday"]);
            ViewData["isBirthday"] = isBrithday;
            bool isSeniorCitizen = Convert.ToBoolean(Request.Form["citizen"]);
            ViewData["isCitizen"] = isSeniorCitizen;
            //ViewBag.birthday=isBrithday;
            //ViewBag.senior = isSeniorCitizen;
            Utility objUtility = new Utility();
            objUtility.IsBirthday = isBrithday;
            objUtility.IsSeniorCitizen = isSeniorCitizen;

            if (iphone6data != "" && iphone6data != null)
                objUtility.Setiphone6price(Convert.ToInt16(iphone6data));

            if (iphone5data != "" && iphone5data != null)
                objUtility.Setiphone5price(Convert.ToInt16(iphone5data));

            if (ipaddata != "" && ipaddata != null)
                objUtility.Setipadprice(Convert.ToInt16(ipaddata));

            if (macbookairdata != "" && macbookairdata != null)
                objUtility.SetmacBookAirprice(Convert.ToInt16(macbookairdata));

            if (macbookprodata != "" && macbookprodata != null)
                objUtility.SetmacBookproprice(Convert.ToInt16(macbookprodata));


            bool schemetype = Convert.ToBoolean(Request.Form["schemetype"]);
            ViewData["schemetype"] = schemetype;
            Response.Write("Your total cost is <span style='color:green'>" + objUtility.GetGrandTotal(schemetype) + "</span>");
            return View();
        }


    }

}
