using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCTD_indexer.QuickCheck
{
    public static class _071_Filenames
    {
        public static String Check(String SequenceDirectory)
        {
            // Get all files in the dossier
            String[] FilesArray = Directory.GetFiles(SequenceDirectory, "*.*", SearchOption.AllDirectories)
                                     .Select(Path.GetFileName)
                                     .ToArray();

            // Create a StringBuilder to inform the user.
            StringBuilder sbReturnValue = new StringBuilder("Please note:\nFile names adapted to a product can not be found. For instance, in section m5 most of the filenames are not defined in the eCTD specification. These files will also be listed here, but this is does not mean that these filenames are invalid.");
            sbReturnValue.Append("\n\nThese files have not been found in the version 7.1 specification list:\n\n");

            // Because the object "Filesnames" is filled with possible
            // beginnings of a filename, we look if there is a file in the dossier
            // which filename begins with one of the Strings in "Filenames"
            for (int i=0;i< Filenames.Length;i++)
            {
                //
                // Find first element starting with substring.
                // For more information have a look at: https://www.dotnetperls.com/array-find
                //
                String result = Array.Find(FilesArray,
                    element => element.StartsWith(Filenames[i], StringComparison.Ordinal));

                while(result != null)
                {
                    // See also https://stackoverflow.com/a/497005
                    FilesArray = FilesArray.Where(val => val != result).ToArray();

                    // Find next element
                    result = Array.Find(FilesArray,
                    element => element.StartsWith(Filenames[i], StringComparison.Ordinal));                    
                }
            }

            // The rest of the files cannot be found in "Filesnames".
            for(int r=0;r<FilesArray.Length;r++)
            {
                sbReturnValue.Append("- \"");
                sbReturnValue.Append(FilesArray[r]);
                sbReturnValue.Append("\" \n");
            }

            return sbReturnValue.ToString();
        }

        private static String[] Filenames =
        {
            // Overview
            "eu-regional.dtd","eu-envelope.mod","eu-leaf.mod","ich-ectd-3-2.dtd","ectd-2-0.xsl","eu-regional.xsl",
            "eu-regional.xml","common-form",

            // m1
            "ctd-toc.pdf","index.xml","index-md5.txt","m1-toc.pdf","braille",
            "quality","nonclinical","clinical","bibliographic","biosimilar",
            "hybrid",
            "datamarketexclusivity", "exceptional", "conditionalma", "nongmo","gmo", "similarity",
            "marketexclusivity", "phvigsystem", "riskmgtsystem", "clinicaltrials","paediatrics",

            // m2
            "introduction","qos","appendices","regional-information","nonclinical-overview",
            "clinical-overview","pharmacol-written-summary","pharmacol-tabulated-summary",
            "pharmkin-written-summary","pharmkin-tabulated-summary","toxicology-written-summary",
            "toxicology-tabulated-summary","summary-biopharm","summary-clin-pharm", "summary-clin-efficacy",
            "summary-clin-safety","literature-references","synopses-indiv-studies",

            // m3
            "m3-toc.pdf", "nomenclature", "structure", "general-properties", "manufacturer",
            "manuf-process-and-controls", "control-of-materials", "control-critical-steps",
            "process-validation", "manuf-process-development", "elucidation-of-structure",
            "impurities", "ctrlstrat", "specification","analytical-procedure",
            "validation-analyt-procedure", "batch-analyses-var", "justification-of-specification",
            "reference-standards", "container-closure-system", "stability-summary",
            "postapproval-stability", "stability-data", "description-and-composition",
            "pharmaceutical-development", "manufacturers", "batch-formula",
            "manuf-process-and-controls", "control-critical-steps", "process-validation",
            "excipients", "analytical-procedures", "validation-analyt-procedures",
            "justification-of-specifications", "excipients-human-animal", "novel-excipients",
            "validation-analytical-procedures", "batch-analyses", "characterisation-impurities",
            "reference-standards", "container-closure-system", "stability-summary",
            "postapproval-stability", "stability-data",
            
            // m4
            "m4-toc.pdf",

            // m5
            "m5-toc.pdf",
            "tabular-listing"
        };
    }
}
