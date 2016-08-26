using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace eCTD_indexer
{
    public class eCTD_Directories
    {
        /// <summary>
        /// Creates all eCTD directories.
        /// </summary>
        /// <param name="rootDir">Root directory where to start</param>
        /// <param name="memberStateList">List of member states</param>
        public void Create(String rootDir, List<String> memberStateList)
        {
            String sourceFile = "";
            DirectoryInfo rootDirectory = new DirectoryInfo(rootDir); // textBoxSeqDir.Text
            rootDirectory.CreateSubdirectory("m1");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "10-cover");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "10-cover" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "10-cover" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "12-form");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "12-form" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "12-form" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "131-spclabelpl");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "131-spclabelpl" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "131-spclabelpl" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "132-mockup");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "132-mockup" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "132-mockup" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "133-specimen");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "133-specimen" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "133-specimen" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "134-consultation");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "134-consultation" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "134-consultation" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "135-approved");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "135-approved" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "135-approved" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "136-braille");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "14-expert");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "14-expert" + Path.DirectorySeparatorChar + "141-quality");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "14-expert" + Path.DirectorySeparatorChar + "142-nonclinical");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "14-expert" + Path.DirectorySeparatorChar + "143-clinical");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific" + Path.DirectorySeparatorChar + "151-bibliographic");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific" + Path.DirectorySeparatorChar + "152-generic-hybrid-bio-similar");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific" + Path.DirectorySeparatorChar + "153-data-market-exclusivity");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific" + Path.DirectorySeparatorChar + "154-exceptional");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "15-specific" + Path.DirectorySeparatorChar + "155-conditional-ma");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "16-environrisk");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "16-environrisk" + Path.DirectorySeparatorChar + "161-nongmo");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "16-environrisk" + Path.DirectorySeparatorChar + "162-gmo");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "17-orphan");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "17-orphan" + Path.DirectorySeparatorChar + "171-similarity");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "17-orphan" + Path.DirectorySeparatorChar + "172-market-exclusivity");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "18-pharmacovigilance");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "18-pharmacovigilance" + Path.DirectorySeparatorChar + "181-phvig-system");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "18-pharmacovigilance" + Path.DirectorySeparatorChar + "182-riskmgt-system");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "19-clinical-trials");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "110-paediatrics");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "responses");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "responses" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "responses" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "additional-data");
            rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "additional-data" + Path.DirectorySeparatorChar + "common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "additional-data" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m2");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "22-intro");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "23-qos");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "24-nonclin-over");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "25-clin-over");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "26-nonclin-sum");
            rootDirectory.CreateSubdirectory("m2" + Path.DirectorySeparatorChar + "27-clin-sum");
            rootDirectory.CreateSubdirectory("m3");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s1-gen-info");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s2-manuf");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s3-charac");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s41-spec");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s42-analyt-proc");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s43-val-analyt-proc");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s44-batch-analys");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s45-justif-spec");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s5-ref-stand");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s6-cont-closure-sys");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-1-manufacturer-1" + Path.DirectorySeparatorChar + "32s7-stab");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p1-desc-comp");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p2-pharm-dev");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p3-manuf");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p4-contr-excip");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar + "excipient-1");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p51-spec");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p52-analyt-proc");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p53-val-analyt-proc");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p54-batch-analys");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p55-charac-imp");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p56-justif-spec");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p6-ref-stand");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p7-cont-closure-sys");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod" + Path.DirectorySeparatorChar + "product-1" + Path.DirectorySeparatorChar + "32p8-stab");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a1-fac-equip");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a2-advent-agent");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a3-excip-name-1");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32r-reg-info");
            rootDirectory.CreateSubdirectory("m3" + Path.DirectorySeparatorChar + "33-lit-ref");
            rootDirectory.CreateSubdirectory("m4");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4211-prim-pd");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4212-sec-pd");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4213-safety-pharmacol");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4214-pd-drug-interact");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4221-analyt-met-val");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4222-absorp");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4223-distrib");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4224-metab");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4225-excr");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4226-pk-drug-interact");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4227-other-pk-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4231-single-dose-tox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4232-repeat-dose-tox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42331-in-vitro");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42332-in-vivo");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42341-lt-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42342-smt-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42343-other-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42351-fert-embryo-dev");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42352-embryo-fetal-dev");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42353-pre-postnatal-dev");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42354-juv");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4236-loc-tol");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42371-antigen");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42372-immunotox");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42373-mechan-stud");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42374-dep");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42375-metab");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42376-imp");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42377-other");
            rootDirectory.CreateSubdirectory("m4" + Path.DirectorySeparatorChar + "43-lit-ref");
            rootDirectory.CreateSubdirectory("m5");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "52-tab-list");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5351-stud-rep-contr");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5351-stud-rep-contr" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5351-stud-rep-contr" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5351-stud-rep-contr" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5352-stud-rep-uncontr");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5352-stud-rep-uncontr" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5352-stud-rep-uncontr" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5352-stud-rep-uncontr" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5354-other-stud-rep");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5354-other-stud-rep" + Path.DirectorySeparatorChar + "study-report-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5354-other-stud-rep" + Path.DirectorySeparatorChar + "study-report-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud" + Path.DirectorySeparatorChar + "indication-1" + Path.DirectorySeparatorChar + "5354-other-stud-rep" + Path.DirectorySeparatorChar + "study-report-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "536-postmark-exp");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl" + Path.DirectorySeparatorChar + "study-1");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl" + Path.DirectorySeparatorChar + "study-2");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl" + Path.DirectorySeparatorChar + "study-3");
            rootDirectory.CreateSubdirectory("m5" + Path.DirectorySeparatorChar + "54-lit-ref");
            rootDirectory.CreateSubdirectory("util");
            rootDirectory.CreateSubdirectory("util" + Path.DirectorySeparatorChar + "dtd");
            rootDirectory.CreateSubdirectory("util" + Path.DirectorySeparatorChar + "style");
            sourceFile = eCTD_indexer.Properties.Resources.ich_ectd_3_2;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "dtd" + Path.DirectorySeparatorChar + "ich-ectd-3-2.dtd", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.ectd_2_0;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "style" + Path.DirectorySeparatorChar + "ectd-2-0.xsl", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_regional;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "dtd" + Path.DirectorySeparatorChar + "eu-regional.dtd", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_regional1;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "style" + Path.DirectorySeparatorChar + "eu-regional.xsl", sourceFile, Encoding.GetEncoding(1252));
            sourceFile = eCTD_indexer.Properties.Resources.eu_envelope;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "dtd" + Path.DirectorySeparatorChar + "eu-envelope.mod", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_leaf;
            System.IO.File.WriteAllText(rootDirectory + "" + Path.DirectorySeparatorChar + "util" + Path.DirectorySeparatorChar + "dtd" + Path.DirectorySeparatorChar + "eu-leaf.mod", sourceFile);  
        }

        /// <summary>
        /// Deletes all subfolders of the given folder.
        /// </summary>
        /// <param name="rootPath"></param>
        public void DeleteEmptyDirectories(String rootPath)
        {
            int numberOfDirs = this.Count(rootPath);

            string[] dirListArray; //list of all directories in sequence
            dirListArray = new string[numberOfDirs];

            //initialise initalArray
            for (int i = 0; i < dirListArray.Length; i++)
            {
                dirListArray[i] = "0";
            }

            //pass root directory to dirLister
            dirListArray = this.dirLister(rootPath, 0, dirListArray);

            //order dirListArray alphabetically (to correct for webfolders), then reverse it
            Array.Sort(dirListArray);
            Array.Reverse(dirListArray);

            //pass reversed dirListArray to directoryDeleter
            for (int p = 1; p < dirListArray.Length; p++)
            {
                this.dirDeleter(dirListArray[p]);
            } 
        }

        /// <summary>
        /// Return a list of all eCTD subdirectories of 
        /// a commited root directory based on the eCTD definition.
        /// This method does not list up the subdirectories 
        /// of a directory on the harddrive.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of all eCTD subdirectories</returns>
        public List<String> getSubDirectories(String root)
        {
            List<String> returnvalue = new List<String>();

            #region root
            // Pattern
            String pat = @"(?<=[0-9]{4})";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(root);

            if (m.Success)
            {
                returnvalue.Add("m1");
                returnvalue.Add("m2");
                returnvalue.Add("m3");
                returnvalue.Add("m4");
                returnvalue.Add("m5");
                return returnvalue;
            }
            #endregion

            #region m1
            if (root == "m1")
            {
                return new List<string>() { "eu" };
            }

            if(root == "eu")
            {
                returnvalue.Add("10-cover");
                returnvalue.Add("12-form");
                returnvalue.Add("13-pi");
                returnvalue.Add("14-expert");
                returnvalue.Add("15-specific");
                returnvalue.Add("16-environrisk");
                returnvalue.Add("17-orphan");
                returnvalue.Add("18-pharmacovigilance");
                returnvalue.Add("19-clinical-trials");
                returnvalue.Add("110-paediatrics");
                returnvalue.Add("additional-data");
                returnvalue.Add("responses");
                return returnvalue;
            }

            if (root == "10-cover" || root =="12-form"
                || root == "additional-data" || root == "responses")
            {
                returnvalue.Add("common");
                return returnvalue;
            }

            if(root =="13-pi")
            {
                returnvalue.Add("131-spclabelpl");
                returnvalue.Add("132-mockup");
                returnvalue.Add("133-specimen");
                returnvalue.Add("134-consultation");
                returnvalue.Add("135-approved");
                returnvalue.Add("136-braille");
                return returnvalue;
            }

            if (root == "14-expert")
            {
                returnvalue.Add("141-quality");
                returnvalue.Add("142-nonclinical");
                returnvalue.Add("143-clinical");
                return returnvalue;
            }

            if (root == "15-specific")
            {
                returnvalue.Add("151-bibliographic");
                returnvalue.Add("152-generic-hybrid-bio-similar");
                returnvalue.Add("153-data-market-exclusivity");
                returnvalue.Add("154-exceptional");
                returnvalue.Add("155-conditional-ma");
                return returnvalue;
            }

            if (root == "16-environrisk")
            {
                returnvalue.Add("161-nongmo");
                returnvalue.Add("162-gmo");
                return returnvalue;
            }

            if (root == "17-orphan")
            {
                returnvalue.Add("171-similarity");
                returnvalue.Add("172-market-exclusivity");
                return returnvalue;
            }

            if (root == "18-pharmacovigilance")
            {
                returnvalue.Add("181-phvig-system");
                returnvalue.Add("182-riskmgt-system");
                return returnvalue;
            }

            if (root == "19-clinical-trials" || root == "110-paediatrics")
            {
                return returnvalue;
            }

            #endregion

            #region m2

            if (root == "m2")
            {
                returnvalue.Add("22-intro");
                returnvalue.Add("23-qos");
                returnvalue.Add("24-nonclin-over");
                returnvalue.Add("25-clin-over");
                returnvalue.Add("26-nonclin-sum");
                returnvalue.Add("27-clin-sum");
                return returnvalue;
            }

            #endregion

            #region m3
            if (root == "m3")
            {
                returnvalue.Add("32-body-data");
                returnvalue.Add("33-lit-ref");
                return returnvalue;
            }

            if (root == "32-body-data")
            {
                returnvalue.Add("32a-app");
                returnvalue.Add("32p-drug-prod");
                returnvalue.Add("32r-reg-info");
                returnvalue.Add("32s-drug-sub");
                return returnvalue;
            }

            if (root == "32a-app")
            {
                returnvalue.Add("32a1-fac-equip");
                returnvalue.Add("32a2-advent-agent");
                returnvalue.Add("32a3-excip-name-1");
                return returnvalue;
            }

            if (root == "32p-drug-prod")
            {
                returnvalue.Add("product-1");
                return returnvalue;
            }

            if (root == "32r-reg-info")
            {
                return returnvalue;
            }

            if (root == "32s-drug-sub")
            {
                returnvalue.Add("substance-1-manufacturer-1");
                return returnvalue;
            }

            if (root == "33-lit-ref")
            {
                return returnvalue;
            }

            #endregion


            if (root == "m4")
            {
                returnvalue.Add("42-stud-rep");
                returnvalue.Add("43-lit-ref");
                return returnvalue;
            }

            if (root == "m5")
            {
                returnvalue.Add("52-tab-list");
                returnvalue.Add("53-clin-stud-rep");
                returnvalue.Add("54-lit-ref");
                return returnvalue;
            }

            return returnvalue;
        }

        /// <summary>
        /// Counts the number of directory in the given path
        /// </summary>
        /// <param name="path">root directory from where to start counting</param>
        /// <returns>number of directories</returns>
        public int Count(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

            int numberOfDirectories = di.GetDirectories().Length;
            if (dirs.Length > 0)
            {
                for (int j = 0; j < dirs.Length; j++)
                {
                    numberOfDirectories = numberOfDirectories + dirs[j].GetDirectories().Length;
                }
            }

            numberOfDirectories++;

            return numberOfDirectories;
        }

        /// <summary>
        /// This method writes all names of all Sub-Directories into an Array.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="counter"></param>
        /// <param name="allSubDirs"></param>
        /// <returns></returns>
        public string[] dirLister(string path, int counter, string[] allSubDirs)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dirs = di.GetDirectories();

                while (allSubDirs[counter] != "0") //to correct counter after jumping up from leaf directories
                {
                    counter++;
                }

                allSubDirs[counter] = di.FullName;
                counter++;

                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        dirLister(dirs[i].FullName, counter, allSubDirs);
                    }
                }
            }

            catch (Exception)
            {
                //MessageBox.Show(e.ToString(), "The indexing process failed");
            }

            return allSubDirs;
        }

        /// <summary>
        /// Deletes an empty directory. 
        /// Works only if no files or subdirectories exists in 
        /// the given directory.
        /// </summary>
        /// <param name="path"></param>
        public void dirDeleter(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dirs = di.GetDirectories();
                FileInfo[] files = di.GetFiles();

                if (dirs.Length == 0 && files.Length == 0)
                {
                    di.Delete(false);
                }
            }

            catch (Exception)
            {
                //MessageBox.Show(e.ToString(), "The delete process failed");
            }
        }
    }
}
