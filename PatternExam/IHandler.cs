using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    //патерн цепочка обязанностей использовал т.к. фармацевт не всегда
    //может полностью обслужить пациента если требуется рецепт на лекарство
    //надо перенаправить врачу 

    //интерфейс объявляющий два метода: построение цепочки обязанностей
    //и обслуживание клиента
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        List<Drug> PatientCare(Patient patientRequest);
    }


}
