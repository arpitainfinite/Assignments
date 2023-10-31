using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebAssignment
{
    public partial class Form1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the initial selection of the dropdown list
                Itemslist.SelectedIndex = 0;
                // Display the default image (you can set this in the markup as well)
                imgItem.ImageUrl = "Img/main.jfif";
            }
        }

        protected void Itemslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the image URL based on the selected item
            string selectedImageUrl = Itemslist.SelectedValue;
            imgItem.ImageUrl = $"Img/{selectedImageUrl}";
            lblCost.Text = ""; // Clear the cost label.
        }

        protected void btnShowCost_Click(object sender, EventArgs e)
        {
            string selectedItem =Itemslist.SelectedValue;

            // Define a dictionary of item costs (you can use a database in a real application).
            var itemCosts = new Dictionary<string, decimal>
            {
                { "smartphone.jpg", 20000.00m },
                { "laptops.jpeg", 50000.00m },
                { "headphones.jpg", 10000.00m },
                { "earbuds.jpg", 12900.00m },
            };

            if (itemCosts.ContainsKey(selectedItem))
            {
                lblCost.Text = $"Cost: ₹{itemCosts[selectedItem]}";
            }
            else
            {
                lblCost.Text = "Cost not available.";
            }
        }
    }
}