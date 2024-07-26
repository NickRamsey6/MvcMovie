using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Actor
{
    public int ActorId { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string? FName { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string? LName { get; set; }

    public int? MovieId { get; set; }

}
