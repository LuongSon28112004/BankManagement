using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace BankManagement.Language
{
    public partial class LangHelper
    {
        private static LangHelper _instance;
        private static readonly object _lock = new object();
        private ResourceManager _resourceManager;
        public LangHelper()
        {
            // Khởi tạo ResourceManager với tên gốc của tài nguyên (không bao gồm mã ngôn ngữ)
            _resourceManager = new ResourceManager("BankManagement.Language.Strings", Assembly.GetExecutingAssembly());

            if (ConfigurationManager.AppSettings["Language"] != "")
            {
                ChangeLanguage(ConfigurationManager.AppSettings["Language"]);
            }
        }

        public static LangHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new LangHelper();
                    }
                }
                return _instance;
            }
        }

        // Phương thức lấy chuỗi ngôn ngữ với ngôn ngữ hiện tại
        public string GetString(string name)
        {
            return _resourceManager.GetString(name, CultureInfo.CurrentUICulture);
        }

        // Phương thức thay đổi ngôn ngữ
        public void ChangeLanguage(string language)
        {
            // Cập nhật ngôn ngữ của ứng dụng
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}