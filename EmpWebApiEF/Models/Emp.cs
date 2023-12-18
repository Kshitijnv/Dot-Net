using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpWebApiEF.Models;

public partial class Emp
{
    public int EmpNo { get; set; }

    public string? EmpName { get; set; }

    public decimal? Basic { get; set; }

    public int? DeptNo { get; set; }
    [BindNever]
    public virtual Dept? DeptNoNavigation { get; set; }
}
