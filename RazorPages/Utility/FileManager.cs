
using IoFile = System.IO.File;//lina 3ibara System.IO.File 3titha ism "IoFile" 
namespace RazorPages.Utility
{


    public static class FileManager


    {//A3mali copie min fichier ili jay min formulaire w 7othhouli fi dossier 
     //uploadFolder w a3tih un nom jdid ykoun unique 5ater ynajim nal9a wa7ed e5er bnefs nNom
     //Nom w traja3li ismou 
        public static async Task <string> CopyFile(IFormFile file, string uploadFolder)
        {
            var extention = Path.GetExtension(file.FileName);
            string newName = Guid.NewGuid().ToString()+extention;//=> génération de chaine de caractére unique name Unique
            var fileDest = Path.Combine(uploadFolder, newName);
            using (var fileStream = new FileStream(fileDest, FileMode.Create))
            { 
                await file.CopyToAsync(fileStream); }

            return newName;

        }



        //on ulitilse pour supprimer  l'enregistement de fichier "file" ou supprimer une image et le modifier par un autre file 
        public static void Deletefile(string filePath)
        {
            if (filePath!= null)
            {

                if (IoFile.Exists(filePath))
                { IoFile.Delete(filePath); }
            }
        }
    }
}
