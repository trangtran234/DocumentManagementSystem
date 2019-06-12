﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Automapper
{
    public interface IAutoMapperConfig
    {
        IMapper GetMapper();
    }
}
