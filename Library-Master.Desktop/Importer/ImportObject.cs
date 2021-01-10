using System;
using System.Collections.Generic;
using Library_Master.Desktop.Entities;
using Library_Master.Desktop.Exceptions;

namespace Library_Master.Desktop.Importer
{
    public class ImportObject
    {
        private string[] list;
        private ImportOptions[] options;
        
        /// <summary>
        /// Default Import Object
        /// </summary>
        public ImportObject(params string[] args)
        {
            list = args;
        }

        /// <summary>
        /// Options for import in that order you init that object
        /// </summary>
        /// <param name="args"></param>
        public void SetOptions(params ImportOptions[] args)
        {
            options = args;
        }
        
        /// <summary>
        /// Return a list of ImportingObject's 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ToManyOptionsGivenException"></exception>
        public List<ImportingObject> ReturnImportObject()
        {
            List<ImportingObject> outputList = new List<ImportingObject>();
            if (list.Length != options.Length)
            {
                throw new ToManyOptionsGivenException();
            }
            else
            {
                for (int i = 0; i < list.Length; i++)
                {
                    outputList.Add(new ImportingObject(list[i], options[i]));
                }
            }
            
            return outputList;
        }
    }

    public class ImportingObject
    {
        public string Variable { get; }
        public ImportOptions Options { get; }

        public ImportingObject(string variable, ImportOptions options)
        {
            Variable = variable;
            Options = options;
        }
    }
}