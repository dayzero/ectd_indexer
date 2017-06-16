<?xml version="1.0" encoding="iso-8859-1" standalone="no"?>
<!--
ectd
util/ectd-2-0.xsl
version 2.0
transformation of the backbone from xml to html
Yokohama, November 17, 2004
-->
<xsl:stylesheet  version="1.0" 
	xmlns:xsl = "http://www.w3.org/1999/XSL/Transform"
	xmlns:ectd = "http://www.ich.org/ectd"	
	xmlns:xlink = "http://www.w3c.org/1999/xlink">
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet" href="util/style/screen.css" type="text/css" media="screen"/>
			</head>
			<body>
				<h2>eCTD <font size="-1"> DTD version <xsl:value-of select="/ectd:ectd/@dtd-version"/></font></h2>
				<xsl:apply-templates select="/ectd:ectd/*"/>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="*">
		<ul type="square">
			<li>
				<xsl:value-of select="name()"/>
				<font color="green">
					<xsl:if test="@manufacturer != ''"> [manufacturer: <xsl:value-of select="@manufacturer"/>] </xsl:if>
					<xsl:if test="@substance != ''"> [substance: <xsl:value-of select="@substance"/>] </xsl:if>
					<xsl:if test="@product-name != ''"> [product name: <xsl:value-of select="@product-name"/>] </xsl:if>
					<xsl:if test="@dosageform != ''"> [dosage form: <xsl:value-of select="@dosageform"/>] </xsl:if>
					<xsl:if test="@indication != ''"> [indication: <xsl:value-of select="@indication"/>] </xsl:if>
					<xsl:if test="@excipient != ''"> [excipient: <xsl:value-of select="@excipient"/>] </xsl:if>
				</font>
			</li>
			<xsl:apply-templates/>
		</ul>
	</xsl:template>
	
	<xsl:template match="leaf">
		<ul type="square">
			<li>
				<xsl:element name="a">
					<xsl:attribute name="href"><xsl:value-of select="@xlink:href"/></xsl:attribute>
					<xsl:value-of select="title"/>
				</xsl:element>
				<font color="red">
					[<xsl:value-of select="@operation"/>]
				</font>
			</li>
		</ul>
	</xsl:template>
	
	<xsl:template match="node-extension">
		<ul type="square">
			<li>
				<xsl:value-of select="title"/>
				<xsl:apply-templates select="leaf|node-extension"/>
			</li>
		</ul>	
	</xsl:template>

</xsl:stylesheet>
