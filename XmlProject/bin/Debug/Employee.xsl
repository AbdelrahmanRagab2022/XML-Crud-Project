<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions">
<xsl:template match="/">
<html>
	<head>
		<title></title>
	</head>
	<body>
	<table border="1">
	<thead>
		<tr bgcolor="#9acd32">
			<th>Name</th>
			<th>Phone</th>
			<th>Email</th>
			<th>Region</th>
			<th>city</th>
			<th>Country</th>

		</tr>
	</thead>
	<tbody>
	<xsl:for-each select="employees/emp">
		<tr>
			<td><xsl:value-of select="name"/></td>
			<td><xsl:value-of select="phones/phone"/></td>
			<td><xsl:value-of select="email"/></td>
			<td><xsl:value-of select="addresses/region"/></td>
			<td><xsl:value-of select="addresses/city"/></td>
			<td><xsl:value-of select="addresses/country"/></td>
		</tr>
	</xsl:for-each>
	</tbody>	
	</table>
	</body>
</html>
</xsl:template>
</xsl:stylesheet>
