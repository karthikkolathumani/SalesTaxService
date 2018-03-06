using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Web.Services;

/// <summary>
/// WebService to calculate the Sales tax for the given zipcode
/// </summary>
[WebService(Namespace = "TaxRateCalculatorStudentProject")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService :  System.Web.Services.WebService {

    public WebService() {
    }

    [WebMethod]
    public TaxInfo getTax(String zipcode,String State) {
             SqlConnection sqlConnection1 = new SqlConnection("Data Source =(LocalDB)\\MSSQLLocalDB;" +"Integrated Security=true;"+ "AttachDbFileName=C:\\Users\\karth\\Documents\\Web Services\\TaxCalcWebSite\\TaxCalcWebSite\\TaxCalcWebSite\\App_Data\\AvalaraTax.mdf");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;


            try
            {
                sqlConnection1.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            int zipcd = Int32.Parse(zipcode);
            cmd.CommandText = "SELECT STATERATE,ESTCOUNTRYRATE,ESTCITYRATE,ESTSPECIALRATE from TaxDB where ZIPCODE ="+zipcd+"AND STATE='"+State+"';";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            double stateRate, ESTCOUNTRYRATE, ESTCITYRATE, ESTSPECIALRATE;
        
            TaxInfo taxInfo=null;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                stateRate = Convert.ToDouble(reader.GetValue(0));
                ESTCOUNTRYRATE = Convert.ToDouble(reader.GetValue(1));
                ESTCITYRATE = Convert.ToDouble(reader.GetValue(2));
                ESTSPECIALRATE = Convert.ToDouble(reader.GetValue(3));
                taxInfo = new TaxInfo(stateRate, ESTCOUNTRYRATE, ESTCITYRATE, ESTSPECIALRATE);
            }
        

            else {
                if (taxInfo == null)
                {
                    taxInfo = new TaxInfo();
                }
                taxInfo.setMessage("Zipcode not in the range [98001 - 99403]");
            }
       
                sqlConnection1.Close();

            return taxInfo;
    }

}
