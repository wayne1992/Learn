namespace Learn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TestMetaData))]
    public partial class Test
    {
    }
    
    public partial class TestMetaData
    {
        [Required]
        public int TestId { get; set; }
        
        [StringLength(255, ErrorMessage="欄位長度不得大於 255 個字元")]
        public string TestName { get; set; }
        public Nullable<bool> TestIsDeleted { get; set; }
        public Nullable<int> TestCategoryId { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        public string TestCode { get; set; }
    
        public virtual TestCategory TestCategory { get; set; }
    }
}
