﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels;

public class RoleAssignVM
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public bool Exists { get; set; }
}