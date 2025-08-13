using System;
using System.Collections.Generic;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;

namespace Freemold.Modules.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

}
