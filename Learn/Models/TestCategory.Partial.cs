namespace Learn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TestCategoryMetaData))]
    public partial class TestCategory
    {
    }
    
    public partial class TestCategoryMetaData
    {
        [Required]
        public int TestCategoryId { get; set; }
        
        [StringLength(255, ErrorMessage="欄位長度不得大於 255 個字元")]
        public string TestCategoryName { get; set; }
        public Nullable<bool> TestCategoryIsDeleted { get; set; }
    
        public virtual ICollection<Test> Test { get; set; }
    }
}
