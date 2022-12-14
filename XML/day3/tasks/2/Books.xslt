<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="books">
    <html> 
        <body>
            <h1>A list of books</h1>
            <table border="1">
                <tr>
                    <th>Index</th>
                    <th>Author</th>
                    <th>Title</th>
                    <th>Price</th>
                </tr>
                <xsl:for-each select="book">
                    <tr>
                        <xsl:variable name="position" select="position()"/>
                        <td><xsl:value-of select="$position"/></td>
                        <td><xsl:value-of select="author"/></td>
                        <td><xsl:value-of select="title"/></td>
                        <td><xsl:value-of select="price"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
    </html>
</xsl:template>
</xsl:stylesheet>