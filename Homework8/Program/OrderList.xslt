<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:template match="@* | node()">
      <html>
        <head>
          <title>Order List</title>
        </head>
        <body>
          <h2>List Of the Orders</h2>
          <table width = "100%" border = "1">
            <thead>
              <tr>
                <th>Order ID</th>
                <th>Client Name</th>
                <th>Client Phone Number</th>
                <th>Product Category</th>
                <th>Order Details</th>
                <th>Total Price</th>
              </tr>
            </thead>
            <tbody>
              <xsl:for-each select="Order">
                <tr>
                  <td>
                    <xsl:value-of select="OrderId"/>
                  </td>
                  <td>
                    <xsl:value-of select="ClientName"/>
                  </td>
                  <td>
                    <xsl:value-of select="ClientPhoneNumber"/>
                  </td>
                  <td>
                    <xsl:value-of select="ProductCategory"/>
                  </td>
                  <td>
                    <xsl:for-each select="ListOfDetails/OrderDetails">
                      Product Name: <xsl:value-of select="ProductName"/>
                      Price Of Product: <xsl:value-of select="PriceOfProduct"/>
                      Number Of Product: <xsl:value-of select="NumOfProduct"/><br/>
                    </xsl:for-each>
                  </td>
                  <td>
                    <xsl:value-of select="TotalPrice"/>
                  </td>
                </tr>
              </xsl:for-each>
            </tbody>
          </table>
        </body>
      </html>
        
    </xsl:template>
</xsl:stylesheet>
