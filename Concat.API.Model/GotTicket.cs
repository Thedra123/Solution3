using Concat.API.Model;

public class GotTicket
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Order { get; set; }
    public DateTime TicketTime { get; set; } = DateTime.Now;

    // Parametresiz yapıcı ekleyin
    public GotTicket() { }

    // Eğer parametreli yapıcıyı kullanmak istiyorsanız, EF için uygun hale getirin
    //public GotTicket(string firstName, string lastName)
    //{
    //    FirstName = firstName;
    //    LastName = lastName;
    //}
}



