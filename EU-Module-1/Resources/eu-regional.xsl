<?xml version="1.0" encoding="iso-8859-1" standalone="no"?>

<!--
	EU Module 1 Style-Sheet

	Version 3.0.1
	May 2016
-->

<xsl:stylesheet version="3.1"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:eu="http://europa.eu.int" 
	xmlns:xlink="http://www.w3c.org/1999/xlink">
   
   <xsl:output method="html" encoding="UTF-8" indent="no"/>
   
   <xsl:template match="/">
      <html>
         <head>
            <title>EU Module 1 - DTD version <xsl:value-of select="/eu:eu-backbone/@dtd-version"/></title>
            <style type="text/css">
				h1, h2, h3, h4 {margin-top:3pt ; margin-bottom:0pt}
				ul {margin-bottom:0pt ; margin-top:0pt}
			</style>
         </head>
			<body>
				<center>
					<h1>EU Module 1</h1>
					<small>DTD version <xsl:value-of select="/eu:eu-backbone/@dtd-version"/></small>
				</center>
				<xsl:apply-templates select="//envelope"/>
				<br/>
				<xsl:apply-templates select="//m1-eu"/>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="data">
		<xsl:value-of select="."/>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="country">
		<xsl:value-of select="translate(.,'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ')"/>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="csv">
		<xsl:value-of select="."/>
		<xsl:if test="position() != last()"><xsl:text>, </xsl:text></xsl:if>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="line">
		<xsl:value-of select="."/>
		<xsl:if test="position() != last()"><br/></xsl:if>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="agency"> 
		<xsl:choose>
			<xsl:when test="@code='AT-BASG'">Austria - BASG- Austrian Federal Office for Safety in Health Care / Austrian Medicines and Medical Devices Agency</xsl:when>
			<xsl:when test="@code='BE-FAMHP'">Belgium - Agence Fédérale des Médicaments et des Produits de Santé</xsl:when>
			<xsl:when test="@code='BG-BDA'">Bulgaria - Bulgarian Drug Agency</xsl:when>
			<xsl:when test="@code='CY-PHS'">Cyprus - Pharmaceutical Services, Ministry of Health</xsl:when>
			<xsl:when test="@code='CZ-SUKL'">Czech Rep - State Institute for Drug Control</xsl:when>
			<xsl:when test="@code='DE-BFARM'">Germany - BfArM - Bundesinstitut für Arzneimittel und Medizinprodukte</xsl:when>
			<xsl:when test="@code='DE-PEI'">Germany - Paul-Ehrlich Institut</xsl:when>
			<xsl:when test="@code='DK-DKMA'">Denmark - Danish Medicines Agency</xsl:when>
			<xsl:when test="@code='EE-SAM'">Estonia - State Agency of Medicines</xsl:when>
			<xsl:when test="@code='EL-EOF'">Greece - EOF - National Drug Organisation</xsl:when>
			<xsl:when test="@code='ES-AEMPS'">Spain - Agencia Española de Medicamentos y Productos Sanitarios</xsl:when>
			<xsl:when test="@code='EU-EDQM'">EDQM - European Directorate for the Quality of Medicines &amp; HealthCare</xsl:when>
			<xsl:when test="@code='FI-FIMEA'">Finland - Finnish Medicines Agency</xsl:when>
			<xsl:when test="@code='FR-ANSM'">France - ANSM - Agence national de sécurité du médicament et des produits de santé</xsl:when>
			<xsl:when test="@code='HR-HALMED'">Croatia - Agency for Medicinal Products and Medical Devices of Croatia </xsl:when>
			<xsl:when test="@code='HU-OGYI'">Hungary - National Institute for Quality and Organizational Development in Healthcare and Medicines, National Institute of Pharmacy</xsl:when>
			<xsl:when test="@code='IE-HPRA'">Ireland - The Health Products Regulatory Authority</xsl:when>
			<xsl:when test="@code='IS-IMCA'">Iceland - Icelandic Medicines Control Agency</xsl:when>
			<xsl:when test="@code='IT-AIFA'">Italy - Agenzia Italiana del Farmaco</xsl:when>
			<xsl:when test="@code='LI-LLV'">Liechtenstein - Kontrollstelle für Arzneimittel beim Amt für Lebensmittelkontrolle und Veterinärwesen</xsl:when>
			<xsl:when test="@code='LT-SMCA'">Lithuania - State Medicines Control Agency</xsl:when>
			<xsl:when test="@code='LU-MINSANT'">Luxembourg - Direction de la Santé Villa Louvigny Division de la Pharmacie et des Medicaments</xsl:when>
			<xsl:when test="@code='LV-ZVA'">Latvia - State Agency of Medicines</xsl:when>
			<xsl:when test="@code='MT-MEDAUTH'">Malta - Medicines Authority Divizjoni Tas-Sahha Bezzjoni Ghar-Regolazzjoni Tal-Medicini</xsl:when>
			<xsl:when test="@code='NL-MEB'">Netherlands - College ter Beoordeling van Geneesmiddelen Medicines Evaluation Board</xsl:when>
			<xsl:when test="@code='NO-NOMA'">Norway - The Norwegian Medicines Agency</xsl:when>
			<xsl:when test="@code='PL-URPL'">Poland - Office for Registration of Medicinal Products, Medical Devices and Biocidal Products</xsl:when>
			<xsl:when test="@code='PT-INFARMED'">Portugal - INFARMED - Instituto Nacional da Farmácia e do Medicamento Parque da Saúde de Lisboa</xsl:when>
			<xsl:when test="@code='RO-ANMMD'">Romania- National Agency for Medicines and Medical Devices</xsl:when>
			<xsl:when test="@code='SE-MPA'">Sweden - Medical Products Agency</xsl:when>
			<xsl:when test="@code='SI-JAZMP'">Slovenia - Javna agencija Republike Slovenije za zdravila in medicinske pripomocke</xsl:when>
			<xsl:when test="@code='SK-SIDC'">Slovak Rep - State Institute for Drug Control</xsl:when>
			<xsl:when test="@code='UK-MHRA'">Medicines and Healthcare products Regulatory Agency</xsl:when>
			<xsl:when test="@code='EU-EMA'">EMA - European Medicines Agency</xsl:when>
		</xsl:choose>
		<xsl:text> </xsl:text>(<xsl:value-of select="@code"/>)
	</xsl:template>
	
	<xsl:template match="*|@*" mode="submission">
		Type: 
		<xsl:choose>
			<xsl:when test="@type='maa'">Marketing Authorisation</xsl:when>
			<xsl:when test="@type='var-type1a'">Variation Type IA</xsl:when>
			<xsl:when test="@type='var-type1ain'">Variation Type IAin</xsl:when>
			<xsl:when test="@type='var-type1b'">Variation Type IB</xsl:when>
			<xsl:when test="@type='var-type2'">Variation Type II</xsl:when>
			<xsl:when test="@type='var-nat'">National Variation</xsl:when>
			<xsl:when test="@type='extension'">Extension</xsl:when>
			<xsl:when test="@type='rup'">Repeat Use Procedure</xsl:when>
			<xsl:when test="@type='psur'">Periodic Safety Update Report</xsl:when>
			<xsl:when test="@type='psusa'">PSUR single assessment procedure</xsl:when>
			<xsl:when test="@type='pam-sob'">Specific obligation related to a post-authorisation measure</xsl:when>
			<xsl:when test="@type='pam-anx'">Annex II condition related to a post-authorisation measure</xsl:when>
			<xsl:when test="@type='pam-mea'">Additional pharmacovigilance activity in the risk-management plan</xsl:when>
			<xsl:when test="@type='pam-leg'">Legally binding measure related to a post-authorisation measure</xsl:when>
			<xsl:when test="@type='pam-sda'">Cumulative review following a request originating from a PSUR or a signal evaluation</xsl:when>
			<xsl:when test="@type='pam-capa'">Corrective Action/Preventive Action</xsl:when>
			<xsl:when test="@type='pam-p45'">Paediatric submissions related to a post-authorisation measure (Par 45)</xsl:when>
			<xsl:when test="@type='pam-p46'">Paediatric submissions related to a post-authorisation measure (Par 46)</xsl:when>
			<xsl:when test="@type='pam-paes'">Submission of a post authorisation efficacy study</xsl:when>
			<xsl:when test="@type='pam-rec'">Recommendation related to a post-authorisation measure </xsl:when>
			<xsl:when test="@type='pass107n'">Submission of a post authorisation safety study protocol</xsl:when>
			<xsl:when test="@type='pass107q'">Submission of a post authorisation safety study report</xsl:when>
			<xsl:when test="@type='renewal'">Renewal</xsl:when>
			<xsl:when test="@type='asmf'">Active Substance Master File</xsl:when>
			<xsl:when test="@type='pmf'">Plasma Master File</xsl:when>
			<xsl:when test="@type='referral-20'">Referral under Article 20</xsl:when>
			<xsl:when test="@type='referral-294'">Referral under Article 29(4)</xsl:when>
			<xsl:when test="@type='referral-29p'">Referral under Article 29 paediatric</xsl:when>
			<xsl:when test="@type='referral-30'">Referral under Article 30</xsl:when>
			<xsl:when test="@type='referral-31'">Referral under Article 31</xsl:when>
			<xsl:when test="@type='referral-35'">Referral under Article 35</xsl:when>
			<xsl:when test="@type='referral-5-3'">Referral under Article 5(3)</xsl:when>
			<xsl:when test="@type='referral-107i'">Referral under Article 107i</xsl:when>
			<xsl:when test="@type='referral-16c1c'">Referral under Article 16c(1c)</xsl:when>
			<xsl:when test="@type='referral-16c4'">Referral under Article 16c(4)</xsl:when>
			<xsl:when test="@type='annual-reassessment'">Annual Reassessment</xsl:when>
			<xsl:when test="@type='usr'">Urgent Safety Restriction</xsl:when>
			<xsl:when test="@type='clin-data-pub-rp'">Clinical data for publication – Redacted Proposal</xsl:when>
			<xsl:when test="@type='clin-data-pub-fv'">Clinical data for publication – Final Version</xsl:when>
			<xsl:when test="@type='paed-7-8-30'">Paediatric Submission, Article 7, 8 or 30 of the Regulation</xsl:when>
			<xsl:when test="@type='paed-29'">Paediatric Submission, Article 29</xsl:when>
			<xsl:when test="@type='paed-45'">Paediatric Submission, Article 45</xsl:when>
			<xsl:when test="@type='paed-46'">Paediatric Submission, Article 46</xsl:when>						
			<xsl:when test="@type='article-58'">Article 58</xsl:when>
			<xsl:when test="@type='notification-61-3'">Notification 61(3)</xsl:when>
			<xsl:when test="@type='transfer-ma'">Transfer of Marketing Authorisation</xsl:when>
			<xsl:when test="@type='lifting-suspension'">Lifting of a Suspension</xsl:when>
			<xsl:when test="@type='withdrawal'">Withdrawal during Assessment or Withdrawal of MA</xsl:when>
			<xsl:when test="@type='cep'">CEP application</xsl:when>
			<xsl:when test="@type='rmp'">Risk Management Plan (outside any procedure)</xsl:when>
			<xsl:when test="@type='none'">The submission is not a regulatory activity</xsl:when>
		</xsl:choose>		
		<br/>
                <xsl:if test="string-length(@mode) > 0">
			Mode: 
			<xsl:choose>
				<xsl:when test="@mode='single'">Single</xsl:when>
				<xsl:when test="@mode='grouping'">Grouping</xsl:when>
				<xsl:when test="@mode='worksharing'">Worksharing</xsl:when>
			</xsl:choose>		
		</xsl:if>
		<xsl:if test="string-length(number) > 0">
			<br/>
			Number: <xsl:apply-templates select="number"/>
		</xsl:if>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="procedure-tracking">
		<xsl:if test="string-length(number) > 0">
			<br/>
			Number: <xsl:apply-templates select="number"/>
		</xsl:if>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="submission-unit">
		<xsl:if test="string-length(@type) > 0">
			Type: 
			<xsl:choose>
			<xsl:when test="@type='initial'">Initial submission to start any regulatory activity</xsl:when>
			<xsl:when test="@type='validation-response'">For rectifying business validation issues</xsl:when>
			<xsl:when test="@type='response'">Response to any kind of question</xsl:when>
			<xsl:when test="@type='corrigendum'">Corrigendum</xsl:when>
			<xsl:when test="@type='additional-info'">Other additional Information</xsl:when>
			<xsl:when test="@type='closing'">Final documents in the centralised procedure</xsl:when>
			<xsl:when test="@type='consolidating'">Consolidates the application after several information in the MRP or DCP handled outside the eCTD application</xsl:when>
			<xsl:when test="@type='reformat'">Reformatting of an existing submission application</xsl:when>
			</xsl:choose>
		</xsl:if>
		<br/>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="procedure">
		<xsl:choose>
			<xsl:when test="@type='centralised'">Centralised </xsl:when>
			<xsl:when test="@type='national'">National Procedure</xsl:when>
			<xsl:when test="@type='mutual-recognition'">Mutual Recognition Procedure (MRP)</xsl:when>
			<xsl:when test="@type='decentralised'">Decentralised Procedure (DCP)</xsl:when>
		</xsl:choose>
		<br/>
	</xsl:template>
	
	<xsl:template match="*|@*" mode="pidoc-type">
		<xsl:choose>
			<xsl:when test="@type='spc'">Summary of Product Characteristics (SmPC)</xsl:when>
			<xsl:when test="@type='outer'">Outer Packaging</xsl:when>
			<xsl:when test="@type='interpack'">Internal Packaging</xsl:when>
			<xsl:when test="@type='impack'">Immediate Packaging</xsl:when>
			<xsl:when test="@type='other'">Other Product Information</xsl:when>
			<xsl:when test="@type='pl'">Package Leaflet</xsl:when>
			<xsl:when test="@type='combined'">Combined</xsl:when>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template match="envelope">
		<center>
			<table width="90%" border="1px" frame="border" rules="groups" cellpadding="2" cellspacing="0">
				<tr>
					<td colspan="2"><h3>Envelope for <xsl:apply-templates select="./@country" mode="country"/></h3></td>
				</tr>
				<tr>
					<td width="20%" valign="top">Identifier: </td>
					<td><xsl:apply-templates select="identifier" mode="identifier"/></td>
				</tr>
				<tr>
					<td width="20%" valign="top">Submission: </td>
					<td><xsl:apply-templates select="submission" mode="submission"/></td>
				</tr>
				<tr>
					<td valign="top">Procedure Tracking Number(s): </td>
					<td><xsl:apply-templates select="submission/procedure-tracking/number" mode="line"/></td>
				</tr>
				<tr>
					<td width="20%" valign="top">Submission Unit: </td>
					<td><xsl:apply-templates select="submission-unit" mode="submission-unit"/></td>
				</tr>
				<tr>
					<td>Applicant: </td>
					<td><xsl:apply-templates select="applicant" mode="data"/></td>
				</tr>
				<tr>
					<td>Agency: </td>
					<td><xsl:apply-templates select="agency" mode="agency"/></td>
				</tr>
				<tr>
					<td>Procedure: </td>
					<td><xsl:apply-templates select="procedure" mode="procedure"/></td>
				</tr>
				<tr>
					<td>Invented Name: </td>
					<td><xsl:apply-templates select="invented-name" mode="csv"/></td>
				</tr>
				<tr>
					<td>INN: </td>
					<td><xsl:apply-templates select="inn" mode="csv"/></td>
				</tr>
				<tr>
					<td>Sequence: </td>
					<td><xsl:apply-templates select="sequence" mode="data"/></td>
				</tr>
				<tr>
					<td>Related Sequence: </td>
					<td><xsl:apply-templates select="related-sequence" mode="csv"/></td>
				</tr>
				<tr>
					<td>Submission Description: </td>
					<td><xsl:apply-templates select="submission-description" mode="data"/></td>
				</tr>
			</table>
		</center>
	</xsl:template>

	<xsl:template match="specific">
		For <xsl:apply-templates select="./@country" mode="country"/>: 
		<ul type="square">
			<xsl:apply-templates select="leaf | node-extension"/>
		</ul>
	</xsl:template>
	
	<xsl:template name="pi-doc-row">
		<xsl:param name="ctry"/>
		<tr>
			<td align="center"><xsl:apply-templates select="$ctry" mode="country"/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='spc']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='annex2']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='outer']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='interpack']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='impack']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='pl']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='other']/leaf" mode="plain"/><br/></td>
			<td><xsl:apply-templates select="//pi-doc[./@country=$ctry and @type='combined']/leaf" mode="plain"/><br/></td>
		</tr>
	</xsl:template>
	
	<xsl:template match="pi-doc">
		<xsl:variable name="pos" select="position()"/>
		<xsl:variable name="ctry" select="./@country"/>
		
		<xsl:variable name="prev" select="count(//pi-doc[position() &lt; $pos and @country = $ctry])"/>
		<xsl:if test="$prev = 0">
			<xsl:call-template name="pi-doc-row">
				<xsl:with-param name="ctry" select="$ctry"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<xsl:template match="leaf" mode="plain">
		<a>
			<xsl:attribute name="href"><xsl:value-of select="@xlink:href"/></xsl:attribute>
			<xsl:value-of select="title"/>
		</a>
		<xsl:text> </xsl:text>
		(<font color="red"><xsl:value-of select="@operation"/></font> - <font color="green"><xsl:value-of select="../@xml:lang"/></font>)
		<xsl:if test="position() != last()"><br/></xsl:if>
	</xsl:template>
	
	<xsl:template match="leaf">
		<li>
			<a>
				<xsl:attribute name="href"><xsl:value-of select="@xlink:href"/></xsl:attribute>
				<xsl:value-of select="title"/>
			</a>
			<xsl:text> </xsl:text>
			(<font color="red"><xsl:value-of select="@operation"/></font>)
			<xsl:if test="position() != last()"><br/></xsl:if>
		</li>
	</xsl:template>	
	
	<xsl:template match="node-extension">
		<li><xsl:apply-templates select="title" mode="data"/>
			<ul type="square">
				<xsl:apply-templates select="leaf | node-extension"/>
			</ul>
		</li>
	</xsl:template>

	<xsl:template match="m1-3-1-spc-label-pl">
		<table width="100%" cellpadding="2" cellspacing="0" border="1" style="font-size: 9pt">
			<tr>
				<th width="11%">Country</th>
				<th width="11%">SmPC</th>
				<th width="11%">Annex II</th>
				<th width="11%">Outer Packaging</th>
				<th width="11%">Intermediate Packaging</th>
				<th width="11%">Immediate Packaging</th>
				<th width="11%">Package Leaflet</th>
				<th width="11%">Other</th>
				<th width="11%">Combined</th>
			</tr>
			<xsl:apply-templates select="pi-doc"/>
		</table>
	</xsl:template>

	<xsl:template match="m1-eu">
		<center>
			<table width="90%" cellpadding="5" cellspacing="2">
				<tr>
					<td colspan="2"><h2>Module 1 EU</h2></td>
				</tr>
				<tr>
					<td width="5%" valign="top"><h3>1.0</h3></td>
					<td width="95%">
						<h3>Cover Letter</h3>
						<xsl:apply-templates select="m1-0-cover/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.2</h3></td>
					<td>
						<h3>Application Form</h3>
						<xsl:apply-templates select="m1-2-form/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.3</h3></td>
					<td>
						<h3>Product Information</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.1</h4></td>
					<td>
						<h4>SmPC, Labelling and Package Leaflet</h4>
						<xsl:apply-templates select="m1-3-pi/m1-3-1-spc-label-pl"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.2</h4></td>
					<td>
						<h4>Mock-up</h4>
						<xsl:apply-templates select="m1-3-pi/m1-3-2-mockup/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.3</h4></td>
					<td>
						<h4>Specimen</h4>
						<xsl:apply-templates select="m1-3-pi/m1-3-3-specimen/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.4</h4></td>
					<td>
						<h4>Consultation with Target Patient Groups</h4>
						<xsl:apply-templates select="m1-3-pi/m1-3-4-consultation/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.5</h4></td>
					<td>
						<h4>Product Information already approved in the Member States</h4>
						<xsl:apply-templates select="m1-3-pi/m1-3-5-approved/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.3.6</h4></td>
					<td>
						<h4>Braille</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-3-pi/m1-3-6-braille/leaf | m1-3-pi/m1-3-6-braille/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.4</h3></td>
					<td>
						<h3>Information about the Experts</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.4.1</h4></td>
					<td>
						<h4>Quality</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-4-expert/m1-4-1-quality/leaf | m1-4-expert/m1-4-1-quality/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.4.2</h4></td>
					<td>
						<h4>Non-Clinical</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-4-expert/m1-4-2-non-clinical/leaf | m1-4-expert/m1-4-2-non-clinical/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.4.3</h4></td>
					<td>
						<h4>Clinical</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-4-expert/m1-4-3-clinical/leaf | m1-4-expert/m1-4-3-clinical/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.5</h3></td>
					<td>
						<h3>Specific Requirements for Different Types of Applications</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.5.1</h4></td>
					<td>
						<h4>Information for Bibliographical Applications</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-5-specific/m1-5-1-bibliographic/leaf | m1-5-specific/m1-5-1-bibliographic/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.5.2</h4></td>
					<td>
						<h4>Information for Generic, 'Hybrid' or Bio-similar Applications</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-5-specific/m1-5-2-generic-hybrid-bio-similar/leaf | m1-5-specific/m1-5-2-generic-hybrid-bio-similar/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.5.3</h4></td>
					<td>
						<h4>(Extended) Data/Market Exclusivity</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-5-specific/m1-5-3-data-market-exclusivity/leaf | m1-5-specific/m1-5-3-data-market-exclusivity/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.5.4</h4></td>
					<td>
						<h4>Exceptional Circumstances</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-5-specific/m1-5-4-exceptional-circumstances/leaf | m1-5-specific/m1-5-4-exceptional-circumstances/node-extension"/>
						</ul>
					</td>
				</tr>
				<xsl:if test="count(//procedure[./@type='decentralised']) = 0">
					<tr>
						<td valign="top"><h4>1.5.5</h4></td>
						<td>
							<h4>Conditional Marketing Authorisation</h4>
							<ul type="square">
								<xsl:apply-templates select="m1-5-specific/m1-5-5-conditional-ma/leaf | m1-5-specific/m1-5-5-conditional-ma/node-extension"/>
							</ul>
						</td>
					</tr>
				</xsl:if>
				<tr>
					<td valign="top"><h3>1.6</h3></td>
					<td>
						<h3>Environmental Risk Assessment</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.6.1</h4></td>
					<td>
						<h4>Non-GMO</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-6-environrisk/m1-6-1-non-gmo/leaf | m1-6-environrisk/m1-6-1-non-gmo/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.6.2</h4></td>
					<td>
						<h4>GMO</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-6-environrisk/m1-6-2-gmo/leaf | m1-6-environrisk/m1-6-2-gmo/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.7</h3></td>
					<td>
						<h3>Information relating to Orphan Market Exclusivity</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.7.1</h4></td>
					<td>
						<h4>Similarity</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-7-orphan/m1-7-1-similarity/leaf | m1-7-orphan/m1-7-1-similarity/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.7.2</h4></td>
					<td>
						<h4>Market Exclusivity</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-7-orphan/m1-7-2-market-exclusivity/leaf | m1-7-orphan/m1-7-2-market-exclusivity/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.8</h3></td>
					<td>
						<h3>Information relating to Pharmacovigilance</h3>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.8.1</h4></td>
					<td>
						<h4>Pharmacovigilance System</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-8-pharmacovigilance/m1-8-1-pharmacovigilance-system/leaf | m1-8-pharmacovigilance/m1-8-1-pharmacovigilance-system/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h4>1.8.2</h4></td>
					<td>
						<h4>Risk-management System</h4>
						<ul type="square">
							<xsl:apply-templates select="m1-8-pharmacovigilance/m1-8-2-risk-management-system/leaf | m1-8-pharmacovigilance/m1-8-2-risk-management-system/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.9</h3></td>
					<td>
						<h3>Information relating to Clinical Trials</h3>
						<ul type="square">
							<xsl:apply-templates select="m1-9-clinical-trials/leaf | m1-9-clinical-trials/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3>1.10</h3></td>
					<td>
						<h3>Information relating to Paediatrics</h3>
						<ul type="square">
							<xsl:apply-templates select="m1-10-paediatrics/leaf | m1-10-paediatrics/node-extension"/>
						</ul>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3></h3></td>
					<td>
						<h3>Responses to Questions</h3>
						<xsl:apply-templates select="m1-responses/specific"/>
					</td>
				</tr>
				<tr>
					<td valign="top"><h3></h3></td>
					<td>
						<h3>Additional Data</h3>
						<xsl:apply-templates select="m1-additional-data/specific"/>
					</td>
				</tr>
			</table>
		</center>
	</xsl:template>
	
</xsl:stylesheet>
