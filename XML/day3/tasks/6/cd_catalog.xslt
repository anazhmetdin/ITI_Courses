<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="CATALOG">
    <html> 
        <h1> CDs in descending order according to price</h1>
        <body>
            <table border="1">
                <tr>
                    <th>CD TITLE</th>
                    <th>ARTIST</th>
                    <th>PRICE</th>
                </tr>
                <xsl:for-each select="CD">
                    <xsl:choose>
                        <xsl:when test="PRICE > 10">    
                            <tr>
                                <td style="background-color: red"><xsl:value-of select="TITLE"/></td>
                                <td><xsl:value-of select="ARTIST"/></td>
                                <td><xsl:value-of select="PRICE"/></td>
                            </tr>
                        </xsl:when>
                        <xsl:otherwise> 
                            <tr>
                                <td style="background-color: green"><xsl:value-of select="TITLE"/></td>
                                <td><xsl:value-of select="ARTIST"/></td>
                                <td><xsl:value-of select="PRICE"/></td>
                            </tr>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:for-each>
            </table>
        </body>
    </html>
</xsl:template>
</xsl:stylesheet>