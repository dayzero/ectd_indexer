<!--
In the eCTD File Organisation: "util/dtd/eu-envelope.mod"

Version 1.4
August 2009

Contributors:
   AFSSAPS (Aziz Diop)
   EMEA (Laurent Desqueper)
   MEB (C.A. van Belkum)

Version 2.0
February 2013

Contributors:
EMA (Antonios Yfantis)

Version 3.0
October 2015

Contributors:
BFARM (Klaus Menges)

Version 3.0.1
May 2016

Contributors:
BFARM (Klaus Menges)-->

<!-- ................................................................... -->
<!ELEMENT eu-envelope (
	envelope+
)>

<!ELEMENT envelope (
	identifier,
        submission,
        submission-unit,
	applicant, 
	agency, 
	procedure,
	invented-name+,
	inn*,
	sequence,
	related-sequence+,
	submission-description
)>

<!-- ................................................................... -->
<!ELEMENT identifier            ( #PCDATA )>
<!ELEMENT submission   		( number?, procedure-tracking )>
<!ELEMENT procedure-tracking 	( number+ )>
<!ELEMENT number 		( #PCDATA )>
<!ELEMENT submission-unit 	EMPTY>
<!ELEMENT applicant   		( #PCDATA )>
<!ELEMENT agency		EMPTY>
<!ELEMENT procedure    		EMPTY>
<!ELEMENT invented-name 	( #PCDATA )>
<!ELEMENT inn		        ( #PCDATA )>
<!ELEMENT sequence		( #PCDATA )>
<!ELEMENT related-sequence 	( #PCDATA )>
<!ELEMENT submission-description ( #PCDATA )>

<!-- ................................................................... -->
<!ATTLIST submission
type (maa | var-type1a | var-type1ain | var-type1b | var-type2 | var-nat | extension | rup | psur | psusa | rmp | renewal | pam-sob | pam-anx | pam-mea | pam-leg | pam-sda | pam-capa | pam-p45 | pam-p46 | pam-paes | pam-rec | pass107n | pass107q | asmf | pmf | referral-20 | referral-294 | referral-29p | referral-30 | referral-31 | referral-35 | referral-5-3 | referral-107i | referral-16c1c | referral-16c4 | annual-reassessment | usr | clin-data-pub-rp | clin-data-pub-fv | paed-7-8-30 | paed-29 | paed-45 | paed-46 | article-58 | notification-61-3 | transfer-ma | lifting-suspension | withdrawal | cep | none) #REQUIRED
mode ( single | grouping | worksharing ) #IMPLIED
>

<!-- ................................................................... -->
<!ATTLIST submission-unit
type (initial | validation-response | response | additional-info | closing | consolidating | corrigendum | reformat ) #REQUIRED
>

<!-- ................................................................... -->
<!ATTLIST agency
code ( AT-BASG | BE-FAMHP | BG-BDA | CY-PHS | CZ-SUKL | DE-BFARM | DE-PEI | DK-DKMA | EE-SAM | EL-EOF | ES-AEMPS | FI-FIMEA | FR-ANSM | HR-HALMED | HU-OGYI | IE-HPRA | IS-IMCA | IT-AIFA | LI-LLV | LT-SMCA | LU-MINSANT | LV-ZVA | MT-MEDAUTH | NL-MEB | NO-NOMA | PL-URPL | PT-INFARMED | RO-ANMMD | SE-MPA | SI-JAZMP | SK-SIDC | UK-MHRA | EU-EMA | EU-EDQM ) #REQUIRED>

<!-- ................................................................... -->
<!ATTLIST procedure
 type (
   centralised
 | national
 | mutual-recognition
 | decentralised
 ) #REQUIRED
>

<!-- ................................................................... -->
<!ENTITY % env-countries "(at|be|bg|cy|cz|de|dk|edqm|ee|el|ema|es|fi|fr|hr|hu|ie|is|it|li|lt|lu|lv|mt|nl|no|pl|pt|ro|se|si|sk|uk)">

<!-- ................................................................... -->
<!ATTLIST envelope country %env-countries; #REQUIRED >

<!-- +++ --> 