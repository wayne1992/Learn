namespace Learn.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static TestRepository GetTestRepository()
		{
			var repository = new TestRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static TestRepository GetTestRepository(IUnitOfWork unitOfWork)
		{
			var repository = new TestRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static TestCategoryRepository GetTestCategoryRepository()
		{
			var repository = new TestCategoryRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static TestCategoryRepository GetTestCategoryRepository(IUnitOfWork unitOfWork)
		{
			var repository = new TestCategoryRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}