namespace ConsultaDisponibilidad.Model;

public class Availability
{
    public int room_id { get; set; }
    public string room_type { get; set; }
    public DateTime available_date { get; set; }
    public string status { get; set; }
}
