using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ToDo.Service
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "ITodoService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        List<Tasks> GetTasks();

        [OperationContract]
        Tasks GetTaskById(int id);

        [OperationContract]
        int AddTask(string title, string description);

        [OperationContract]
        int UpdateTask(int id, string title, string description);

        [OperationContract]
        int DeleteTaskById(int id);
    }
}
