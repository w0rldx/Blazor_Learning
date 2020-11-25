using System;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Pages.Notes
{
    public class TaskModel
    {
        public Guid Guid { get; set; }
        
        [Required(ErrorMessage = "Titel wird benötigt")]
        [StringLength(20, ErrorMessage = "Titel ist zu lang")]
        public string Titel { get; set; }
        
        [Required(ErrorMessage = "Inhalt wird benötigt")]
        public string Inhalt { get; set; }
        public DateTime Erstellt { get; set; }
        public bool ReadOnly { get; set; } = true;

        // public TaskModel(string titel, string inhalt, bool readOnly)
        // {
        //     Titel = titel;
        //     Inhalt = inhalt;
        //     Erstellt = DateTime.Now;
        //     ReadOnly = readOnly;
        // }
    }
}