using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HelloWorldModels;
using HelloWorldInfrastructure;
using System.Linq;
using Microsoft.Extensions.Options;

namespace FileAccess
{
    public class HelloWorldFile : IRepositoryKey<HelloWorldMessage, string>, IDisposable
    {
        private List<HelloWorldMessage> _messages = new List<HelloWorldMessage>();
        private bool disposed;

        public HelloWorldFile(IOptions<FileOptions> fileSettings)
        {
            var fileName = fileSettings.Value.FileName;
            string[] header = null;
            bool firstLine = true;
            
            foreach (var record in CSVFileParser.ReadDelimitedFile(fileName))
            {
                if (firstLine)
                {
                    header = record;
                    firstLine = false;
                }
                else
                {
                    var message = record.ParseLine<HelloWorldMessage>(header);
                    _messages.Add(message);
                }
            }
        }

        public void AddNew(HelloWorldMessage item)
        {
            throw new NotImplementedException();
        }

        public void Delete(HelloWorldMessage item)
        {
            throw new NotImplementedException();
        }

        public void DeleteByKey(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<HelloWorldMessage> GetAll()
        {
            return _messages.AsQueryable();
        }

        public IQueryable<HelloWorldMessage> GetItem(string id)
        {
            return _messages.Where(m => m.Id == id).AsQueryable();
        }

        public void Update(HelloWorldMessage item)
        {
            throw new NotImplementedException();
        }
 
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    _messages = null;
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
