using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace DicomStorage.WindowsService
{
    public abstract class QueueService: BackgroundService
    {
        protected readonly ConcurrentQueue<QueueItem>  Queue = new ConcurrentQueue<QueueItem>();

        public void Enqueue(QueueItem item)
        {
            Queue.Enqueue(item);
        }

        public override void Start()
        {
            base.Start();
            LoadFromFile();
        }

        public override void Stop()
        {
            base.Stop();
            SaveToFile(getStorageFileName());
        }

        protected override void workAction()
        {
            while (!CancellationPending)
            {
                while (!Queue.IsEmpty && !CancellationPending)
                {
                    try
                    {
                        QueueItem item;
                        if (Queue.TryDequeue(out item))
                        {
                            processItem(item);
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
                Thread.Sleep(100);
            }
        }

        protected abstract void processItem(QueueItem queueItem);

        protected abstract string getStorageFileName();

        public void SaveToFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var uncompleatedItems = Queue.ToList();
                var serializer = new XmlSerializer(uncompleatedItems.GetType());
                using (var writer = new XmlTextWriter(fileName, Encoding.Default))
                    serializer.Serialize(writer, uncompleatedItems);
            }
        }

        public void LoadFromFile(string fileName = "")
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = getStorageFileName();
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                var uncompleatedItems = new List<QueueItem>();
                var serializer = new XmlSerializer(uncompleatedItems.GetType());
                using (var reader = new XmlTextReader(fileName))
                    uncompleatedItems = (List<QueueItem>) serializer.Deserialize(reader);
                uncompleatedItems.ForEach(x => Queue.Enqueue(x));
            }
        }

    }

    [Serializable]
    public class QueueItem
    {
        public string FileName { get; set; }
        public ServerOptions Options { get; set; }

        public string ApplyCodepage(string source)
        {
            return Options.ApplyCodepage(source);
        }
    }
}