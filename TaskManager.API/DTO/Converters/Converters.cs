using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Infrastructure;

namespace TaskManager.API.DTO
{
    #region NEWCONVERTERS
    public class ProdunctionTaskConverter : IConverter<ProductionTask, ProductionTaskDTO>
    {
        public ProductionTaskDTO ToDTO(ProductionTask productionTask)
        {
            return Converters.ToProductionTaskDTO(productionTask);
        }
        public List<Guid> ToDTO(List<ProductionTask> productionTasks)
        {
            return Converters.ToProductionTaskDTO(productionTasks);
        }
        //------------------------
        public ProductionTask FromDTO(ProductionTaskDTO productionTaskDTO)
        {
            return Converters.ToProductionTask(productionTaskDTO);
        }
        //public List<ProductionTask> FromDTO(List<Guid> productionTaskDTOs)
        //{
        //    return null;
        //} // NULL
    }

    public class DocumentConverter : IConverter<Document, DocumentDTO>
    {
        public DocumentDTO ToDTO(Document document)
        {
            return Converters.ToDocumentDTO(document);
        }
        public List<DocumentDTO> ToDTO(List<Document> documents)
        {
            return Converters.ToDocumentDTO(documents);
        }

        //------------------------
        public Document FromDTO(DocumentDTO documentDTO)
        {
            return Converters.ToDocument(documentDTO);
        }
        public List<Document> FromDTO(List<DocumentDTO> documentDTOs)
        {
            return Converters.ToDocument(documentDTOs);
        }
    }

    public class InDocumentConverter : IConverter<InDocument, InDocumentDTO>
    {
        public InDocumentDTO ToDTO(InDocument inDocument)
        {
            return Converters.ToInDocumentDTO(inDocument);
        }

        //------------------------
        public InDocument FromDTO(InDocumentDTO inDocumentDTO)
        {
            return Converters.ToInDocument(inDocumentDTO);
        }
    }

    public class OutDocumentConverter : IConverter<OutDocument, OutDocumentDTO>
    {
        public OutDocumentDTO ToDTO(OutDocument outDocument)
        {
            return Converters.ToOutDocumentDTO(outDocument);
        }
        public List<Guid> ToDTO(List<OutDocument> outDocuments)
        {
            return Converters.ToOutDocumentDTO(outDocuments);
        }

        //------------------------
        public OutDocument FromDTO(OutDocumentDTO outDocumentDTO)
        {
            return Converters.ToOutDocument(outDocumentDTO);
        }
        //public List<Guid> FromDTO(List<OutDocumentDTO> outDocumentDTOs)
        //{
        //    return null;
        //}//NULL
    }

    public class PersonConverter : IConverter<Person, PersonDTO>
    {
        public PersonDTO ToDTO(Person person)
        {
            return Converters.ToPersonDTO(person);
        }

        //------------------------
        public Person FromDTO(PersonDTO personDTO)
        {
            return Converters.ToPerson(personDTO);
        }
    }

    public class TaskTypeConverter : IConverter<TaskType, TaskTypeDTO>
    {
        public TaskTypeDTO ToDTO(TaskType taskType)
        {
            return Converters.ToTaskTypeDTO(taskType);
        }

        //------------------------
        public TaskType FromDTO(TaskTypeDTO taskTypeDTO)
        {
            return Converters.ToTaskType(taskTypeDTO);
        }
    }

    public class ProductionSubTaskConverter : IConverter<ProductionSubTask, ProductionSubTaskDTO>
    {
        public ProductionSubTaskDTO ToDTO(ProductionSubTask productinSubTask)
        {
            return Converters.ToProductinSubTaskDTO(productinSubTask);
        }
        public List<Guid> ToDTO(List<ProductionSubTask> productinSubTasks)
        {
            return Converters.ToProductinSubTaskDTO(productinSubTasks);
        }

        //------------------------
        public ProductionSubTask FromDTO(ProductionSubTaskDTO productinSubTaskDTO)
        {
            return Converters.ToProductinSubTask(productinSubTaskDTO);
        }
    }
    #endregion

    #region OLDCONVERTERS
    //public class ProdunctionTaskConverter : IConverter<ProductionTask, ProductionTaskDTO>
    //{
    //    public ProductionTaskDTO ToDTO(ProductionTask productionTask) 
    //    {
    //        if (productionTask == null) return null;
    //        ProductionTaskDTO productionTaskDTO = new ProductionTaskDTO
    //        {
    //            Id = productionTask.Id,
    //            Title = productionTask.Title,
    //            TaskContent = productionTask.TaskContent,
    //            Notes = productionTask.Notes,
    //            InitDate = productionTask.InitDate,
    //            State = productionTask.State,
    //            Priority = productionTask.Priority,
    //            DocReadyFlag = productionTask.DocReadyFlag,
    //            TaskReadyFlag = productionTask.TaskReadyFlag,
    //            TaskCancelFlag = productionTask.TaskCancelFlag,
    //            PlannedCompletionDate = productionTask.PlannedCompletionDate,
    //            ActualCompletionDate = productionTask.ActualCompletionDate,
    //            CancelDate = productionTask.CancelDate,
    //            ResponsibleExecutor = Converters.ToPersonDTO(productionTask.ResponsibleExecutor),
    //            TaskTypeId = productionTask.TaskTypeId,
    //            TaskType = Converters.ToTaskTypeDTO(productionTask.TaskType),
    //            InputDocs = Converters.ToInDocumentDTO(productionTask.InputDocs),
    //            ReportDocs = Converters.ToOutDocumentDTO(productionTask.ReportDocs),
    //            Tasks = Converters.ToProductinSubTaskDTO(productionTask.Tasks),
    //            CompletionBasics = Converters.ToDocumentDTO(productionTask.CompletionBasics),
    //            CancellationBasics = Converters.ToDocumentDTO(productionTask.CancellationBasics)
    //        };
    //        return productionTaskDTO;
    //    }
    //    public List<Guid> ToDTO(List<ProductionTask> productionTasks)
    //    {
    //        if (productionTasks == null) return null;
    //        List<Guid> productionTaskDTOs = new List<Guid>();
    //        foreach (var task in productionTasks)
    //        {
    //            productionTaskDTOs.Add(task.Id);
    //        }
    //        return productionTaskDTOs;
    //    }
    //    //------------------------
    //    public ProductionTask FromDTO(ProductionTaskDTO productionTaskDTO)
    //    {
    //        if (productionTaskDTO == null) return null;
    //        ProductionTask productionTask = new ProductionTask
    //        {
    //            Id = productionTaskDTO.Id,
    //            Title = productionTaskDTO.Title,
    //            TaskContent = productionTaskDTO.TaskContent,
    //            Notes = productionTaskDTO.Notes,
    //            InitDate = productionTaskDTO.InitDate,
    //            State = productionTaskDTO.State,
    //            Priority = productionTaskDTO.Priority,
    //            DocReadyFlag = productionTaskDTO.DocReadyFlag,
    //            TaskReadyFlag = productionTaskDTO.TaskReadyFlag,
    //            TaskCancelFlag = productionTaskDTO.TaskCancelFlag,
    //            PlannedCompletionDate = productionTaskDTO.PlannedCompletionDate,
    //            ActualCompletionDate = productionTaskDTO.ActualCompletionDate,
    //            CancelDate = productionTaskDTO.CancelDate,
    //            ResponsibleExecutor = Converters.ToPerson(productionTaskDTO.ResponsibleExecutor),
    //            TaskTypeId = productionTaskDTO.TaskTypeId,
    //            TaskType = Converters.ToTaskType(productionTaskDTO.TaskType),
    //            InputDocs = Converters.ToInDocument(productionTaskDTO.InputDocs),
    //            //ReportDocs = ToOutDocument(productionTaskDTO.ReportDocs),
    //            //Tasks = ToProductinSubTask(productionTaskDTO.Tasks),
    //            CompletionBasics = Converters.ToDocument(productionTaskDTO.CompletionBasics),
    //            CancellationBasics = Converters.ToDocument(productionTaskDTO.CancellationBasics)
    //        };
    //        return productionTask;
    //    }
    //    public List<ProductionTask> FromDTO(List<Guid> productionTaskDTOs)
    //    {
    //        return null;
    //    } // NULL
    //}


    //public class DocumentConverter : IConverter<Document, DocumentDTO>
    //{
    //    public DocumentDTO ToDTO(Document document)
    //    {
    //        if (document == null) { return null; }
    //        DocumentDTO documentDTO = new DocumentDTO
    //        {
    //            Id = document.Id,
    //            Title = document.Title,
    //            DocumentId = document.DocumentId
    //        };
    //        return documentDTO;
    //    }
    //    public List<DocumentDTO> ToDTO(List<Document> documents)
    //    {
    //        if (documents == null) return null;
    //        List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
    //        foreach (var doc in documents)
    //        {
    //            documentDTOs.Add(ToDTO(doc));
    //        }
    //        return documentDTOs;
    //    }

    //    //------------------------
    //    public Document FromDTO(DocumentDTO documentDTO)
    //    {
    //        if (documentDTO == null) return null;
    //        Document document = new Document
    //        {
    //            Id = documentDTO.Id,
    //            Title = documentDTO.Title,
    //            DocumentId = documentDTO.DocumentId
    //        };
    //        return document;
    //    }
    //    public List<Document> FromDTO(List<DocumentDTO> documentDTOs)
    //    {
    //        if (documentDTOs == null) return null;
    //        List<Document> documents = new List<Document>();
    //        foreach (var docDTO in documentDTOs)
    //        {
    //            documents.Add(FromDTO(docDTO));
    //        }
    //        return documents;
    //    }
    //}


    //public class InDocumentConverter : IConverter<InDocument, InDocumentDTO>
    //{
    //    public InDocumentDTO ToDTO(InDocument inDocument)
    //    {
    //        if (inDocument == null) return null;
    //        InDocumentDTO inDocumentDTO = new InDocumentDTO
    //        {
    //            Id = inDocument.Id,
    //            Name = inDocument.Name,
    //            Address = inDocument.Address,
    //            Email = inDocument.Email,
    //            DeliveryDate = inDocument.DeliveryDate,
    //            RegistrationDate = inDocument.RegistrationDate,
    //            RegistrPerson = Converters.ToPersonDTO(inDocument.RegistrPerson),
    //            MessageText = inDocument.MessageText,
    //            IncomingNumber = inDocument.IncomingNumber,
    //            ProductionTaskId = inDocument.ProductionTaskId,
    //            ProductionTask = Converters.ToProductionTaskDTO(inDocument.ProductionTask),
    //            Documents = Converters.ToDocumentDTO(inDocument.Documents)
    //        };
    //        return inDocumentDTO;
    //    }

    //    //------------------------
    //    public InDocument FromDTO(InDocumentDTO inDocumentDTO)
    //    {
    //        if (inDocumentDTO == null) return null;
    //        InDocument inDocument = new InDocument
    //        {
    //            Id = inDocumentDTO.Id,
    //            Name = inDocumentDTO.Name,
    //            Address = inDocumentDTO.Address,
    //            Email = inDocumentDTO.Email,
    //            DeliveryDate = inDocumentDTO.DeliveryDate,
    //            RegistrationDate = inDocumentDTO.RegistrationDate,
    //            RegistrPerson = Converters.ToPerson(inDocumentDTO.RegistrPerson),
    //            MessageText = inDocumentDTO.MessageText,
    //            IncomingNumber = inDocumentDTO.IncomingNumber,
    //            ProductionTaskId = inDocumentDTO.ProductionTaskId,
    //            //ProductionTask = ToProductionTask(inDocumentDTO.ProductionTask),
    //            Documents = Converters.ToDocument(inDocumentDTO.Documents)
    //        };
    //        return inDocument;
    //    }
    //}


    //public class OutDocumentConverter : IConverter<OutDocument, OutDocumentDTO>
    //{
    //    public OutDocumentDTO ToDTO(OutDocument outDocument)
    //    {
    //        if (outDocument == null) return null;
    //        OutDocumentDTO outDocumentDTO = new OutDocumentDTO
    //        {
    //            Id = outDocument.Id,
    //            Name = outDocument.Name,
    //            Address = outDocument.Address,
    //            Email = outDocument.Email,
    //            MessageText = outDocument.MessageText,
    //            ResponsePerson = Converters.ToPersonDTO(outDocument.ResponsePerson),
    //            DeliveryType = outDocument.DeliveryType,
    //            SentDocsDate = outDocument.SentDocsDate,
    //            OutgoingNumber = outDocument.OutgoingNumber,
    //            Executor = Converters.ToPersonDTO(outDocument.Executor),
    //            ExecutorNumber = outDocument.ExecutorNumber,
    //            State = outDocument.State,
    //            SendRespCommand = outDocument.SendRespCommand,
    //            SendRespCommandDate = outDocument.SendRespCommandDate,
    //            RespCommandPerson = Converters.ToPersonDTO(outDocument.RespCommandPerson),
    //            PlannsedRespDate = outDocument.PlannsedRespDate,
    //            ActualRespDate = outDocument.ActualRespDate,
    //            Notes = outDocument.Notes,
    //            ProductionTaskId = outDocument.ProductionTaskId,
    //            ProductionTask = Converters.ToProductionTaskDTO(outDocument.ProductionTask),
    //            Documents = Converters.ToDocumentDTO(outDocument.Documents)
    //        };
    //        return outDocumentDTO;
    //    }
    //    public List<Guid> ToDTO(List<OutDocument> outDocuments)
    //    {
    //        if (outDocuments == null) return null;
    //        List<Guid> outDocumentDTOs = new List<Guid>();
    //        foreach (var doc in outDocuments)
    //        {
    //            outDocumentDTOs.Add(doc.Id);
    //        }
    //        return outDocumentDTOs;
    //    }

    //    //------------------------
    //    public OutDocument FromDTO(OutDocumentDTO outDocumentDTO)
    //    {
    //        if (outDocumentDTO == null) return null;
    //        OutDocument outDocument = new OutDocument
    //        {
    //            Id = outDocumentDTO.Id,
    //            Name = outDocumentDTO.Name,
    //            Address = outDocumentDTO.Address,
    //            Email = outDocumentDTO.Email,
    //            MessageText = outDocumentDTO.MessageText,
    //            ResponsePerson = Converters.ToPerson(outDocumentDTO.ResponsePerson),
    //            DeliveryType = outDocumentDTO.DeliveryType,
    //            SentDocsDate = outDocumentDTO.SentDocsDate,
    //            OutgoingNumber = outDocumentDTO.OutgoingNumber,
    //            Executor = Converters.ToPerson(outDocumentDTO.Executor),
    //            ExecutorNumber = outDocumentDTO.ExecutorNumber,
    //            State = outDocumentDTO.State,
    //            SendRespCommand = outDocumentDTO.SendRespCommand,
    //            SendRespCommandDate = outDocumentDTO.SendRespCommandDate,
    //            RespCommandPerson = Converters.ToPerson(outDocumentDTO.RespCommandPerson),
    //            PlannsedRespDate = outDocumentDTO.PlannsedRespDate,
    //            ActualRespDate = outDocumentDTO.ActualRespDate,
    //            Notes = outDocumentDTO.Notes,
    //            ProductionTaskId = outDocumentDTO.ProductionTaskId,
    //            ProductionTask = Converters.ToProductionTask(outDocumentDTO.ProductionTask),
    //            Documents = Converters.ToDocument(outDocumentDTO.Documents)
    //        };
    //        return outDocument;
    //    }
    //    //public List<OutDocument> FromDTO(List<Guid> DocumentGuids, Context context)
    //    //{
    //    //    if (DocumentGuids == null) return null;
    //    //    OutDocumentRepository repository = new OutDocumentRepository(context);
    //    //    List<OutDocument> outDocuments = new List<OutDocument>();
    //    //    foreach (var doc in DocumentGuids)
    //    //    {
    //    //        repository.
    //    //        outDocuments.Add();
    //    //    }
    //    //    return outDocuments;
    //    //}
    //}


    //public class PersonConverter : IConverter<Person, PersonDTO>
    //{
    //    public PersonDTO ToDTO(Person person)
    //    {
    //        if (person == null) return null;
    //        PersonDTO personDTO = new PersonDTO
    //        {
    //            Id = person.Id,
    //            Name = person.Name,
    //            UserId = person.UserId
    //        };
    //        return personDTO;
    //    }

    //    //------------------------
    //    public Person FromDTO(PersonDTO personDTO)
    //    {
    //        if (personDTO == null) return null;
    //        Person person = new Person
    //        {
    //            Id = personDTO.Id,
    //            Name = personDTO.Name,
    //            UserId = personDTO.UserId
    //        };
    //        return person;
    //    }
    //}


    //public class TaskTypeConverter : IConverter<TaskType, TaskTypeDTO>
    //{
    //    public TaskTypeDTO ToDTO(TaskType taskType)
    //    {
    //        if (taskType == null) return null;
    //        TaskTypeDTO taskTypeDTO = new TaskTypeDTO
    //        {
    //            Id = taskType.Id,
    //            Code = taskType.Code,
    //            Name = taskType.Name,
    //            ProductionTasks = Converters.ToProductionTaskDTO(taskType.ProductionTasks)
    //        };
    //        return taskTypeDTO;
    //    }

    //    //------------------------
    //    public TaskType FromDTO(TaskTypeDTO taskTypeDTO)
    //    {
    //        if (taskTypeDTO == null) return null;
    //        TaskType taskType = new TaskType
    //        {
    //            Id = taskTypeDTO.Id,
    //            Code = taskTypeDTO.Code,
    //            Name = taskTypeDTO.Name
    //        };
    //        return taskType;
    //    }
    //}


    //public class ProductionSubTaskConverter : IConverter<ProductionSubTask, ProductionSubTaskDTO>
    //{
    //    public ProductionSubTaskDTO ToDTO(ProductionSubTask productinSubTask)
    //    {
    //        if (productinSubTask == null) return null;
    //        ProductionSubTaskDTO productinSubTaskDTO = new ProductionSubTaskDTO
    //        {
    //            Id = productinSubTask.Id,
    //            Comments = productinSubTask.Comments,
    //            ExecutorReport = productinSubTask.ExecutorReport,
    //            PlannedCompletionDate = productinSubTask.PlannedCompletionDate,
    //            ActualCompletionDate = productinSubTask.ActualCompletionDate,
    //            State = productinSubTask.State,
    //            Priority = productinSubTask.Priority,
    //            InitDate = productinSubTask.InitDate,
    //            Executor = Converters.ToPersonDTO(productinSubTask.Executor),
    //            ConfirmDate = productinSubTask.ConfirmDate,
    //            ReportFlag = productinSubTask.ReportFlag,
    //            TaskReadyFlag = productinSubTask.TaskReadyFlag,
    //            CancelFlag = productinSubTask.CancelFlag,
    //            CancelDate = productinSubTask.CancelDate,
    //            ProductionTask = Converters.ToProductionTaskDTO(productinSubTask.ProductionTask),
    //            UpperTask = Converters.ToProductinSubTaskDTO(productinSubTask.UpperTask),
    //            SubTasks = Converters.ToProductinSubTaskDTO(productinSubTask.SubTasks),
    //            ReportDocs = Converters.ToDocumentDTO(productinSubTask.ReportDocs)
    //        };
    //        return productinSubTaskDTO;
    //    }
    //    public List<Guid> ToDTO(List<ProductionSubTask> productinSubTasks)
    //    {
    //        if (productinSubTasks == null) return null;
    //        List<Guid> productinSubTaskDTOs = new List<Guid>();
    //        foreach (var task in productinSubTasks)
    //        {
    //            productinSubTaskDTOs.Add(task.Id);
    //        }
    //        return productinSubTaskDTOs;
    //    }

    //    //------------------------
    //    public ProductionSubTask FromDTO(ProductionSubTaskDTO productinSubTaskDTO)
    //    {
    //        if (productinSubTaskDTO == null) return null;
    //        ProductionSubTask productinSubTask = new ProductionSubTask
    //        {
    //            Id = productinSubTaskDTO.Id,
    //            Comments = productinSubTaskDTO.Comments,
    //            ExecutorReport = productinSubTaskDTO.ExecutorReport,
    //            PlannedCompletionDate = productinSubTaskDTO.PlannedCompletionDate,
    //            ActualCompletionDate = productinSubTaskDTO.ActualCompletionDate,
    //            State = productinSubTaskDTO.State,
    //            Priority = productinSubTaskDTO.Priority,
    //            InitDate = productinSubTaskDTO.InitDate,
    //            Executor = Converters.ToPerson(productinSubTaskDTO.Executor),
    //            ConfirmDate = productinSubTaskDTO.ConfirmDate,
    //            ReportFlag = productinSubTaskDTO.ReportFlag,
    //            TaskReadyFlag = productinSubTaskDTO.TaskReadyFlag,
    //            CancelFlag = productinSubTaskDTO.CancelFlag,
    //            CancelDate = productinSubTaskDTO.CancelDate,
    //            ProductionTask = Converters.ToProductionTask(productinSubTaskDTO.ProductionTask),
    //            UpperTask = Converters.ToProductinSubTask(productinSubTaskDTO.UpperTask),
    //            //SubTasks = ToProductinSubTask(productinSubTaskDTO.SubTasks),
    //            ReportDocs = Converters.ToDocument(productinSubTaskDTO.ReportDocs)
    //        };
    //        return productinSubTask;
    //    }
    //    //public List<ProductinSubTask> FromDTO(List<Guid> productinSubTaskGuids)
    //    //{
    //    //    if (productinSubTaskGuids == null) return null;
    //    //    List<Guid> productinSubTasks = new List<Guid>();
    //    //    foreach (var task in productinSubTaskGuids)
    //    //    {
    //    //        productinSubTasks.Add();
    //    //    }
    //    //    return productinSubTasks;
    //    //}
    //}
    #endregion


    public static class Converters
    {
        #region PRODUCTIONTASK
        public static ProductionTaskDTO ToProductionTaskDTO(ProductionTask productionTask)
        {
            if (productionTask == null) return null;
            ProductionTaskDTO productionTaskDTO = new ProductionTaskDTO
            {
                Id = productionTask.Id,
                Title = productionTask.Title,
                TaskContent = productionTask.TaskContent,
                Notes = productionTask.Notes,
                InitDate = productionTask.InitDate,
                State = productionTask.State,
                Priority = productionTask.Priority,
                DocReadyFlag = productionTask.DocReadyFlag,
                TaskReadyFlag = productionTask.TaskReadyFlag,
                TaskCancelFlag = productionTask.TaskCancelFlag,
                PlannedCompletionDate = productionTask.PlannedCompletionDate,
                ActualCompletionDate = productionTask.ActualCompletionDate,
                CancelDate = productionTask.CancelDate,
                ResponsibleExecutor = ToPersonDTO(productionTask.ResponsibleExecutor),
                TaskTypeId = productionTask.TaskTypeId,
                TaskType = ToTaskTypeDTO(productionTask.TaskType),
                InputDocs = ToInDocumentDTO(productionTask.InputDocs),
                ReportDocs = ToOutDocumentDTO(productionTask.ReportDocs),
                Tasks = ToProductinSubTaskDTO(productionTask.Tasks),
                CompletionBasics = ToDocumentDTO(productionTask.CompletionBasics),
                CancellationBasics = ToDocumentDTO(productionTask.CancellationBasics)
            };
            return productionTaskDTO;
        }
        public static List<Guid> ToProductionTaskDTO(List<ProductionTask> productionTasks)
        {
            if (productionTasks == null) return null;
            List<Guid> productionTaskDTOs = new List<Guid>();
            foreach (var task in productionTasks)
            {
                productionTaskDTOs.Add(task.Id);
            }
            return productionTaskDTOs;
        }

        //------------------------
        public static ProductionTask ToProductionTask(ProductionTaskDTO productionTaskDTO)
        {
            if (productionTaskDTO == null) return null;
            ProductionTask productionTask = new ProductionTask
            {
                Id = productionTaskDTO.Id,
                Title = productionTaskDTO.Title,
                TaskContent = productionTaskDTO.TaskContent,
                Notes = productionTaskDTO.Notes,
                InitDate = productionTaskDTO.InitDate,
                State = productionTaskDTO.State,
                Priority = productionTaskDTO.Priority,
                DocReadyFlag = productionTaskDTO.DocReadyFlag,
                TaskReadyFlag = productionTaskDTO.TaskReadyFlag,
                TaskCancelFlag = productionTaskDTO.TaskCancelFlag,
                PlannedCompletionDate = productionTaskDTO.PlannedCompletionDate,
                ActualCompletionDate = productionTaskDTO.ActualCompletionDate,
                CancelDate = productionTaskDTO.CancelDate,
                ResponsibleExecutor = ToPerson(productionTaskDTO.ResponsibleExecutor),
                TaskTypeId = productionTaskDTO.TaskTypeId,
                TaskType = ToTaskType(productionTaskDTO.TaskType),
                InputDocs = ToInDocument(productionTaskDTO.InputDocs),
                //ReportDocs = ToOutDocument(productionTaskDTO.ReportDocs),
                //Tasks = ToProductinSubTask(productionTaskDTO.Tasks),
                CompletionBasics = ToDocument(productionTaskDTO.CompletionBasics),
                CancellationBasics = ToDocument(productionTaskDTO.CancellationBasics)
            };
            return productionTask;
        }
        #endregion

        //======================================================================================
        #region TASKTYPE
        public static TaskTypeDTO ToTaskTypeDTO(TaskType taskType)
        {
            if (taskType == null) return null;
            TaskTypeDTO taskTypeDTO = new TaskTypeDTO
            {
                Id = taskType.Id,
                Code = taskType.Code,
                Name = taskType.Name,
                ProductionTasks = ToProductionTaskDTO(taskType.ProductionTasks)
            };
            return taskTypeDTO;
        }

        //------------------------
        public static TaskType ToTaskType(TaskTypeDTO taskTypeDTO)
        {
            if (taskTypeDTO == null) return null;
            TaskType taskType = new TaskType
            {
                Id = taskTypeDTO.Id,
                Code = taskTypeDTO.Code,
                Name = taskTypeDTO.Name
            };
            return taskType;
        }
        #endregion

        //======================================================================================
        #region PERSON
        public static PersonDTO ToPersonDTO(Person person)
        {
            if (person == null) return null;
            PersonDTO personDTO = new PersonDTO
            {
                //Id = person.Id,
                Name = person.Name,
                UserId = person.UserId
            };
            return personDTO;
        }

        //------------------------
        public static Person ToPerson(PersonDTO personDTO)
        {
            if (personDTO == null) return null;
            Person person = new Person
            {
                //Id = personDTO.Id,
                Name = personDTO.Name,
                UserId = personDTO.UserId
            };
            return person;
        }
        #endregion

        //======================================================================================
        #region DOCUMENT
        public static DocumentDTO ToDocumentDTO(Document document)
        {
            if (document == null) return null;
            DocumentDTO documentDTO = new DocumentDTO
            {
                //Id = document.Id,
                Title = document.Title,
                DocumentId = document.DocumentId
            };
            return documentDTO;
        }
        public static List<DocumentDTO> ToDocumentDTO(List<Document> documents)
        {
            if (documents == null) return null;
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            foreach (var doc in documents)
            {
                documentDTOs.Add(ToDocumentDTO(doc));
            }
            return documentDTOs;
        }

        //------------------------
        public static Document ToDocument(DocumentDTO documentDTO)
        {
            if (documentDTO == null) return null;
            Document document = new Document
            {
                //Id = documentDTO.Id,
                Title = documentDTO.Title,
                DocumentId = documentDTO.DocumentId
            };
            return document;
        }
        public static List<Document> ToDocument(List<DocumentDTO> documentDTOs)
        {
            if (documentDTOs == null) return null;
            List<Document> documents = new List<Document>();
            foreach (var docDTO in documentDTOs)
            {
                documents.Add(ToDocument(docDTO));
            }
            return documents;
        }
        #endregion

        //======================================================================================
        #region INDOCUMENT
        public static InDocumentDTO ToInDocumentDTO(InDocument inDocument)
        {
            if (inDocument == null) return null;
            InDocumentDTO inDocumentDTO = new InDocumentDTO
            {
                Id = inDocument.Id,
                Name = inDocument.Name,
                Address = inDocument.Address,
                Email = inDocument.Email,
                DeliveryDate = inDocument.DeliveryDate,
                RegistrationDate = inDocument.RegistrationDate,
                RegistrPerson = ToPersonDTO(inDocument.RegistrPerson),
                MessageText = inDocument.MessageText,
                IncomingNumber = inDocument.IncomingNumber,
                ProductionTaskId = inDocument.ProductionTaskId,
                ProductionTask = ToProductionTaskDTO(inDocument.ProductionTask),
                Documents = ToDocumentDTO(inDocument.Documents)
            };
            return inDocumentDTO;
        }

        //------------------------
        public static InDocument ToInDocument(InDocumentDTO inDocumentDTO)
        {
            if (inDocumentDTO == null) return null;
            InDocument inDocument = new InDocument
            {
                Id = inDocumentDTO.Id,
                Name = inDocumentDTO.Name,
                Address = inDocumentDTO.Address,
                Email = inDocumentDTO.Email,
                DeliveryDate = inDocumentDTO.DeliveryDate,
                RegistrationDate = inDocumentDTO.RegistrationDate,
                RegistrPerson = ToPerson(inDocumentDTO.RegistrPerson),
                MessageText = inDocumentDTO.MessageText,
                IncomingNumber = inDocumentDTO.IncomingNumber,
                ProductionTaskId = inDocumentDTO.ProductionTaskId,
                //ProductionTask = ToProductionTask(inDocumentDTO.ProductionTask),
                Documents = ToDocument(inDocumentDTO.Documents)
            };
            return inDocument;
        }
        #endregion

        //======================================================================================
        #region OUTDOCUMENT
        public static OutDocumentDTO ToOutDocumentDTO(OutDocument outDocument)
        {
            if (outDocument == null) return null;
            OutDocumentDTO outDocumentDTO = new OutDocumentDTO
            {
                Id = outDocument.Id,
                Name = outDocument.Name,
                Address = outDocument.Address,
                Email = outDocument.Email,
                MessageText = outDocument.MessageText,
                ResponsePerson = ToPersonDTO(outDocument.ResponsePerson),
                DeliveryType = outDocument.DeliveryType,
                SentDocsDate = outDocument.SentDocsDate,
                OutgoingNumber = outDocument.OutgoingNumber,
                Executor = ToPersonDTO(outDocument.Executor),
                ExecutorNumber = outDocument.ExecutorNumber,
                State = outDocument.State,
                SendRespCommand = outDocument.SendRespCommand,
                SendRespCommandDate = outDocument.SendRespCommandDate,
                RespCommandPerson = ToPersonDTO(outDocument.RespCommandPerson),
                PlannsedRespDate = outDocument.PlannsedRespDate,
                ActualRespDate = outDocument.ActualRespDate,
                Notes = outDocument.Notes,
                ProductionTaskId = outDocument.ProductionTaskId,
                ProductionTask = ToProductionTaskDTO(outDocument.ProductionTask),
                Documents = ToDocumentDTO(outDocument.Documents)
            };
            return outDocumentDTO;
        }
        public static List<Guid> ToOutDocumentDTO(List<OutDocument> outDocuments)
        {
            if (outDocuments == null) return null;
            List<Guid> outDocumentDTOs = new List<Guid>();
            foreach (var doc in outDocuments)
            {
                outDocumentDTOs.Add(doc.Id);
            }
            return outDocumentDTOs;
        }

        //------------------------
        public static OutDocument ToOutDocument(OutDocumentDTO outDocumentDTO)
        {
            if (outDocumentDTO == null) return null;
            OutDocument outDocument = new OutDocument
            {
                Id = outDocumentDTO.Id,
                Name = outDocumentDTO.Name,
                Address = outDocumentDTO.Address,
                Email = outDocumentDTO.Email,
                MessageText = outDocumentDTO.MessageText,
                ResponsePerson = ToPerson(outDocumentDTO.ResponsePerson),
                DeliveryType = outDocumentDTO.DeliveryType,
                SentDocsDate = outDocumentDTO.SentDocsDate,
                OutgoingNumber = outDocumentDTO.OutgoingNumber,
                Executor = ToPerson(outDocumentDTO.Executor),
                ExecutorNumber = outDocumentDTO.ExecutorNumber,
                State = outDocumentDTO.State,
                SendRespCommand = outDocumentDTO.SendRespCommand,
                SendRespCommandDate = outDocumentDTO.SendRespCommandDate,
                RespCommandPerson = ToPerson(outDocumentDTO.RespCommandPerson),
                PlannsedRespDate = outDocumentDTO.PlannsedRespDate,
                ActualRespDate = outDocumentDTO.ActualRespDate,
                Notes = outDocumentDTO.Notes,
                ProductionTaskId = outDocumentDTO.ProductionTaskId,
                ProductionTask = ToProductionTask(outDocumentDTO.ProductionTask),
                Documents = ToDocument(outDocumentDTO.Documents)
            };
            return outDocument;
        }
        //public static List<OutDocument> ToOutDocument(List<Guid> DocumentGuids, Context context)
        //{
        //    if (DocumentGuids == null) return null;
        //    OutDocumentRepository repository = new OutDocumentRepository(context);
        //    List<OutDocument> outDocuments = new List<OutDocument>();
        //    foreach (var doc in DocumentGuids)
        //    {
        //        repository.
        //        outDocuments.Add();
        //    }
        //    return outDocuments;
        //}
        #endregion

        //======================================================================================
        #region PRODUCTINSUBTASK
        public static ProductionSubTaskDTO ToProductinSubTaskDTO(ProductionSubTask productinSubTask)
        {
            if (productinSubTask == null) return null;
            ProductionSubTaskDTO productinSubTaskDTO = new ProductionSubTaskDTO
            {
                Id = productinSubTask.Id,
                Comments = productinSubTask.Comments,
                ExecutorReport = productinSubTask.ExecutorReport,
                PlannedCompletionDate = productinSubTask.PlannedCompletionDate,
                ActualCompletionDate = productinSubTask.ActualCompletionDate,
                State = productinSubTask.State,
                Priority = productinSubTask.Priority,
                InitDate = productinSubTask.InitDate,
                Executor = ToPersonDTO(productinSubTask.Executor),
                ConfirmDate = productinSubTask.ConfirmDate,
                ReportFlag = productinSubTask.ReportFlag,
                TaskReadyFlag = productinSubTask.TaskReadyFlag,
                CancelFlag = productinSubTask.CancelFlag,
                CancelDate = productinSubTask.CancelDate,
                ProductionTask = ToProductionTaskDTO(productinSubTask.ProductionTask),
                UpperTask = ToProductinSubTaskDTO(productinSubTask.UpperTask),
                SubTasks = ToProductinSubTaskDTO(productinSubTask.SubTasks),
                ReportDocs = ToDocumentDTO(productinSubTask.ReportDocs)
            };
            return productinSubTaskDTO;
        }
        public static List<Guid> ToProductinSubTaskDTO(List<ProductionSubTask> productinSubTasks)
        {
            if (productinSubTasks == null) return null;
            List<Guid> productinSubTaskDTOs = new List<Guid>();
            foreach (var task in productinSubTasks)
            {
                productinSubTaskDTOs.Add(task.Id);
            }
            return productinSubTaskDTOs;
        }

        //------------------------
        public static ProductionSubTask ToProductinSubTask(ProductionSubTaskDTO productinSubTaskDTO)
        {
            if (productinSubTaskDTO == null) return null;
            ProductionSubTask productinSubTask = new ProductionSubTask
            {
                Id = productinSubTaskDTO.Id,
                Comments = productinSubTaskDTO.Comments,
                ExecutorReport = productinSubTaskDTO.ExecutorReport,
                PlannedCompletionDate = productinSubTaskDTO.PlannedCompletionDate,
                ActualCompletionDate = productinSubTaskDTO.ActualCompletionDate,
                State = productinSubTaskDTO.State,
                Priority = productinSubTaskDTO.Priority,
                InitDate = productinSubTaskDTO.InitDate,
                Executor = ToPerson(productinSubTaskDTO.Executor),
                ConfirmDate = productinSubTaskDTO.ConfirmDate,
                ReportFlag = productinSubTaskDTO.ReportFlag,
                TaskReadyFlag = productinSubTaskDTO.TaskReadyFlag,
                CancelFlag = productinSubTaskDTO.CancelFlag,
                CancelDate = productinSubTaskDTO.CancelDate,
                ProductionTask = ToProductionTask(productinSubTaskDTO.ProductionTask),
                UpperTask = ToProductinSubTask(productinSubTaskDTO.UpperTask),
                //SubTasks = ToProductinSubTask(productinSubTaskDTO.SubTasks),
                ReportDocs = ToDocument(productinSubTaskDTO.ReportDocs)
            };
            return productinSubTask;
        }
        //public static List<ProductinSubTask> ToProductinSubTask(List<Guid> productinSubTaskGuids)
        //{
        //    if (productinSubTaskGuids == null) return null;
        //    List<Guid> productinSubTasks = new List<Guid>();
        //    foreach (var task in productinSubTaskGuids)
        //    {
        //        productinSubTasks.Add();
        //    }
        //    return productinSubTasks;
        //}
        #endregion

    }
}
