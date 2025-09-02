using CourseMemory.Entities;

Console.Write("How many employees will be registered? ");
var n = int.Parse(Console.ReadLine() ?? "0");

for (int i = 0; i < n; i++)
{
	Console.WriteLine($"Employee #{i + 1}:");
	Console.Write("Id: ");
	var userId = int.Parse(Console.ReadLine() ?? "0");

	Console.Write("Name: ");
	var name = Console.ReadLine();

	Console.Write("Salary: ");
	var salary = double.Parse(Console.ReadLine() ?? "0");
	Console.WriteLine();

	EmployeeManager.Instance.AddEmployee(new()
	{
		Id = userId,
		Name = name,
		Salary = salary
	});
}

Console.Write("Enter the employee id that will have salary increase: ");

var id = await EmployeeManager.Instance.GetIdAsync();

var employee = EmployeeManager.Instance.GetEmployeeById(id);

double percentage;

Console.Write("Enter the percentage: ");
while (!double.TryParse(Console.ReadLine(), out percentage))
{
	Console.WriteLine("Error!");
	Console.Write("Please enter a valid percentage: ");
}

employee?.IncreaseSalary(percentage);

Console.WriteLine();

EmployeeManager.Instance.ListEmployee();
