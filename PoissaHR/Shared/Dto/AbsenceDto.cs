namespace PoissaHR.Shared.Dto
{
    public class AbsenceDto
    {
        public Guid Id { get; set; }
        public string? LinkedEmploymentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public string? Notes { get; set; }
    }
}
