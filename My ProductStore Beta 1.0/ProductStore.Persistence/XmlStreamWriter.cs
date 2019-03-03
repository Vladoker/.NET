using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProductStore.Persistence
{
    /// <summary>
	/// Base class for XML writers.
	/// </summary>
	public class XmlStreamWriter : IDisposable
    {
        private string xmlNamespace = string.Empty;
        private string StreamPatch;
        private XmlWriter xmlWriter;
        private Stream xmlStream;

        public XmlStreamWriter()
        { }

        public XmlStreamWriter(string filePatch)
        {
            StreamPatch = filePatch;
        }

        /// <summary>
        /// Begins the writing.
        /// </summary>
        public void Begin(string rootElementName)
        {
            xmlStream = System.IO.File.Create(StreamPatch);
            XmlWriterSettings writerSettings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
            xmlWriter = XmlWriter.Create(xmlStream, writerSettings);
            xmlWriter.WriteStartElement(rootElementName, xmlNamespace);
        }

        /// <summary>
        /// Writes the passed data element.
        /// </summary>
        /// <param name="productXml">The data element to be written.</param>
        public void WriteElement(ProductXml productXml)
        {
            Serialize(productXml);
        }

        /// <summary>
        /// Finishs the writing.
        /// </summary>
        public void Finish()
        {
            xmlWriter.WriteEndElement();          
            xmlWriter.Close();
            xmlStream.Close();
        }

        /// <summary>
        /// Releases all resources used by the current instance class.
        /// </summary>
        public void Dispose()
        {
            xmlWriter.Dispose();
            xmlStream.Dispose();
        }

        protected void Serialize(ProductXml productXml)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(productXml.GetType());
            xmlSerializer.Serialize(xmlWriter, productXml, xmlSerializerNamespaces);
        }
    }

}
