using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FacultateWebApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FacultateWebService : System.Web.Services.WebService
    {
        private static List<Student> studenti = new List<Student>();
        private static List<String> materii = new List<string>();
        private static Dictionary<string, Dictionary<Student, int>> noteMaterii = new Dictionary<string, Dictionary<Student, int>>();

        [WebMethod]
        public int adaugaMaterie(string nume)
        {
            materii.Add(nume);
            noteMaterii[nume] = new Dictionary<Student, int>();
            return materii.Count;
        }

        [WebMethod]
        public int adaugaStudent(string nume, string grupa)
        {
            Student student = new Student(studenti.Count + 1, nume, grupa);
            studenti.Add(student);

            return studenti.Count;
        }

        [WebMethod]
        public void adaugaNota(int nota, int studentId, int materieId)
        {
            Student student = studenti.ElementAt(studentId - 1);
            string materie = materii.ElementAt(materieId - 1);

            noteMaterii[materie][student] = nota;
        }

        [WebMethod]
        //Poate ar trebui sa returneze doar numele
        public List<KVP<Student, int>> returneazaNote(int idMaterie)
        {
            string materie = materii.ElementAt(idMaterie - 1);
            return noteMaterii[materie].Select(kvp => new KVP<Student, int>(kvp.Key, kvp.Value)).ToList();
        }
            
        [WebMethod]
        public List<string> returneazaStudenti(string grupa)
        {
            return studenti.Where(s => s.Grupa == grupa).Select(s => s.Nume).ToList();
        }
    }
}
