using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    // класс лекарств
    public class Drug
    {
        public string Name { get; set; }
        public PharmacologicalGroup PharmGroup { get; set; }
        public bool RequiredRecipe = false;

        public void ViewInfo()
        {
            Console.WriteLine("Название лекарства: {0}, фармакологическая группа: {1}, отпуск только по рецепту: {2}", this.Name, this.PharmGroup, this.RequiredRecipe);
        }
    }

    public enum PharmacologicalGroup
    {
        Antibacterial, Antiparasitic, Tranquilizing
    }
    //строитель для создания лекрств(патерн испльзуется т.к. 
    //существуют лекарства отпускаемые по рецепту и без)
    public class DrugBuilder
    {
        private Drug _drug = new Drug();

        public DrugBuilder()
        {
            this.Reset();            
        }

        public void Reset()
        {
            this._drug = new Drug();
        }

        public void SetName(string name)
        {
            this._drug.Name = name;
        }

        public void SetPG(PharmacologicalGroup pg)
        {
            this._drug.PharmGroup = pg;
        }

        public void SetRequiredRecipe()
        {
            this._drug.RequiredRecipe = true;
        }

        public Drug GetProduct()
        {
            Drug result = this._drug;
            this.Reset();
            return result;
        }
    }
    // Директор испльзуется для быстрого создания и заполнения лекарств
    public class Director
    {
        public DrugBuilder db { get; set; }

        public void createDrugWithOutRequiredRecipe(string name, PharmacologicalGroup pg)
        {
            db.SetName(name);
            db.SetPG(pg);
        }

        public void createDrugWithRequiredRecipe(string name, PharmacologicalGroup pg)
        {
            db.SetName(name);
            db.SetPG(pg);
            db.SetRequiredRecipe();
        }
    }
}
