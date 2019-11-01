using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    // патерн наблюдатель использовал для того что бы аптека могла 
    // информировать клиентов о поступлении лекарств, и пациент мог
    // отреагировать и купить если оно есть в списке его запросов
    public interface IObserver
    {
        void Update(Drug drug, Pharmacy pharmacy);
    }

    public interface ISubject
    {        
        void Attach(IObserver observer);
        
        void Detach(IObserver observer);
        
        void Notify();
    }
}
