using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKEA_DWP_IOS
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<EmployeeViewModel> Employee = null;

            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8081/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // get something
            var responseTask = client.GetAsync("GetEmployees")

            responseTask.Wait();

            //To store result of web api response.   
            var result = responseTask.Result;

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStreamAsync();
                //var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                data.Wait();
                
                //Employee = data.Result;
            }
            else
            {
                //Error response received   
                Employee = Enumerable.Empty<EmployeeViewModel>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }

        }
    }
}