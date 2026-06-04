namespace PoissaHR.Shared.Dto
{
    public class DashboardDto
    {
        public List<EmployeeDto?> Employees { get; set; } = [];
        public List<AbsenceDto?> Absences { get; set; } = [];
        public List<DepartmentDto?> Departments { get; set; } = [];
    }
}
