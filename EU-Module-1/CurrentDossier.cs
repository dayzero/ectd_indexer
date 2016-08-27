//eCTD indexer (EU Module 1)
//Copyright 2007-2016 Ymir Vesteinsson, ymir@ectd.is

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


namespace WindowsApplication1
{
    class CurrentDossier
    {
        public void AssembleCurrentDossier(string topSequenceFolder)
		{
			System.Xml.XmlNodeList leafElements;
			List<List<string>> leafList = new List<List<string>> ();
			int someNumber;
			try {
				string[] dirs = Directory.GetDirectories (topSequenceFolder);
				Array.Sort (dirs);
				foreach (string dir in dirs) {	
					string sequence = dir.Substring (dir.Length - 4, 4);
					if (Int32.TryParse (sequence, out someNumber)) {
						string euregionalPath = dir + Path.DirectorySeparatorChar + "m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "eu-regional.xml";
						if (File.Exists (euregionalPath)) {
							leafElements = leafCollection(euregionalPath);
							foreach (System.Xml.XmlNode leaf in leafElements){
								if (leaf.Attributes["operation"].InnerText == "replace"){
									foreach (List<string> subList in leafList){
										if (subList[3] == leaf.Attributes["modified-file"].InnerText){											
											subList[4] ="replaced in " + sequence;
										}
									}
								}
								if (leaf.Attributes["operation"].InnerText == "delete"){
									foreach (List<string> subList in leafList){
										if (subList[3] == leaf.Attributes["modified-file"].InnerText){											
											subList[4] ="deleted in " + sequence;
										}
									}
								}
								//add the sequence number, the relative path to the file, the element title and the string to match the "modified-file" attribute of any leaf replacing or deleting this one
								if (leaf.Attributes["operation"].InnerText != "delete"){
									leafList.Add(new List<string>{sequence, sequence + "/m1/eu/" + leaf.Attributes["xlink:href"].InnerText, leaf.FirstChild.InnerText, "../../../" + sequence + "/m1/eu/eu-regional.xml#" + leaf.Attributes["ID"].InnerText, "valid"});
								}
							}
						} 
						else {
							MessageBox.Show ("No eu-regional.xml file in sequence " + sequence);
						}
						string indexPath = dir + Path.DirectorySeparatorChar + "index.xml";
						if (File.Exists (indexPath)) {
							leafElements = leafCollection(indexPath);
							foreach (System.Xml.XmlNode leaf in leafElements){
								if (leaf.Attributes["operation"].InnerText == "replace"){
									foreach (List<string> subList in leafList){
										if (subList[3] == leaf.Attributes["modified-file"].InnerText){											
											subList[4] ="replaced in " + sequence;
										}
									}
								}
								if (leaf.Attributes["operation"].InnerText == "delete"){
									foreach (List<string> subList in leafList){
										if (subList[3] == leaf.Attributes["modified-file"].InnerText){											
											subList[4] ="deleted in " + sequence;
										}
									}
								}
								//add the sequence number, the relative path to the file, the element title and the string to match the "modified-file" attribute of any leaf replacing or deleting this one
								if ((leaf.Attributes["operation"].InnerText != "delete") && (leaf.Attributes["xlink:href"].InnerText != "m1/eu/eu-regional.xml")){
									leafList.Add(new List<string>{sequence, sequence + "/" + leaf.Attributes["xlink:href"].InnerText, leaf.FirstChild.InnerText, "../" + sequence + "/index.xml#" + leaf.Attributes["ID"].InnerText, "valid"});
								}
							}
						} 
						else {
							MessageBox.Show ("No index.xml file in sequence " + sequence);
						}
					}
				}
				int validFileCount = 0;
				StreamWriter sr = File.CreateText (topSequenceFolder + Path.DirectorySeparatorChar + "current_dossier" + ".html");
				sr.WriteLine ("<html><title>Current dossier and file history</title><body>");
				sr.WriteLine ("<table border=\"1\">");
				sr.WriteLine ("<tr><td>Sequence</td><td>Element title</td><td>reference to this file</td><td>status</td>");
				foreach (List<string> subList in leafList){					
					sr.WriteLine("<tr>");
					sr.Write("<td>" + subList[0] + "</td>" + "<td><a href=\"" + subList[1] + "\">" + subList[2] + "</td>" + "<td>" + subList[3] + "</td><td>" + subList[4] + "</td>");
					sr.WriteLine("</tr>");
					if (subList[4] == "valid"){
						validFileCount++;
					}
				}
				sr.WriteLine("</table></body></html>");
				sr.Close ();
				int multipleFiles = 0;
				DialogResult createBaseline = new DialogResult();
				createBaseline = MessageBox.Show("Number of valid files: " + validFileCount.ToString() + "\n" + "Create baseline dossier under " + topSequenceFolder.ToString() + "?", "Create Baseline?", MessageBoxButtons.YesNo);
				if (createBaseline == DialogResult.Yes){
					//copy all valid files to a new baseline folder
					string consolidatedDossier = topSequenceFolder + Path.DirectorySeparatorChar + "consolidated";
					Directory.CreateDirectory(consolidatedDossier);
					foreach (List<string> subList in leafList){
						if(subList[4] == "valid"){
							int stopHere = subList[1].LastIndexOf("/") - 5;
							Directory.CreateDirectory(consolidatedDossier + Path.DirectorySeparatorChar + subList[1].Substring(5,stopHere));
							if (File.Exists(consolidatedDossier + Path.DirectorySeparatorChar + subList[1].Substring(5))){
								File.Copy(topSequenceFolder + Path.DirectorySeparatorChar + subList[1], consolidatedDossier + Path.DirectorySeparatorChar + subList[1].Substring(5,subList[1].Length-9) + multipleFiles.ToString() + subList[1].Substring(subList[1].Length-4,4));
								multipleFiles++;
							}
							else{
								File.Copy(topSequenceFolder + Path.DirectorySeparatorChar + subList[1], consolidatedDossier + Path.DirectorySeparatorChar + subList[1].Substring(5));
							}
						}					
					}
				}
				if (createBaseline == DialogResult.No){
					//do nothing
				}
			} 
			catch (Exception b) {
				MessageBox.Show (b.ToString (), "Failed to read the sequence index.xml files");
			}
		}

		public XmlNodeList leafCollection (string xmlPath)
		{			
			XmlTextReader mySequenceReader = new XmlTextReader (xmlPath);
			XmlDocument sequenceSourceDoc = new XmlDocument ();
			sequenceSourceDoc.Load (mySequenceReader);
			mySequenceReader.Close ();
			System.Xml.XmlNodeList leafItems;
			leafItems = sequenceSourceDoc.SelectNodes ("//leaf");
			return(leafItems);
		}
	}
}
