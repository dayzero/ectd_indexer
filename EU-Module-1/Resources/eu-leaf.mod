<!--
In the eCTD File Organisation: "util/dtd/eu-leaf.mod"

Version 1.4
August 2009

Contributors:
   ANSM (Aziz Diop)
   EMA (Laurent Desqueper)
   MEB (C.A. van Belkum)

This is based on ich-ectd-3-2.dtd;

If the ich-ectd.dtd is modularized, this one could be replaced.
Hence, one is certain that the common and EU leaf are the same.
-->

<!-- ============================================================= -->
<!ELEMENT node-extension (title, (leaf | node-extension)+)>
<!ATTLIST node-extension
	ID ID #IMPLIED
	xml:lang CDATA #IMPLIED
>

<!-- ============================================================= -->
<!ENTITY % show-list " (new | replace | embed | other | none) ">
<!ENTITY % actuate-list " (onLoad | onRequest | other | none) ">
<!ENTITY % operation-list " (new | append | replace | delete) ">
<!ENTITY % leaf-element " (title, link-text?) ">
<!ENTITY % leaf-att '
 ID                  ID                #REQUIRED
 application-version CDATA             #IMPLIED
 version             CDATA             #IMPLIED
 font-library        CDATA             #IMPLIED
 operation           %operation-list;  #REQUIRED
 modified-file       CDATA             #IMPLIED
 checksum            CDATA             #REQUIRED
 checksum-type       CDATA             #REQUIRED
 keywords            CDATA             #IMPLIED
 xmlns:xlink         CDATA             #FIXED    "http://www.w3c.org/1999/xlink"
 xlink:type          CDATA             #FIXED    "simple"
 xlink:role          CDATA             #IMPLIED
 xlink:href          CDATA             #IMPLIED
 xlink:show          %show-list;       #IMPLIED
 xlink:actuate       %actuate-list;    #IMPLIED
 xml:lang            CDATA             #IMPLIED
 '>

<!ELEMENT leaf %leaf-element;>
<!ATTLIST leaf
	%leaf-att; 
>
<!ELEMENT title (#PCDATA)>
<!ELEMENT link-text (#PCDATA | xref)*>

<!ELEMENT xref EMPTY>
<!ATTLIST xref
	ID ID #REQUIRED
	xmlns:xlink CDATA #FIXED "http://www.w3c.org/1999/xlink"
	xlink:type CDATA #FIXED "simple"
	xlink:role CDATA #IMPLIED
	xlink:title CDATA #REQUIRED
	xlink:href CDATA #REQUIRED
	xlink:show %show-list; #IMPLIED
	xlink:actuate %actuate-list; #IMPLIED
>

<!-- +++ -->
