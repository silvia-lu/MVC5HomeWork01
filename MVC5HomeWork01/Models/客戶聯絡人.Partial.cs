namespace MVC5HomeWork01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.RegularExpressions;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
       
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new 客戶資料Entities();
            if (!Regex.IsMatch(this.手機.ToString(), @"\d{4}-\d{6}"))
            {
                yield return new ValidationResult("手機格式不對，ex:0911-111111",
                       new string[] { "手機" });

            }

            if (this.Id == 0)
            {
                if (db.客戶聯絡人.Where(p => p.客戶Id == this.客戶Id && p.Email.Equals(this.Email)).Any())
                {
                    yield return new ValidationResult("同一個客戶下的聯絡人,Email不可重覆", new string[] { "Email" });
                }

            }
            else
            {
                if (db.客戶聯絡人.Where(p => p.客戶Id == this.客戶Id && p.Id != this.Id && p.Email.Equals(this.Email)).Any())
                {
                    yield return new ValidationResult("同一個客戶下的聯絡人,Email不可重覆", new string[] { "Email" });
                }
            }

            yield break;
        }
    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        [Required]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [EmailAddress(ErrorMessage = "信箱格式錯誤")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        
        public string 手機 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        [DisplayName("是否已刪除")]
        public bool IsDeleted { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
