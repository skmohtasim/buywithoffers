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
        Productdata objProductData = new Productdata();
        public ActionResult Index()
        {
            return View();
        }

        
       [HttpGet]
        public ActionResult Product()
        {
            
            List<SelectListItem> driphone6 = new List<SelectListItem>();
            driphone6 =objProductData.GetIphone6(driphone6,"");
            ViewBag.iphone6data = driphone6;

            List<SelectListItem> driphone5 = new List<SelectListItem>();
            driphone5 = objProductData.GetIphone5(driphone5, "");
            ViewBag.iphone5data = driphone5;

            List<SelectListItem> driIpad = new List<SelectListItem>();
            driIpad = objProductData.GetIpad(driIpad, "");
            ViewBag.ipaddata = driIpad;

            List<SelectListItem> drmacbookair = new List<SelectListItem>();
            drmacbookair = objProductData.GetMacBookAir(drmacbookair, "");
            ViewBag.macbookairdata = drmacbookair;

            List<SelectListItem> macbookpro = new List<SelectListItem>();
            macbookpro = objProductData.GetMacBookPro(macbookpro, "");
            ViewBag.macbookprodata = macbookpro;

          
            return View();
        }

        [HttpPost]
        public ActionResult Product(FormCollection collection)
        {
            List<SelectListItem> driphone6 = new List<SelectListItem>();
            string noOfIphone6= Request.Form["iphone6data"].ToString();
            driphone6 = objProductData.GetIphone6(driphone6, noOfIphone6);
            ViewBag.iphone6data = driphone6;


            List<SelectListItem> driphone5 = new List<SelectListItem>();
            string noOfIphone5 = Request.Form["iphone5data"].ToString();
            driphone5 = objProductData.GetIphone5(driphone5, noOfIphone5);
            ViewBag.iphone5data = driphone5;

            List<SelectListItem> driIpad = new List<SelectListItem>();
            string noOfIpad = Request.Form["ipaddata"].ToString();
            driIpad = objProductData.GetIpad(driIpad, noOfIpad);
            ViewBag.ipaddata = driIpad;

            List<SelectListItem> drmacbookair = new List<SelectListItem>();
            string noOfMacbookair = Request.Form["macbookairdata"].ToString();
            drmacbookair = objProductData.GetMacBookAir(drmacbookair, noOfMacbookair);
            ViewBag.macbookairdata = drmacbookair;

            List<SelectListItem> macbookpro = new List<SelectListItem>();
            string noOfMacbookpro= Request.Form["macbookprodata"].ToString();
            macbookpro = objProductData.GetMacBookPro(macbookpro, noOfMacbookpro);
            ViewBag.macbookprodata = macbookpro;

            bool isBrithday =Convert.ToBoolean(Request.Form["birthday"]);
            ViewData["isBirthday"] = isBrithday;
            bool isSeniorCitizen = Convert.ToBoolean(Request.Form["citizen"]);
            ViewData["isCitizen"] = isSeniorCitizen;
            //ViewBag.birthday=isBrithday;
            //ViewBag.senior = isSeniorCitizen;
            Utility objUtility = new Utility();
            objUtility.IsBirthday = isBrithday;
            objUtility.IsSeniorCitizen = isSeniorCitizen;

            if (noOfIphone6 != "" && noOfIphone6!=null)
                objUtility.Setiphone6price(Convert.ToInt16(noOfIphone6));

            if(noOfIphone5!="" && noOfIphone5!=null)
                objUtility.Setiphone5price(Convert.ToInt16(noOfIphone5));

            if (noOfIpad != "" && noOfIpad != null)
                objUtility.Setipadprice(Convert.ToInt16(noOfIpad));

            if (noOfMacbookair != "" && noOfMacbookair != null)
                objUtility.SetmacBookAirprice(Convert.ToInt16(noOfMacbookair));

            if (noOfMacbookpro != "" && noOfMacbookpro != null)
                objUtility.SetmacBookproprice(Convert.ToInt16(noOfMacbookpro));


            bool schemetype = Convert.ToBoolean(Request.Form["schemetype"]);
            ViewData["schemetype"] = schemetype;
            Response.Write("Your total cost is <span style='color:green'>" + objUtility.GetGrandTotal(schemetype) + "</span>");
            return View();
        }

       
    }

}
