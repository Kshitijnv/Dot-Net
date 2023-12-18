using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpWebApiEF.Models;

public partial class Dept
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }
    [BindNever]
    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
