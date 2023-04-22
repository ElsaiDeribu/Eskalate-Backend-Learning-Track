using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDb.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public int Status { get; set; }

    public int DateAdded { get; set; }

    public int DateUpdated { get; set; }

}
