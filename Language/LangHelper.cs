using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace BankManagement.Language
{
    public partial class LangHelper
    {
        private ResourceManager _resourceManager;
        public LangHelper()
        {
            // Khởi tạo ResourceManager với tên gốc của tài nguyên (không bao gồm mã ngôn ngữ)
            _resourceManager = new ResourceManager("BankManagement.Language.Strings", Assembly.GetExecutingAssembly());
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
