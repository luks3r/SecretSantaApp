﻿using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BusinessLogic.Entities
{
    public class Image : EntityBase
    {
        [Url] public string Url { get; set; } = default!;
        [MaxLength(128)] public string? Alt { get; set; }
    }
}