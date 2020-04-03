# ectd_indexer

Instructions for using the program, the binary file can be downloaded from ectd.is

---


To get the executable file, download the zip file from ectd.is and extract all files.

To run the program in Windows double click the EU-Module-1.exe in the Application folder.
 
To run the program in Linux, make sure mono is installed, then type: 
mono EU-Module-1.exe 
(or: mono /path/to/file/EU-Module-1.exe, as appropriate)

---

Note that it is presumed that the entire dossier is available in electronic format before starting this procedure.

Steps to building the eCTD application:

1. Create a sequence folder where you want to build the application, copy the path of the sequence folder to the eCTD indexer, then use the "eCTD folder tree" button to create the eCTD folder tree with the required files in the "util" folders (stylesheets and DTDs). 

2. Save sections of the CTD dossier in the relevant folders in accordance with the Notice To Applicants EU Module 1 v. 1.4 and eCTD v. 3.2 guideline. Note that for multiple instances of 3.2.S, 3.2.P, 3.2.P.4, etc., additional folders have to be generated manually (e.g. by copy-pasting).

3. Delete empty folders and create eu-regional.xml and index.xml with the eCTD indexer.

4. Modify the index.xml document with a text editor or XML notepad, if needed.

---


1. Enter the sequence path in the text box under "Path to sequence directory (e.g. 0000), then press the "eCTD folder tree" button.If any of the country checkboxes are checked when the 'eCTD folder tree' button is clicked, corresponding country folders will be created under 10-cover, 12-form, 131-spclabelpl, 132-mockup, 133-specimen, 134-consultation and 135-approved.

Note that the UUID submission identification number was introduced in version 3.0.1 of the EU Module 1 specification. If the UUID text box in the program form is left empty, the program will generate a new number automatically. For subsequent sequences, use the "Copy envelope" button to copy the details from a previous sequence for the dossier.


2. Save sections of the CTD dossier in the relevant folders:

After creating the empty folder structure, divide the dossier into separate pdf documents, name documents in Module 1 according to the EU M1 specification (http://esubmission.ema.europa.eu/eumodule1/index.htm) and Modules 2 to 5 according to the ICH eCTD specification (v. 3.2, http://estri.ich.org/eCTD/eCTD_Specification_v3_2.pdf) and save in the relevant folder. Note that it is very important to name the documents exactly as listed in the specification document.

The following rules are applied by the program to assign a title for documents in Module 1.2:
    
* If the filename contains "form-" the title will be "Application - " followed by the text between "form-" and ".pdf"
      e.g. a filename ".../common-form-power-of-attorney.pdf" would give the title "Application - power-of-attorney"
    
* If the filename does not contain "form-", the title will be "Application form"
 e.g. a filename ".../common-form.pdf" would give the title "Application form"

Additionally, in order for the following documents in Module 1.3.1 to be indexed correctly, they must be named as follows:

Document:		PDF name must include:	Example:
SPC			-spc.			../m1/eu/13-pi/131-spclabelpl/common/en/en-spc.pdf
Annex 2		-annex2		../m1/eu/13-pi/131-spclabelpl/common/en/en-annex2.pdf
Outer packaging	-outer			../m1/eu/13-pi/131-spclabelpl/common/en/en-outer.pdf
Intermediate packaging	-interpack		../m1/eu/13-pi/131-spclabelpl/common/en/en-interpack.pdf
Immediate packaging	-impack		../m1/eu/13-pi/131-spclabelpl/common/en/en-impack.pdf
Other			-other			../m1/eu/13-pi/131-spclabelpl/common/en/en-other.pdf
Package Leaflet	-pl			../m1/eu/13-pi/131-spclabelpl/common/en/en-pl.pdf
Combined  		-combined 		../m1/eu/13-pi/131-spclabelpl/common/en/en-combined.pdf

XML attributes for 2.3.S, 2.3.P, 3.2.S, 3.2.P, 3.2.P.4, 3.2.A.1 and 3.2.A.2:
The attribues for the above Modules can be read from a separate text file. The text file should be named "attributes.txt" and be saved under the top level folder (i.e. on the same level as the sequence folders, not inside a sequence folder). The text file should include information on the path to the file or folder and the values to be used for the attributes, separated by spaces. One file per line and each line must end with a space, e.g. as follows:

m2/23-qos/drug-substance.pdf substance:propranolol manufacturer:apicorp 
m2/23-qos/drug-product.pdf product-name:propro dosageform:tablets manufacturer:newsite 
m3/32-body-data/32s-drug-sub/substance-1-manufacturer-1 substance:propranolol manufacturer:apicorp 
m3/32-body-data/32p-drug-prod/product-1 product-name:propro dosageform:tablets manufacturer:newsite 

As is, this text file must be manually prepared. A template attributes.txt file is included.


3. Create eu-regional.xml and index.xml with the eCTD indexer after saving all documents as detailed above:

The information necessary for the Module 1 envelope should be entered into the relevant fields. Refer to the Module 1 specification (see table above) for details on the Module 1 envelope. After completing this, browse to or copy-paste the path to the sequence directory (e.g. C:\eCTD\sample\0000) in the "Path to sequence directory" text box, then click the "eu-regional" button to create the eu-regional.xml file for Module 1. 
The button 'copy envelope' can be used to automatically copy information from a previous sequence into the form: Press the button, navigate to an eu-regional.xml file and press OK.
The index.xml file for Modules 2-5 is then created by clicking the "index.xml" button.

The button 'delete empty' deletes all empty directories in subfolders under the path entered in the the "Path to sequence directory" text box. It is therefore important to finish copying all pdfs in the relevant folders before pressing this button. 

Note that the program does not give a warning before overwriting existing eu-regional.xml or index.xml files.


4. Modify the index.xml document with a text editor or XML notepad:

The index.xml file may have to be modified - e.g. to replace the document titles where those generated automatically are not descriptive enough. This can be done by editing the xml file in a text editor like notepad or an xml editor like Microsoft XML Notepad 2007. 

Save the index.xml after making any changes. The md5 checksum for the index.xml file can be generated by entering the path to the file in the text box below 'Calculate MD5 checksum for single file' and pressing the MD5 button. The md5 sum should then be saved as a text document directly under the sequence folder. The "save" button to the right of the checksum will save the md5 as a text document "index-md5.txt" in the sequence folder.

---

Instructions for the replace and delete attributes:

To replace a document from a previous sequence, add "replace(seq. no.)" to the end of the document name in the current sequence as a reference to the previous sequence. For example, if Module 3.2.P.3.3 submitted in sequence 0000 should be replaced in sequence 0001, the new file should be named as follows:
C:\eCTD\eCTDDossier\0001\m3\32-body-data\32p-drug-prod\productname\32p3-manuf\manuf-process-and-controlsreplace(0000).pdf. 
The program will then look for a leaf element that refers to a file named C:\eCTD\eCTDDossier\0000\m3\32-body-data\32p-drug-prod\productname\32p3-manuf\manuf-process-and-controls.pdf in the index for sequence 0000, create a new leaf element in sequence 0001 and then rename the file to get rid of the "replace(seq. no.)" bit.

To append a document to a document in a previous sequence, add "append(seq. no.)", e.g. "append(0000)" at the end of the document name in the current sequence. The same goes in this case as for the replace attribute, above. The filename and path of the current file must be identical to the previous file and it is not possible to append to files in the same sequence (e.g. a file in sequence 0001 can not be appended to another file in sequence 0001).

The delete attribute is set in a similar way - include a document with the same path and name as the document to be deleted, but add "delete(seq.no.)" to the end of the filename. For example, if Module 3.2.P.3.3 submitted in sequence (0000) should be withdrawn in sequence 0001, include a file named:
C:\eCTD\eCTDDossier\0001\m3\32-body-data\32p-drug-prod\productname\32p3-manuf\manuf-process-and-controlsdelete(0000).pdf
in sequence 0001. The program will create the leaf element accordingly, then delete the file from the 0001 sequence.

On pressing the button "Assemble current dossier" the program will go through all index.xml files in all sequences under the path in the sequence text box (i.e. one level up from the absolute path in the text box) and create an HTML file listing all documents not deleted or replaced up to the last sequence. The HTML file is written in the same directory as the sequence folders (e.g. if the path entered in the sequence text box is C:\ectd\dossier\0003, the HTML file will be saved as C:\ectd\dossier\current-dossier.html).
