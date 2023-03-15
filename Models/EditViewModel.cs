using System.ComponentModel.DataAnnotations;
public class Editview{
   [Key]
    public int Id {get;set;}
       [Required]
        [MaxLength(100)]
    public string? StudentName {get;set;}
     [Required]
        [MaxLength(100)]
    public string? Image{get;set;}
 [Required]
[MaxLength(100)]
    public string? Dob {get;set;}
    public string? Address {get;set;}
     [Required]
         [Range(1,100000, ErrorMessage ="Price must be between 1-1000.")]
    public String? Mobile {get;set;}
     [Required]
        [MaxLength(100)]
    public string? Email {get;set;}
     [Required]
        [MaxLength(100)]
    public string? Grade {get;set;}
     [Required]
        [MaxLength(100)]
    public string? Documents {get;set;}
     [Required]
        [MaxLength(100)]
    public string? Descriptions {get;set;}
}