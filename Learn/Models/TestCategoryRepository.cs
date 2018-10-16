using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Learn.Models
{   
	public  class TestCategoryRepository : EFRepository<TestCategory>, ITestCategoryRepository
	{

	}

	public  interface ITestCategoryRepository : IRepository<TestCategory>
	{

	}
}