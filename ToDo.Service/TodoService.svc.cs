using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ToDo.Service
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "TodoService" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione TodoService.svc ou TodoService.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class TodoService : ITodoService
    {
        public List<Tasks> GetTasks()
        {
            List<Tasks> taskList = new List<Tasks>();
            TODOEntities tdDb = new TODOEntities();
            var taskResult = from tk in tdDb.Tasks select tk;

            foreach(var task in taskResult)
            {
                Tasks tsk = new Tasks();
                tsk.id = task.id;
                tsk.title = task.title;
                tsk.description = task.description;

                taskList.Add(tsk);
            }

            return taskList;
        }

        public Tasks GetTaskById(int id)
        {
            TODOEntities tdDb = new TODOEntities();
            var taskResult = from tk in tdDb.Tasks where tk.id == id select tk;
            Tasks tsk = new Tasks();
            foreach (var task in taskResult)
            {
                tsk.id = task.id;
                tsk.title = task.title;
                tsk.description = task.description;
            }

            return tsk;
        }

        public int AddTask(string title, string description)
        {
            TODOEntities tdDb = new TODOEntities();
            Tasks tsk = new Tasks();
            tsk.title = title;
            tsk.description = description;

            tdDb.Tasks.Add(tsk);

            int retVal = tdDb.SaveChanges();
            
            return retVal;
        }

        public int UpdateTask(int id, string title, string description)
        {
            TODOEntities tdDb = new TODOEntities();
            Tasks tsk = new Tasks();
            tsk.id = id;
            tsk.title = title;
            tsk.description = description;

            tdDb.Entry(tsk).State = System.Data.Entity.EntityState.Modified;

            int retVal = tdDb.SaveChanges();

            return retVal;
        }

        public int DeleteTaskById(int id)
        {
            TODOEntities tdDb = new TODOEntities();
            Tasks tsk = new Tasks();
            tsk.id = id;

            tdDb.Entry(tsk).State = System.Data.Entity.EntityState.Deleted;

            int retVal = tdDb.SaveChanges();

            return retVal;
        }
    }
}
