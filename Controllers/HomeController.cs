using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Mngement_system.Entities;
using Student_Mngement_system.Models;

namespace Student_Mngement_system.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
    {
        _logger = logger;
        Environment = _environment;
    }

    public IActionResult Index()
    {
        return View();
    }

   public IActionResult ViewStudentList()
    {
       using (var context=new EmployeeDBContext())
        {
            var employeeList=context.StudentMangements.ToList();
             return View(employeeList);
        }
    }
     public IActionResult StudentDetailPage(int id)
{
    //handle your search stuff here...
         using (var context=new EmployeeDBContext())
        {
             var data=context.StudentMangements.FirstOrDefault(x=>x.Id==id);
             return View(data);
        }
}
     public IActionResult AddStudent()
    {
        return View();
    }
 [HttpPost]
        public IActionResult AddStudent(AddStudent StudentDetail,IFormFile Image)
    {
       string wwwPath = this.Environment.WebRootPath;
        string contentPath = this.Environment.ContentRootPath;
        string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        List<string> uploadedFiles = new List<string>();
            string fileName = Path.GetFileName(Image.FileName);
                  using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                Image.CopyTo(stream);
                uploadedFiles.Add(fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
        using (var context=new EmployeeDBContext())
        {
            StudentMangement employee=new StudentMangement();
            employee.Studentname =StudentDetail.StudentName;
            employee.Dob=StudentDetail.Dob;
            employee.Address=StudentDetail.Address;
            employee.Image=fileName;
            employee.Mobile=StudentDetail.Mobile;
            employee.Grade=StudentDetail.Grade;
             employee.Descriptions=StudentDetail.Descriptions;
              employee.Documents=StudentDetail.Documents;
                 employee.Email=StudentDetail.Email;
             
            context.StudentMangements.Add(employee);
            context.SaveChanges();
        
        }
        return RedirectToAction(actionName: "ViewStudentList", controllerName: "Home");
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet]
 public IActionResult Editview(int id)
   {
        using (var context=new EmployeeDBContext())
        {
            var data=context.StudentMangements.FirstOrDefault(x=>x.Id==id);
            if(data!=null){
            var viewmodel=new Editview(){
            Id =data.Id,
            StudentName =data.Studentname,
            Dob=data.Dob,
            Address=data.Address,
            Image=data.Image,
            Mobile=data.Mobile,
            Email=data.Email,
            Documents=data.Documents,
            Descriptions=data.Descriptions,
            Grade=data.Grade
            };
            return View(viewmodel);
        }
        return RedirectToAction(actionName: "ViewStudentList", controllerName: "Home");
    }}
    [HttpPost]
    public IActionResult Editview(Editview model){
             using (var context=new EmployeeDBContext())
        {
            var data=context.StudentMangements.Find(model.Id);
            if(data!=null){
                data.Studentname =model.StudentName;
                data.Dob=model.Dob;
                data.Address=model.Address;
                data.Image=model.Image;
                data.Mobile=model.Mobile;
                data.Email=model.Email;
                context.SaveChanges();
                  return RedirectToAction(actionName: "ViewStudentList", controllerName: "Home");
            }
               return RedirectToAction(actionName: "ViewStudentList", controllerName: "Home");
    }}
    public IActionResult DeleteDish(int Id)
    {
        using (var context = new EmployeeDBContext())
        {
            var candidateRecord = context.StudentMangements.FirstOrDefault(x => x.Id == Id);
            if (candidateRecord != null)
            {
                context.StudentMangements.Remove(candidateRecord);
                context.SaveChanges();
            }
            return RedirectToAction(actionName: "ViewStudentList", controllerName: "Home");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
