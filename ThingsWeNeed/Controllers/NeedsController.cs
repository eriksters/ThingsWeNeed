using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;
using ThingsWeNeed.Models.Binders;
using TwnData;
using ThingsWeNeed.Utility;

namespace ThingsWeNeed.Controllers
{
    public class NeedsController : Controller
    {
        public TwnContext context { get; set; }

        public NeedsController()
        {
            context = new TwnContext();
        }

        public NeedsController(TwnContext context) {
            this.context = context;
        }

        public ActionResult List() {
            int userId = 1;

            //  Open database connection
            using (context) {
                try
                {
                    ThingsListViewModel model = new ThingsListViewModel("Needs")
                    {
                        //  Eager load the purchases
                        //  (Decreases times the database needs to be accessed, no DB access happens in the views layer)
                        Title = "Household list",
                        User = context.Users
                            .Include("Households")
                            .Include("Households.Things")
                            .Include("Households.Things.Purchases")
                            .Single(x => x.UserId == userId)
                    };
                    //  Return View with complete ViewModel
                    return View("NeedsList", model);
                } catch (InvalidOperationException e) {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.InnerException);

                    return View("Error");
                }
            }
        }


        //  Action for handling purchases
        [HttpPost]
        public JsonResult Purchase([Bind(Prefix = "purchases", Include = "ThingId, ThingPrice")] CreateNeedData[] purchases) {
            
            //  Instantiate response builder
            JsonResponseBuilder builder = new JsonResponseBuilder();
            if (ModelState.IsValid)
            {
                try
                {
                    int changes = 0;

                    foreach (CreateNeedData data in purchases)
                    {

                        Thing thing = context.Things.Find(data.ThingId);

                        //  Check if the thing could be found
                        if (thing != null)
                        {

                            Purchase purchase = new Purchase
                            {
                                HouseholdId = thing.HouseholdId,
                                MadeById = 1,
                                Paid = data.ThingPrice,
                                ThingId = data.ThingId,
                                MadeOn = DateTime.Now,
                            };

                            context.Purchases.Add(purchase);
                            thing.Needed = false;
                            changes++;
                        }
                        else
                        {
                            //  If the thing could not be found, add the error to the response
                            builder.Errors.Add(new JsonResponseBuilder.Error
                            {
                                ErrorMessage = $"Thing with id [{data.ThingId}] could not be found"
                            });
                            builder.SendErrors = true;
                        }


                    }

                    //  Format the success response
                    builder.Success = true;
                    builder.SendData = true;
                    builder.Data = new { PurchasedAmount = changes };

                    //  Save changes
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    //  If an exception is caught, format and return the error
                    builder.Success = false;
                    builder.Errors.Add(new JsonResponseBuilder.Error
                    {
                        ErrorMessage = e.Message,
                        StackTrace = e.StackTrace,
                        Source = e.Source,
                    });
                }
                finally
                {
                    context.Dispose();
                }
            } 
            else
            {
                //  If model state is not valid, format and add the errors
                builder.Success = false;
                builder.SendErrors = true;
                foreach (ModelState state in ViewData.ModelState.Values) {
                    foreach (ModelError error in state.Errors) {
                        builder.Errors.Add(new JsonResponseBuilder.Error
                        {
                            ErrorMessage = error.ErrorMessage,
                        });
                    }
                }
            }
            //  Return the result
            return Json(builder.Build(), JsonRequestBehavior.AllowGet);
        }

    }
}