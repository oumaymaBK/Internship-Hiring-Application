using AutoMapper;
using Habanero.BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.Admin.Users;
using RazorPages.Pages.ViewModels;
using RazorPages.Utility;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace RazorPages.Pages.Admin.Projects
{
    public class AddOrEditModel : PageModel
    {

        //HHH attribut de décoration à ajouter


        //*//
        private readonly ILogger<RegisterModel> _logger;

        private readonly IHostEnvironment _environment;

        [BindProperty]
        public ProjectViewModel ProjectViewModel { get; set; }

        //*********** 1 ére étape de la liste de book La récupération de book de BD " slection de Book dans le formulaire" juste l'implémentation voi la récupération dans le code HTML 
        public IEnumerable<SelectListItem> BookList { get; set; }
        //l'ijection de dépendence dans le constructeur:
        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        private readonly IWebHostEnvironment _host;

        //3éme file: IWebHostEnvironment host:pour récupérer le chemin de fichier ili ya7tajou wwwroot
        public AddOrEditModel(ILogger<RegisterModel> logger,ProjetDbContext db, IMapper mapper, IToastNotification notify, IWebHostEnvironment host)//IToastNotification eni samitha notify 
        //et On n'oublie pas la déclaration "private readonly IToastNotification _notify;"+
        //+this._notify = notify;
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            this._host = host;
            _logger = logger;

        }
        public async Task OnGet(string? ProjectId)

        {

            if (ProjectId!= null)
            {
                Project? project = await _db.Project.FirstOrDefaultAsync(p => p.ProjectId == Guid.Parse(ProjectId));
                ProjectViewModel = _mapper.Map<ProjectViewModel>(project);
            }
            //****2éme étape de la selectiion de liste de Book 
            BookList = _db.Book.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.BookId.ToString()//value en string et id string pour ca onfa

            });
        }

        // 1ére L'ajout au BD :
        // public async Task<IActionResult> OnPost()

        public async Task<IActionResult> OnPost(List<IFormFile> FileImage)

        {

            //*//
            var filePath = "";
            foreach (var formFile in FileImage)
            {


                if (formFile.Length > 0)
                {   


                    filePath = Path.Combine("C:\\Users\\HELM11\\Downloads\\wetransfer_razorpage123_2024-06-21_2302\\RazorPage123\\RazorPages\\wwwroot\\Images\\Projects\\", formFile.FileName);
                    _logger.LogInformation("OnPost method filePath" + filePath);

                    using (var stream = System.IO.File.Create(filePath))
                    {


                        await formFile.CopyToAsync(stream);
                        _notify.AddSuccessToastMessage($"Project created successfully. Image saved at: {filePath}");
                                                        //                                                  //nzidouha fi meme dossier 

                    }
                }
                else
                {
                       _notify.AddErrorToastMessage("Project not Creatred !!!!!");
                    
                }

                

            }


            //4éme File :réquiperer le root de host + réquipérer le file
            //string webroot = _host.WebRootPath;
            //var files = HttpContext.Request.Form.Files;
            //string ImageFolder = @"Images\Projects";


            //    //:tout simplement c'est la combinaison entre le  ImageFolder et le Webroot
            //string UploadFolder = Path.Combine(webroot, ImageFolder);


            if (ModelState.IsValid)
            {   //Add Action
                if (ProjectViewModel.ProjectId == null)
                {
                    //        // Remarque:ON a besoin de Project Model NOn Project ViewModel pour ça on fait le mapping dans Utility/MappingProfil
                    //        //Voici la ligne écrite "CreateMap<Project,ProjectViewModel>().ReverseMap();
                    //        ////On doit l'ajouter en haut dans le constructeur+private Mapper
                    //        ///
                    //        //la distination vers <Project> w les données yjiwna min ProjectViewModel
                    //        //Auton Mapper y3awina bech kif n7ibou njibou attribut mano93douch na3mlou . kima  Projet.name= ProjectViewModel

                    Project project = _mapper.Map<Project>(ProjectViewModel);
                    //        //5éme file: récupérer le nom: peut étre plusieurs fichier files[0] on va récuperer le premiére valeur de file et on fait copie dans uploadFolder
                    //        //5éme file: récupérer le nom: peut étre plusieurs fichier files[0] on va récuperer le premiére valeur de file et on fait copie dans uploadFolder
                    //string fileNewName = await FileManager.CopyFile(files[0],UploadFolder); 
                    //        //6éme File:Ecraser l'ancienne valeur
                    project.ImageUrl = filePath;
                    _logger.LogInformation("OnPost method imagggge" + project.ImageUrl);

                    //        //project:l'entité qui réprésente le table Project dans BD 
                    await _db.Project.AddAsync(project);
                    //        // ON a ajouter "bool res" pour faire le test / >0=>On a changement dans BD => res == true
                    bool res = await _db.SaveChangesAsync() > 0;
                    //       
                    if (res)
                    {


                        /*{*/ //tant Mieux qu'on ajout une notification pour dire que je project est ajouté ou nonn
                              //                //à traver Toast qu'on doit l'ajouter dans le constructeur 
                        _notify.AddSuccessToastMessage("Project created successfully");
                        return RedirectToPage("Index"); //Min a7sen n'ajoutouha w najmou n5aliouha 7ata far8a bech mata3milnech mochkla 
                    }                              //                                                  //nzidouha fi meme dossier 

                    else
                    {
                     _notify.AddErrorToastMessage("Project not Creatred !!!!!");
                        


                    }


                }
                else
                {
                    //Update Action:
                    //Project project = _mapper.Map<Project>(ProjectViewModel);
                    //if (FileImage.Count > 0)
                    //{
                    //    //delete old image 
                    //    if (ProjectViewModel.FileImage != null)
                    //    {
                    //        var oldImage = Path.Combine(_host.WebRootPath, ProjectViewModel.FileImage);
                    //        FileManager.Deletefile(oldImage);
                    //    }
                    //    string newFileImage = await FileManager.CopyFile(FileImage[0], UploadFolder);
                    //    project.FileImage = Path.Combine("~/Images/Projects", newFileImage);
                    //}
                    //    _db.Project.Update(project);

                    //    project.FileImage = filePath;

                    //    _db.Project.Update(project);

                    //    bool res = await _db.SaveChangesAsync() > 0;

                    //    if (res)
                    //    {

                    //        /*{*/ //tant Mieux qu'on ajout une notification pour dire que je project est ajouté ou nonn
                    //              //                //à traver Toast qu'on doit l'ajouter dans le constructeur 
                    //        _notify.AddSuccessToastMessage("Project updated successfully");
                    //        return RedirectToPage("Index"); //Min a7sen n'ajoutouha w najmou n5aliouha 7ata far8a bech mata3milnech mochkla 
                    //    }                              //                                                  //nzidouha fi meme dossier 

                    //    else
                    //    {
                    //        _notify.AddErrorToastMessage("Project not updated !!!!!");



                    //    }
                    //if (ProjectViewModel.ProjectId == null)
                    
                       
                    
                
                    
                        Project project = _mapper.Map<Project>(ProjectViewModel);
                        _db.Project.Update(project);

                        bool res = await _db.SaveChangesAsync() > 0;

                        if (res)
                        {
                            _notify.AddSuccessToastMessage("Project updated successfully");
                            return RedirectToPage("Index");
                        }
                        else
                        {
                            _notify.AddErrorToastMessage("Project not updated!");
                        }
                }
                }
            
            return Page();
        }
        //As8el fonction hya delete 

        //public async Task<IActionResult> OnGetDelete(string ProjectId)
        //{
        //    Project project = await _db.Project.FirstOrDefaultAsync(p => p.ProjectId == Guid.Parse(ProjectId));
        //    if (project != null)
        //    {
        //        _db.Project.Remove(project);
        //        // Attendre la sauvegarde des modifications dans la base de données
        //        int savedChanges = await _db.SaveChangesAsync();

        //        // Vérifier si la suppression a réussi
        //        if (savedChanges > 0)
        //        {
        //            string _webroot = _host.WebRootPath;
        //            string imageFile = Path.Combine(_webroot, project.FileImage);

        //            // Vérifier si le fichier image existe avant de le supprimer

        //             FileManager.Deletefile(imageFile);
        //            //** return new JsonResult(new { msg = "ok" });
        //            return RedirectToPage("Index");
        //         }
        //        else
        //            {
        //                //****return new JsonResult(new { msg = "no" });
        //                return Page();
        //            }

        //            // Redirection vers la page d'index
        //            //return RedirectToPage("Index");

        //    }
        //    //***return new JsonResult(new { msg = "ok" });
        //    return Page();
        //}
        public async Task<IActionResult> OnGetDelete(string ProjectId)
        {
            Project project = await _db.Project.FirstOrDefaultAsync(p => p.ProjectId == Guid.Parse(ProjectId));
            if (project != null)
            {
                _db.Project.Remove(project);
                // Attendre la sauvegarde des modifications dans la base de données
                int savedChanges = await _db.SaveChangesAsync();

                // Vérifier si la suppression a réussi
                if (savedChanges > 0)
                {
                    string _webroot = _host.WebRootPath;
                    string imageFile = Path.Combine(_webroot, project.ImageUrl);

                    // Vérifier si le fichier image existe et si project.FileImage n'est pas null avant de le supprimer
                    if (!string.IsNullOrEmpty(project.ImageUrl))
                    {
                        FileManager.Deletefile(imageFile);
                    }

                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }

        // Si le projet n'existe pas ou s'il y a eu une erreur, retourner à la page actuelle

    }
}








