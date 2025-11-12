public class ServiceRequest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime SubmissionDate { get; set; }

    public ServiceRequest() { } // Parameterless constructor

    public ServiceRequest(int id, string desc, string status)
    {
        Id = id;
        Description = desc;
        Status = status;
        SubmissionDate = DateTime.Now;
    }
}
