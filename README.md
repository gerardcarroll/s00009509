## RAD 301 CA1 MVC Bootstrap App

**Submission Date 12/11/2013**

The application has the following features/functionality:

* Initial (Home) page displays a list of Orders for Albums
* Permits searching for an order by First Name
* Sorting of Order List by Date(Ascending and Descending)
* Sorting of Order List by Total value of order(Ascending and Descending)
* Clicking via a button, to show the list of Albums in that Order
* A Back button to revert back to previous page/view
* Implemented a small Partial View for DateTime String in a Template

---

### Home Page

![Screenshot](screen.png)

---

### Albums Page

![Screenshot](screen2.png)

---


### Home Index Method

```csharp
public ActionResult Index(string searchTerm, string sortOrder)
		{
            ViewBag.message = "RAD 301 Music Store Orders";
            
            var allOrders = db.Orders.Where(o => searchTerm == null || o.FirstName.Contains(searchTerm));
            
            switch (sortOrder)
            {
                case "descend": allOrders = allOrders.OrderByDescending(o => o.OrderDate);
                    break;

                case "ascend": allOrders = allOrders.OrderBy(o => o.OrderDate);
                    break;

                case "Value_desc": allOrders = allOrders.OrderByDescending(o => o.Total);
                    break;

                case "Value_asc": allOrders = allOrders.OrderBy(o => o.Total);
                    break;
            }

            return View(allOrders);
		}       
```

---

### Format Order Date With Partial View 

```csharp
@model System.DateTime

@Model.ToShortDateString()
```
Using the above partial view:

```csharp
@Html.DisplayFor(modelItem => item.OrderDate, "ShortDateTime")
```

### Back Button Code

```csharp
@if (Request.UrlReferrer != null)
        {
            <input type="button" class="btn btn-danger" value="Go Back" onclick="history.go(-1); return false;" />
        }
```
