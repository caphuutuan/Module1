using Module1.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace Module1.Helper
{
    public static class Utilities
    {
        public static int PAGE_SIZE = 20;
        public static void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }
        public static string ToTitleCase(string str)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                var words = str.Split(' ');
                for (int index = 0; index < words.Length; index++)
                {
                    var s = words[index];
                    if (s.Length > 0)
                    {
                        words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    }
                }
                result = string.Join(" ", words);
            }
            return string.Join(" ", result);
        }
        public static bool IsInteger(string str)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            try
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                if (!regex.IsMatch(str))
                {
                    return false;
                }
            }
            catch
            {

            }
            return true;
        }
        public static string GetRandomKey(int length = 5)
        {
            string pattern = @"123456789zxcvbnmasdfghjklqwertyuiop[]{}:~!@#$%^&*()+";
            Random rd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }
            return sb.ToString();
        }

        public static string SEOUrl(this string url)
        {
            var result = url.ToLower().Trim();
            result = Regex.Replace(result, "áàảãạăắằẳẵặâấầẩẫậ", "a");
            result = Regex.Replace(result, "éèẻẽẹêếềểễệ", "e");
            result = Regex.Replace(result, "óòỏõọôốồổỗộơớờởỡợ", "o");
            result = Regex.Replace(result, "úùủũụưứừửữự", "u");
            result = Regex.Replace(result, "ýỳỷỹỵ", "y");
            result = Regex.Replace(result, "íìỉĩị", "i");
            result = Regex.Replace(result, "đ", "d");
            result = Regex.Replace(result, "[\\s'\";]", "-");
            result = Regex.Replace(result, "[,]", "");
            result = Regex.Replace(result, "[[]]", "");
            result = Regex.Replace(result, "[^a-z0-9-]", "");
            result = Regex.Replace(result, "(-)+", "");

            return result;
        }
        public static async Task<string> UploadFile(Microsoft.AspNetCore.Http.IFormFile formFile, string sDirectory, string newname)
        {
            try
            {
                if (newname == null)
                {
                    newname = formFile.FileName;
                }
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory);
                CreateIfMissing(path);
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory, newname);
                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif", "mp4", "avi", };
                var fileExt = System.IO.Path.GetExtension(formFile.FileName).Substring(1);
                if(!supportedTypes.Contains(fileExt.ToLower()))
                {
                    return null;
                }
                else
                {
                    using (var stream = new FileStream(pathFile, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    return newname;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
