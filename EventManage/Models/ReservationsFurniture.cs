using System;
using System.Collections.Generic;

namespace EventManage.Models;

public partial class ReservationsFurniture
{
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public int FurnitureId { get; set; }
}
