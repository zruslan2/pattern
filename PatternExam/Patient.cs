using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    public class Patient:IObserver
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //список необходимых лекарств
        public List<Drug> RequiredDrugs { get; set; }
        //полученные лекарства
        public List<Drug> ReceivedDrugs { get; set; }
        //рецепты
        public List<string> Recipes { get; set; }

        public Patient(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.RequiredDrugs = new List<Drug>();
            this.ReceivedDrugs = new List<Drug>();
            this.Recipes = new List<string>();
        }

        public void AddRequiredDrug(Drug drug)
        {
            this.RequiredDrugs.Add(drug);
        }

        public void AddReceivedDrugs(List<Drug> drugs)
        {            
            this.ReceivedDrugs.AddRange(drugs);            
        }

        public void AddReceivedDrugs(Drug drug)
        {
            this.ReceivedDrugs.Add(drug);
        }

        public void AddRecipes(List<string> drugsName)
        {
            this.Recipes.AddRange(drugsName);
        }

        public void AddRecipes(string drugName)
        {
            this.Recipes.Add(drugName);
        }
        //спичок полученных лекарств пациентом
        public void ViewListReceivedDrugs()
        {
            Console.WriteLine("Cписок полученных лекарств: ");
            foreach (Drug drug in this.ReceivedDrugs)
            {
                drug.ViewInfo();
            }
        }
        //спичок полученных лекарств пациентом по рецепту
        public void ViewListReceivedDrugsWithRecipe()
        {
            Console.WriteLine("Cписок полученных лекарств по рецепту: ");
            foreach (Drug drug in this.ReceivedDrugs)
            {
                if(drug.RequiredRecipe == true)
                    drug.ViewInfo();
            }
        }
        public void GoToThePharmacy(Pharmacy pharmacy)
        {
            List<Drug> reqdrugs = new List<Drug>();
            reqdrugs.AddRange(pharmacy.pharmacist.PatientCare(this));
            foreach (Drug drug in reqdrugs)
            {
                this.RequiredDrugs.Remove(drug);
            }
        }

        public void Update(Drug drug, Pharmacy pharmacy)
        {
            List<Drug> ld = new List<Drug>();
            ld.AddRange(RequiredDrugs);
            foreach (Drug item in ld)
            {
                if (item.Name == drug.Name)
                {
                    this.GoToThePharmacy(pharmacy);
                }
            }
        }
    }
}
