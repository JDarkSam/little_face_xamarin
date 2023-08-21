﻿using little_face.Data.Models.Dto;
using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public interface IChildService
    {
        Task<List<Child>> GetChildsAsync(long userId);
    }
}
