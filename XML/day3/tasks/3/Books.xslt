<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="books">
    <html> 
        <body>
            <table border="1">
                <tr>
                    <th>Number of books with review 3.5</th>
                    <th>Number of books with review 4</th>
                </tr>
                <tr>
                    <td><xsl:value-of select="count(./book[review='3.5'])"/></td>
                    <td><xsl:value-of select="count(./book[review='4'])"/></td>
                </tr>
            </table>
        </body>
    </html>
</xsl:template>
</xsl:stylesheet>