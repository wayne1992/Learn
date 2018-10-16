using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Learn.Models
{   
	public  class TestRepository : EFRepository<Test>, ITestRepository
	{

	}

	public  interface ITestRepository : IRepository<Test>
	{

	}
}