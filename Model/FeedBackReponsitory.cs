using BankManagement.Language;
using BankManagement.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace BankManagement.Model
{
    internal class FeedBackReponsitory
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";
        LangHelper langHelper;
        public FeedBackReponsitory()
        {
            langHelper = new LangHelper();
            if (WebConfigurationManager.AppSettings["Language"] != "")
            {
                langHelper.ChangeLanguage(WebConfigurationManager.AppSettings["Language"]);
            }
        }

        //thêm một feedback vaò cơ sở dự liệu
        public void addFeedBack(FeedBack feedBack)
        {
            string query = "INSERT INTO feedback(title,descriptions,staff_id,rating) VALUES(@Title,@Descriptions,@Staff_id,@Rating)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar) { Value = feedBack.Title });
                        cmd.Parameters.Add(new SqlParameter("@Descriptions", SqlDbType.NVarChar) { Value = feedBack.Description });
                        cmd.Parameters.Add(new SqlParameter("@Staff_id", SqlDbType.Int) { Value = feedBack.StaffId });
                        cmd.Parameters.Add(new SqlParameter("@Rating", SqlDbType.Int) { Value = feedBack.Rating });
                        cmd.ExecuteNonQuery();
                    }
                }
                CustomMessageBox.ShowBox(langHelper.GetString("Feedback sent successfully!"), "Success");
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
    }
}
