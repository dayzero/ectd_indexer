//eCTD indexer (EU Module 1)
//Copyright 2007-2011 Ymir Vesteinsson, ymir@ectd.is

//This file is part of eCTD-indexer.

//eCTD-indexer is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//eCTD-indexer is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with eCTD-indexer.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;


namespace eCTD_indexer
{
    class CurrentDossier
    {
        public void AssembleCurrentDossier(string topSequenceFolder)
        {
            string currentXmlIndexOutput = topSequenceFolder + Path.DirectorySeparatorChar + "current-index.xml";
			XmlDocument emptyXmlDoc = new XmlDocument();
			XmlTextWriter emptyXmlDocWriter = new XmlTextWriter(currentXmlIndexOutput, null);
            emptyXmlDocWriter.Formatting = Formatting.Indented;
			emptyXmlDocWriter.WriteStartElement("ectd");
			emptyXmlDocWriter.WriteEndElement();
			emptyXmlDoc.Save(emptyXmlDocWriter);
			emptyXmlDocWriter.Close();

                //get sequence directories
                try
                {
                    string[] dirs = Directory.GetDirectories(topSequenceFolder);
                    foreach (string dir in dirs)
                    {
                        string sequence = dir.Substring(dir.Length - 4, 4);
                        string sequenceIndex = (dir + Path.DirectorySeparatorChar + "index.xml");

                        //read index.xml from each sequence, add to consolidated current-index.xml
                        //alter xlink:href to add sequence folder
                        //make ID attribute = modified-file path to simplify replace and delete operations

//                        if (File.Exists(sequenceIndex) && sequence == "0000")
//                        {
//						
////						File.Copy(sequenceIndex,currentXmlIndexOutput);
//						
//                        XmlTextReader myReader = new XmlTextReader(currentXmlIndexOutput);
//                        XmlDocument mySourceDoc = new XmlDocument();
//                        mySourceDoc.Load(myReader);
//                        myReader.Close();
//
//                        System.Xml.XmlNodeList leafItems;
//                        leafItems = mySourceDoc.SelectNodes("//leaf");
//
//                        	foreach (System.Xml.XmlNode leafItem in leafItems)
//                        	{
//									string leafXlink = leafItem.Attributes["xlink:href"].InnerText;
//                            		leafXlink = leafXlink.Replace("\\", "/"); //fixes error when assembling from older (with backslashes in xlinks, made with previous versions of eCTD indexer) and newer (with forward slashes in xlinks) sequences
//                            		leafXlink = sequence + "/" + leafXlink;
//                            		leafItem.Attributes["xlink:href"].InnerText = leafXlink;
//
//                            		string alterId = leafItem.Attributes["ID"].InnerText;
//                            		alterId = "../" + sequence + "/index.xml#" + alterId;
//                            		leafItem.Attributes["ID"].InnerText = alterId;
//                        	}							
//							XmlTextWriter writer = new XmlTextWriter(currentXmlIndexOutput, null);
//				            writer.Formatting = Formatting.Indented;
//				            mySourceDoc.Save(writer); 
//						}
//					
//						if (File.Exists(sequenceIndex) && sequence != "0000" && File.Exists(currentXmlIndexOutput))
						if (File.Exists(sequenceIndex))
                        {

                        XmlTextReader mySequenceReader = new XmlTextReader(sequenceIndex);
                        XmlDocument sequenceSourceDoc = new XmlDocument();
                        sequenceSourceDoc.Load(mySequenceReader);
                        mySequenceReader.Close();
						
						System.Xml.XmlNodeList leafItems;
                        leafItems = sequenceSourceDoc.SelectNodes("//leaf");
						
						XmlTextReader currentDossierReader = new XmlTextReader(currentXmlIndexOutput);
						XmlDocument currentSourceDoc = new XmlDocument();
						currentSourceDoc.Load(currentDossierReader);
						currentDossierReader.Close();

						System.Xml.XmlNodeList currentIndexLeaves;
						currentIndexLeaves = currentSourceDoc.SelectNodes("//leaf");

                        	foreach (System.Xml.XmlNode leafItem in leafItems)
                        	{
								string leafXlink = leafItem.Attributes["xlink:href"].InnerText;
                        		leafXlink = leafXlink.Replace("\\", "/"); //fixes error when assembling from older (with backslashes in xlinks, made with previous versions of eCTD indexer) and newer (with forward slashes in xlinks) sequences
                        		leafXlink = sequence + "/" + leafXlink;
                        		leafItem.Attributes["xlink:href"].InnerText = leafXlink;

                        		string alterId = leafItem.Attributes["ID"].InnerText;
                        		alterId = "../" + sequence + "/index.xml#" + alterId;
                        		leafItem.Attributes["ID"].InnerText = alterId;
								if (leafItem.Attributes["operation"].InnerText =="new")
								{
									XmlNode newLeaf = currentSourceDoc.ImportNode(leafItem, true);
									currentSourceDoc["ectd"].AppendChild(newLeaf);									
								}
						
								if(leafItem.Attributes["operation"].InnerText == "delete")
								{
									foreach (System.Xml.XmlNode currentIndexleaf in currentIndexLeaves)
									{
										if (leafItem.Attributes["modified-file"].InnerText == currentIndexleaf.Attributes["ID"].InnerText)
										{
											currentSourceDoc["ectd"].RemoveChild(currentIndexleaf);										
										}
									}
								}
														
								if(leafItem.Attributes["operation"].InnerText == "replace")
								{
									foreach (System.Xml.XmlNode currentIndexleaf in currentIndexLeaves)
									{
										if (leafItem.Attributes["modified-file"].InnerText == currentIndexleaf.Attributes["ID"].InnerText)
										{
											XmlNode replacingLeaf = currentSourceDoc.ImportNode(leafItem, true);
											currentSourceDoc["ectd"].InsertAfter(replacingLeaf,currentIndexleaf);
											currentSourceDoc["ectd"].RemoveChild(currentIndexleaf);											
										}
									}
								}

//                            	string result = leafItem.OuterXml;
//                            	writer.WriteRaw(result);
//								}
                        	}
							XmlTextWriter writer = new XmlTextWriter(currentXmlIndexOutput, null);
				            writer.Formatting = Formatting.Indented;
				            currentSourceDoc.Save(writer);  
							writer.Close();
						}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Failed to read the sequence index.xml files");
                }
                


            }

//            //Load current-index.xml
//            System.IO.StreamReader sr = new System.IO.StreamReader(currentXmlIndexOutput);
//            System.Xml.XmlTextReader xr = new System.Xml.XmlTextReader(sr);
//
//            System.Xml.XmlDocument eCTDDocument = new System.Xml.XmlDocument();
//
//            eCTDDocument.Load(xr);
//
//            XmlNamespaceManager nsmgr = new XmlNamespaceManager(eCTDDocument.NameTable);
//            nsmgr.AddNamespace("currIndex", "http://ectd.is");
//            XmlNodeList nodelist = eCTDDocument.SelectNodes("//currIndex:leaf", nsmgr);
//
//            //count delete/replace operations
//            int delReplCounter = 0;
//            foreach (System.Xml.XmlNode eCTDItem in nodelist)
//            {
//                if (eCTDItem.Attributes["operation"].InnerText == "replace" || eCTDItem.Attributes["operation"].InnerText == "delete")
//                {
//                    delReplCounter++;                    
//                }
//            }
//
//            //create string array, load modified-file attribute values of delete/replace leaves
//            string[] delReplArray = new string[delReplCounter];
//            int i = 0;
//            foreach (System.Xml.XmlNode eCTDItem in nodelist)
//            {
//                if (eCTDItem.Attributes["operation"].InnerText == "replace" || eCTDItem.Attributes["operation"].InnerText == "delete")
//                {
//                    delReplArray[i] = eCTDItem.Attributes["modified-file"].InnerText;
//                    i++;
//                }
//            }
//
//            //create html file output with information on leaf elements that have not been replaced or deleted
//            using (StreamWriter htmlStream = new StreamWriter(topSequenceFolder + Path.DirectorySeparatorChar + "currentDossier.html"))
//            {
//                htmlStream.WriteLine("<html><head><title>Current Dossier</title></head><body><table>");                
//                foreach (System.Xml.XmlNode eCTDItem in nodelist)
//                {
//                    foreach (string modfile in delReplArray)
//                    {
//                        if (eCTDItem.Attributes["ID"].InnerText != modfile)
//                        {
//                            string xlink = eCTDItem.Attributes["xlink:href"].InnerText;                            
//                            string title = eCTDItem.FirstChild.InnerText;
//                            htmlStream.WriteLine("<tr><td>{0}</td><td><a href=\"{1}\">{1}</a></td></tr>", title, xlink);
//                        }
//                    }
//                }
//                htmlStream.WriteLine("</table></body></html>");
//            }
//
//            xr.Close();

            //delete all-leaf-nodes-index.xml            
            //File.Delete(currentXmlIndexOutput);
//        }
    }
}
