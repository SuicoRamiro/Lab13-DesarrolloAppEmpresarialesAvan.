using System;
using System.Collections.Generic;

namespace Lab13_RamiroSuico.Domain.Models;

public partial class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = null!;
}
