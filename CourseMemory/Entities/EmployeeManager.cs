namespace CourseMemory.Entities
{
	internal class EmployeeManager
	{
		private List<Employee> _employees = [];
		private static EmployeeManager? _instance;
		public static EmployeeManager Instance
		{
			get
			{
				// (IDE0054 and IDE0074) The "??=" operator replaces the "if (_instance == null)" check, making the code clean.
				_instance ??= new EmployeeManager();
				return _instance;
			}
		}

		/// <summary>
		/// Add Employee in enterprise
		/// </summary>
		/// <param name="employee">Employee object</param>
		/// <exception cref="ArgumentException">If user id doesn't exist </exception>
		public void AddEmployee(Employee employee)
		{
			if (_employees.Any(x => x.Id == employee.Id)) 
				throw new ArgumentException("This employees already exist!");

			_employees.Add(employee);
		}

		public Employee? GetEmployeeById(int id)
		{
			return _employees.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Get id and verify if is a integer and/or that id exist in employee list
		/// </summary>
		/// <returns>return correct id</returns>
		public Task<int> GetIdAsync()
		{
			int id;
			while (!int.TryParse(Console.ReadLine(), out id) || !_employees.Any(x => x.Id == id))
			{
				Console.WriteLine("Ops! Try a valid number or valid Id.");
				Console.Write("Put a valid Id: ");
			}
			return Task.FromResult(id);
		}

		public void ListEmployee()
		{
			Console.WriteLine("Update List of Employees!");
			foreach (var item in _employees)
			{
				Console.WriteLine(item);
			}
		}
	}
}
