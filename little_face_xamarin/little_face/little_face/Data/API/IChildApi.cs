﻿using little_face.Data.Models.Dto;
using little_face.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Data.API
{
    public interface IChildApi
    {
        [Get("/Childs")]
        Task<IEnumerable<Child>> GetChildsAsync(long userId);

        [Get("/Childs/{id}")]
        Task<Child> GetChild(long id);

        [Post("/Childs")]
        Task<Child> PostChild(ChildDto child);
        
    }
}
