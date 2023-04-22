using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDb.Models;

public class Driver : BaseEntity
{

    public int TeamId { get; set; }
    public string Name { get; set; } = "";

    public int RacingNumber { get; set; }


    public virtual DriverMadia DriverMedia {get;set;}
    public virtual Team Team {get;set;}
}
