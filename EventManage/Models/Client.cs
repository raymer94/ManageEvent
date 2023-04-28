using System;
using System.Collections.Generic;

namespace EventManage.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? StatusId { get; set; }
}
