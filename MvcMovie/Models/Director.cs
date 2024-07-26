using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Director
{
    public int DirectorId { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string? DirectorName { get; set; }

}