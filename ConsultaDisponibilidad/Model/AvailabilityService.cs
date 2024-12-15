using ConsultaDisponibilidad.Data;
using ConsultaDisponibilidad.Services;
using System.Xml.Linq;

namespace ConsultaDisponibilidad.Model;

public class AvailabilityService : IAvailabilityService
{
    private readonly AppDbContext _context;

    public AvailabilityService(AppDbContext context)
    {
        _context = context;
    }

    public XElement GetAvailability(DateTime startDate, DateTime endDate, string roomType)
    {
        var rooms = _context.Availability
            .Where(a => a.available_date >= startDate &&
                        a.available_date <= endDate &&
                        a.room_type == roomType &&
                        a.status == "Available")
            .ToList();

        XElement response = new XElement("Rooms",
            rooms.Select(r => new XElement("Room",
                new XElement("RoomId", r.room_id),
                new XElement("RoomType", r.room_type),
                new XElement("AvailableDate", r.available_date.ToString("yyyy-MM-dd")),
                new XElement("Status", r.status)
            ))
        );

        return response;
    }

    public XElement CheckAvailability(DateTime startDate, DateTime endDate, string roomType)
    {
        var rooms = _context.Availability
            .Where(a => a.available_date >= startDate &&
                        a.available_date <= endDate &&
                        a.room_type == roomType)
            .ToList();

        XElement response = new XElement("Rooms",
            rooms.Select(r => new XElement("Room",
                new XElement("RoomId", r.room_id),
                new XElement("RoomType", r.room_type),
                new XElement("AvailableDate", r.available_date.ToString("yyyy-MM-dd")),
                new XElement("Status", r.status)
            ))
        );

        return response;
    }
}