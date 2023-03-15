using System.ComponentModel.DataAnnotations;
public class AddStudent{
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
     [Required]
         public string? Address {get;set;}
     [Required]
        
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
public enum cate
{
    veg,
    nonveg
}