using System;
using System.Collections.Generic;

namespace EventManage.Models;

public partial class Furniture
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
