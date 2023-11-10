using System.Linq;
using System.Web.Mvc;
using Codebase_TestMVC;

public class CodeController : Controller
{
    private NorthwindEntities db = new NorthwindEntities(); 

    //1- Action method to get customers residing in Germany
    public ActionResult CustomersInGermany()
    {
        var germanCustomers = db.Customers.Where(c => c.Country == "Germany").ToList();
        return View(germanCustomers);
    }

    //2- Action method to get customer details with OrderId == 10248
    public ActionResult CustomerDetailsWithOrderId()
    {
        var customerId = db.Orders
            .Where(o => o.OrderID == 10248)
            .Select(o => o.CustomerID)
            .FirstOrDefault();

        var customerDetails = db.Customers
            .Where(c => c.CustomerID == customerId)
            .FirstOrDefault();

        return View(customerDetails);
    }
}
