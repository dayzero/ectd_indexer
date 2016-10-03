//eCTD indexer (EU Module 1)
//Copyright 2007-2013 Ymir Vesteinsson, ymir@ectd.is

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
using System.Xml;
using System.IO;

namespace eCTD_indexer
{
    public class Sort
    {
        public void m2m5sort(string xmlFile)
        {            
            XmlTextReader myReader = new XmlTextReader(xmlFile);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            //order elements in 2.3
            //put introduction first
            XmlNodeList m23introduction;
            m23introduction = mySourceDoc.SelectNodes("//m2-3-introduction");
            if (m23introduction.Count > 0)
            {
                foreach (XmlNode intro in m23introduction)
                {
                    while (intro != intro.ParentNode.FirstChild)
                    {
                        XmlNode parent = intro.ParentNode;
                        XmlNode previousSibling = intro.PreviousSibling;
                        parent.RemoveChild(intro);
                        parent.InsertBefore(intro, previousSibling);
                    }
                }
            }
            //...then substance
            XmlNodeList m23substance;
            m23substance = mySourceDoc.SelectNodes("//m2-3-s-drug-substance");
            if (m23substance.Count > 0)
            {
                foreach (XmlNode substance in m23substance)
                {
                    while ((substance != substance.ParentNode.FirstChild) && (substance.PreviousSibling.Name != "m2-3-introduction"))
                    {
                        XmlNode parent = substance.ParentNode;
                        XmlNode previousSibling = substance.PreviousSibling;
                        parent.RemoveChild(substance);
                        parent.InsertBefore(substance, previousSibling);
                    }
                }
            }

            //...then product
            XmlNodeList m23product;
            m23product = mySourceDoc.SelectNodes("//m2-3-p-drug-product");
            if (m23product.Count > 0)
            {
                foreach (XmlNode product in m23product)
                {
                    while ((product != product.ParentNode.FirstChild) && (product.PreviousSibling.Name != "m2-3-introduction") && (product.PreviousSibling.Name != "m2-3-s-drug-substance"))
                    {
                        XmlNode parent = product.ParentNode;
                        XmlNode previousSibling = product.PreviousSibling;
                        parent.RemoveChild(product);
                        parent.InsertBefore(product, previousSibling);
                    }
                }
            }

            //order elements in 2.6
            XmlNodeList m262;
            m262 = mySourceDoc.SelectNodes("//m2-6-2-pharmacology-written-summary");
            if (m262.Count > 0)
            {
                foreach (XmlNode m262pws in m262)
                {
                    while ((m262pws != m262pws.ParentNode.FirstChild) && (m262pws.PreviousSibling.Name != "m2-6-1-introduction"))
                    {
                        XmlNode parent = m262pws.ParentNode;
                        XmlNode previousSibling = m262pws.PreviousSibling;
                        parent.RemoveChild(m262pws);
                        parent.InsertBefore(m262pws, previousSibling);
                    }
                }
            }
            XmlNodeList m264;
            m264 = mySourceDoc.SelectNodes("//m2-6-4-pharmacokinetics-written-summary");
            if (m264.Count > 0)
            {
                foreach (XmlNode m264pws in m264)
                {
                    while ((m264pws != m264pws.ParentNode.FirstChild) && (m264pws.PreviousSibling.Name != "m2-6-1-introduction") 
                        && (m264pws.PreviousSibling.Name != "m2-6-2-pharmacology-written-summary") 
                        && (m264pws.PreviousSibling.Name != "m2-6-3-pharmacology-tabulated-summary"))
                    {
                        XmlNode parent = m264pws.ParentNode;
                        XmlNode previousSibling = m264pws.PreviousSibling;
                        parent.RemoveChild(m264pws);
                        parent.InsertBefore(m264pws, previousSibling);
                    }
                }
            }
            XmlNodeList m266;
            m266 = mySourceDoc.SelectNodes("//m2-6-6-toxicology-written-summary");
            if (m264.Count > 0)
            {
                foreach (XmlNode m266tws in m266)
                {
                    while ((m266tws != m266tws.ParentNode.FirstChild) && (m266tws.PreviousSibling.Name != "m2-6-1-introduction") 
                        && (m266tws.PreviousSibling.Name != "m2-6-2-pharmacology-written-summary") 
                        && (m266tws.PreviousSibling.Name != "m2-6-3-pharmacology-tabulated-summary")
                        && (m266tws.PreviousSibling.Name != "m2-6-4-pharmacokinetics-written-summary")
                        && (m266tws.PreviousSibling.Name != "m2-6-5-pharmacokinetics-tabulated-summary"))
                    {
                        XmlNode parent = m266tws.ParentNode;
                        XmlNode previousSibling = m266tws.PreviousSibling;
                        parent.RemoveChild(m266tws);
                        parent.InsertBefore(m266tws, previousSibling);
                    }
                }
            }

            //order elements in 2.7
            XmlNodeList m271;
            m271 = mySourceDoc.SelectNodes("//m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods");
            if (m271.Count > 0)
            {
                foreach (XmlNode m271sbs in m271)
                {
                    while (m271sbs != m271sbs.ParentNode.FirstChild)
                    {
                        XmlNode parent = m271sbs.ParentNode;
                        XmlNode previousSibling = m271sbs.PreviousSibling;
                        parent.RemoveChild(m271sbs);
                        parent.InsertBefore(m271sbs, previousSibling);
                    }
                }
            }
            XmlNodeList m272;
            m272 = mySourceDoc.SelectNodes("//m2-7-2-summary-of-clinical-pharmacology-studies");
            if (m272.Count > 0)
            {
                foreach (XmlNode m272scps in m272)
                {
                    while ((m272scps != m272scps.ParentNode.FirstChild)
                        && m272scps.PreviousSibling.Name != "m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods")
                    {
                        XmlNode parent = m272scps.ParentNode;
                        XmlNode previousSibling = m272scps.PreviousSibling;
                        parent.RemoveChild(m272scps);
                        parent.InsertBefore(m272scps, previousSibling);
                    }
                }
            }
            XmlNodeList m273;
            m273 = mySourceDoc.SelectNodes("//m2-7-3-summary-of-clinical-efficacy");
            if (m273.Count > 0)
            {
                foreach (XmlNode m273sce in m273)
                {
                    while ((m273sce != m273sce.ParentNode.FirstChild)
                        && m273sce.PreviousSibling.Name != "m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods"
                        && m273sce.PreviousSibling.Name != "m2-7-2-summary-of-clinical-pharmacology-studies")
                    {
                        XmlNode parent = m273sce.ParentNode;
                        XmlNode previousSibling = m273sce.PreviousSibling;
                        parent.RemoveChild(m273sce);
                        parent.InsertBefore(m273sce, previousSibling);
                    }
                }
            }
            XmlNodeList m274;
            m274 = mySourceDoc.SelectNodes("//m2-7-4-summary-of-clinical-safety");
            if (m274.Count > 0)
            {
                foreach (XmlNode m274scs in m274)
                {
                    while ((m274scs != m274scs.ParentNode.FirstChild)
                        && m274scs.PreviousSibling.Name != "m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods"
                        && m274scs.PreviousSibling.Name != "m2-7-2-summary-of-clinical-pharmacology-studies"
                        && m274scs.PreviousSibling.Name != "m2-7-3-summary-of-clinical-efficacy")
                    {
                        XmlNode parent = m274scs.ParentNode;
                        XmlNode previousSibling = m274scs.PreviousSibling;
                        parent.RemoveChild(m274scs);
                        parent.InsertBefore(m274scs, previousSibling);
                    }
                }
            }

            //put drug substance nodes first in module 3.2
            XmlNodeList m32substances;
            m32substances = mySourceDoc.SelectNodes("//m3-2-s-drug-substance");
            if (m32substances.Count > 0)
            {
                foreach (XmlNode substance in m32substances)
                {
                    while (substance != substance.ParentNode.FirstChild)
                    {
                        XmlNode parent = substance.ParentNode;
                        XmlNode previousSibling = substance.PreviousSibling;
                        parent.RemoveChild(substance);
                        parent.InsertBefore(substance, previousSibling);
                    }
                }
            }

            //place 3.2.S.1.3 last under 3.2.S.1
            XmlNodeList m32s13;
            m32s13 = mySourceDoc.SelectNodes("//m3-2-s-1-3-general-properties ");
            if (m32s13.Count > 0)
            {
                foreach (XmlNode genProp in m32s13)
                {
                    XmlNode parent = genProp.ParentNode;
                    parent.RemoveChild(genProp);
                    parent.InsertAfter(genProp, parent.LastChild);
                }
            }

            //order elements in 3.2.S.2
            XmlNodeList m32s2;
            m32s2 = mySourceDoc.SelectNodes("//m3-2-s-2-manufacture");
            if (m32s2.Count > 0)
            {
                for (int j = 0; j < m32s2.Count; j++)
                {
                    if (m32s2[j].ChildNodes.Count > 0)
                    {
                        int length = m32s2[j].ChildNodes.Count;
                        string[] nodeNames = new string[length];
                        int i = 0;
                        foreach (XmlNode child in m32s2[j].ChildNodes)
                        {
                            nodeNames[i] = child.Name;
                            i++;
                        }
                        Array.Sort(nodeNames);

                        for (i = 0; i < length; i++)
                        {
                            foreach (XmlNode nextnodein in m32s2[j])
                            {
                                if (nextnodein.Name == nodeNames[i])
                                {
                                    m32s2[j].InsertAfter(nextnodein, m32s2[j].LastChild);
                                }
                            }
                        }
                    }
                }
            }

            //order elements in 3.2.S.7
            XmlNodeList m32s7;
            m32s7 = mySourceDoc.SelectNodes("//m3-2-s-7-stability");
            if (m32s7.Count > 0)
            {
                for (int j = 0; j < m32s7.Count; j++)
                {
                    if (m32s7[j].ChildNodes.Count > 0)
                    {
                        int length = m32s7[j].ChildNodes.Count;
                        string[] nodeNames = new string[length];
                        int i = 0;
                        foreach (XmlNode child in m32s7[j].ChildNodes)
                        {
                            nodeNames[i] = child.Name;
                            i++;
                        }
                        Array.Sort(nodeNames);

                        for (i = 0; i < length; i++)
                        {
                            foreach (XmlNode nextnodein in m32s7[j])
                            {
                                if (nextnodein.Name == nodeNames[i])
                                {
                                    m32s7[j].InsertAfter(nextnodein, m32s7[j].LastChild);
                                }
                            }
                        }
                    }
                }
            }

            //order elements in 3.2.P.3
            XmlNodeList m32p3;
            m32p3 = mySourceDoc.SelectNodes("//m3-2-p-3-manufacture");
            if (m32p3.Count > 0)
            {
                for (int j = 0; j < m32p3.Count; j++)
                {
                    if (m32p3[j].ChildNodes.Count > 0)
                    {
                        int length = m32p3[j].ChildNodes.Count;
                        string[] nodeNames = new string[length];
                        int i = 0;
                        foreach (XmlNode child in m32p3[j].ChildNodes)
                        {
                            nodeNames[i] = child.Name;
                            i++;
                        }
                        Array.Sort(nodeNames);

                        for (i = 0; i < length; i++)
                        {
                            foreach (XmlNode nextnodein in m32p3[j])
                            {
                                if (nextnodein.Name == nodeNames[i])
                                {
                                    m32p3[j].InsertAfter(nextnodein, m32p3[j].LastChild);
                                }
                            }
                        }
                    }
                }
            }

            //order elements in 3.2.P.4
            XmlNodeList m32p4;
            m32p4 = mySourceDoc.SelectNodes("//m3-2-p-4-control-of-excipients");
            if (m32p4.Count > 0)
            {
                for (int j = 0; j < m32p4.Count; j++)
                {
                    if (m32p4[j].ChildNodes.Count > 0)
                    {
                        int length = m32p4[j].ChildNodes.Count;
                        string[] nodeNames = new string[length];
                        int i = 0;
                        foreach (XmlNode child in m32p4[j].ChildNodes)
                        {
                            nodeNames[i] = child.Name;
                            i++;
                        }
                        Array.Sort(nodeNames);

                        for (i = 0; i < length; i++)
                        {
                            foreach (XmlNode nextnodein in m32p4[j])
                            {
                                if (nextnodein.Name == nodeNames[i])
                                {
                                    m32p4[j].InsertAfter(nextnodein, m32p4[j].LastChild);
                                }
                            }
                        }
                    }
                }
            }

            //order elements in 3.2.P.8
            XmlNodeList m32p8;
            m32p8 = mySourceDoc.SelectNodes("//m3-2-p-8-stability");
            if (m32p8.Count > 0)
            {
                for (int j = 0; j < m32p8.Count; j++)
                {
                    if (m32p8[j].ChildNodes.Count > 0)
                    {
                        int length = m32p8[j].ChildNodes.Count;
                        string[] nodeNames = new string[length];
                        int i = 0;
                        foreach (XmlNode child in m32p8[j].ChildNodes)
                        {
                            nodeNames[i] = child.Name;
                            i++;
                        }
                        Array.Sort(nodeNames);

                        for (i = 0; i < length; i++)
                        {
                            foreach (XmlNode nextnodein in m32p8[j])
                            {
                                if (nextnodein.Name == nodeNames[i])
                                {
                                    m32p8[j].InsertAfter(nextnodein, m32p8[j].LastChild);
                                }
                            }
                        }
                    }
                }
            }

            //let drug product follow drug substance nodes in module 3.2
            XmlNodeList m32products;
            m32products = mySourceDoc.SelectNodes("//m3-2-p-drug-product");
            if (m32products.Count > 0)
            {
                foreach (XmlNode product in m32products)
                {
                    while ((product != product.ParentNode.FirstChild) && (product.PreviousSibling.Name != "m3-2-s-drug-substance"))
                    {
                        XmlNode parent = product.ParentNode;
                        XmlNode previousSibling = product.PreviousSibling;
                        parent.RemoveChild(product);
                        parent.InsertBefore(product, previousSibling);
                    }
                }
            }

            // Write the XML file
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(xmlFile, settings);
            mySourceDoc.Save(writer);
            writer.Close();
        }
		
		public void m1sort(string xmlFile)
        {            
            XmlTextReader myReader = new XmlTextReader(xmlFile);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            //put Module 1.10 in the right place (appears between 1.1 and 1.2 after indexing)            
            XmlNodeList m1paediatrics;
            m1paediatrics = mySourceDoc.SelectNodes("//m1-10-paediatrics");
            if (m1paediatrics.Count > 0)
            {
                foreach (XmlNode paediatrics in m1paediatrics)
                {
                    while ((paediatrics != paediatrics.ParentNode.LastChild) && (paediatrics.NextSibling.Name != ("m1-responses") || (paediatrics.NextSibling.Name != "m1-additional-data")))
                    {
                        XmlNode parent = paediatrics.ParentNode;
                        XmlNode nextSibling = paediatrics.NextSibling;
                        parent.RemoveChild(paediatrics);
                        parent.InsertAfter(paediatrics, nextSibling);
                    }
                }
            }
			//move additional data nodes last (appears before responses after indexing)
			XmlNodeList m1additional;
			m1additional = mySourceDoc.SelectNodes("//m1-additional-data");
			if (m1additional.Count > 0) 
			{
				foreach (XmlNode additional in m1additional) 
				{
					while (additional != additional.ParentNode.LastChild) 
					{
						XmlNode parent = additional.ParentNode;
						XmlNode nextSibling = additional.NextSibling;
						parent.RemoveChild (additional);
						parent.InsertAfter (additional, nextSibling);
					}
				}
			}

            XmlTextWriter writer = new XmlTextWriter(xmlFile, null);
            writer.Formatting = Formatting.Indented;
            mySourceDoc.Save(writer);
            writer.Close();
        }
		
        public string modifiedFile(string seqIndexPath, string leafFilePath)
        {
            string leafID = "";
            if (File.Exists(seqIndexPath))
            {
                XmlTextReader myNewReader = new XmlTextReader(seqIndexPath);
                XmlDocument myNewSourceDoc = new XmlDocument();
                myNewSourceDoc.Load(myNewReader);
                myNewReader.Close();

                leafID = "";                

                XmlNodeList prevSequenceLeaves = myNewSourceDoc.SelectNodes("//leaf");
                foreach (XmlNode leaf in prevSequenceLeaves)
                {
                    if (leaf.Attributes["xlink:href"].Value == leafFilePath)
                    {
                        leafID = leaf.Attributes["ID"].Value;
                    }
                }
            }
            else
            {
                MessageBox.Show(seqIndexPath, "Error! File not found:");                
            }
            return leafID;
        }

    }
}
