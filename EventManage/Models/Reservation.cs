using System;
using System.Collections.Generic;

namespace EventManage.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int EventId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? StatusId { get; set; }
}
