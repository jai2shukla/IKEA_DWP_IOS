using Newtonsoft.Json;
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
            if (!Page.IsPostBack)
            {
                
                string temp = string.Empty;
                string bb = "";
                var data1 = 888;
                var data = findAll();
                grdData.DataSource = data;
                grdData.DataBind();
            }
            
        }
        private string Base_URL = "http://localhost:8081/api/";  
 
        public IEnumerable<EmployeeViewModel> findAll()
        {  
            try  
           {  
               HttpClient client = new HttpClient();  
                client.BaseAddress = new Uri(Base_URL);  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                HttpResponseMessage response = client.GetAsync("GetEmployees").Result;  
  
               if (response.IsSuccessStatusCode)  
                    return response.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;  
                return null;  
            }  
            catch  
            {  
                return null;  
            }  
        }
        public IEnumerable<EmployeeViewModel> find(int id)
       {  
            try  
            {  
                HttpClient client = new HttpClient();  
                client.BaseAddress = new Uri(Base_URL);  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                HttpResponseMessage response = client.GetAsync("GetEmployees?id=" + id).Result;  
  
                if (response.IsSuccessStatusCode)  
                    return response.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;  
                return null;  
            }  
            catch  
            {  
                return null;  
            }  
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var data =find(Convert.ToInt32(txtSearch.Text));
                        
            grdData.DataSource = string.Empty; 
            grdData.DataBind();
            grdData.DataSource = data;
            grdData.DataBind();
        }
        public string GetName(string firstName, string lastName)
        {  
            return string.Concat(firstName," ", lastName);  
        }

}
    public class Calculator
    {
        public static int Divide(int fnum,int snum)
        {
            int result = 0;
            return result = fnum / snum;
        }
    }
}