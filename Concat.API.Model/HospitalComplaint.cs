namespace Concat.API.Model
{
    public class HospitalComplaint
    {
        public int Id { get; set; }
        public int HospitalNo { get; set; }  
        public string Complaint { get; set; }  
        public DateTime Date { get; set; }  
    }
}
