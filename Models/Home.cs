using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EmployeeSkillManagement.Models;

public class HomeIndex
{

    public List<Skills> skill;

    public List<Employee> employees;

}