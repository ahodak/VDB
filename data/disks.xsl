<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/TR/WD-xsl" version="1.0">
	<xsl:template match="/">
		<html>
			<head>
				<title>Video Disk Base</title>
				<style>
					body {font-faminy: "Tahoma, Arial, Helvetica"; margin: 0em 1em 0em 1em;}
					td {font-family: "Tahoma, Arial, Helvetica"; font-size: 10pt}
					td.bold {font-weight: bold; vertical-align: top}
					td.descr {text-align: justify}
					h1 {text-align: center; color: #DF0029}
					div {padding: 5px 10px 5px 10px;}
				</style>
				<script language="jscript">
					function checkExpand( ) {
						if ("" != event.srcElement.id) {
							var ch = event.srcElement.id + "Child";
							var el = document.all[ch];
							if (null != el) {
								el.style.display = "none" == el.style.display ? "" : "none";
								if (el.style.display != "none")
									event.returnValue=false;
							}
						}
					}
				</script>
			</head>
			<body onClick="checkExpand()">
				<h1>Video Disk Base</h1>

			<xsl:for-each select="Data/Entries/Entry">
				<table Border="0" CellPadding="0" CellSpacing="0" Width="100%">
					<tr>
						<td><a><xsl:attribute name="id">CD<xsl:eval>sectionNum(this)</xsl:eval></xsl:attribute>
							<xsl:attribute name="href">#</xsl:attribute>
    						<xsl:value-of select="NameRus"/></a></td>
					</tr>
					<tr><td>
						<div><xsl:attribute name="id">CD<xsl:eval>sectionNum(this)</xsl:eval>Child</xsl:attribute>
							<xsl:attribute name="Style">display: none</xsl:attribute>
							<table border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr><td class="bold" width="110">Название:</td><td><xsl:value-of select="NameEng"/></td></tr>
								<tr><td class="bold">Жанр:</td><td><xsl:value-of select="Genre"/></td></tr>
								<tr><td class="bold">Компания:</td><td><xsl:value-of select="Company"/></td></tr>
								<tr><td class="bold">Год:</td><td><xsl:value-of select="Year"/></td></tr>
								<tr><td class="bold">Режиссёр:</td><td><xsl:value-of select="Director"/></td></tr>
								<tr><td class="bold">В ролях:</td><td><xsl:value-of select="Stars"/></td></tr>
								<tr><td class="bold">Длительность:</td><td><xsl:value-of select="Length"/></td></tr>
								<tr><td class="bold">Размер:</td><td><xsl:value-of select="Size"/></td></tr>
								<tr><td class="bold">Дата:</td><td><xsl:value-of select="Date"/></td></tr>
								<tr><td class="bold">Описание:</td><td class="descr"><pre><xsl:value-of select="Description"/></pre><p></p></td></tr>
							</table>
						</div>
						</td>
					</tr>
				</table>
			</xsl:for-each>
			</body>
		</html>
		<xsl:apply-templates/>
	</xsl:template>
	
	<!-- Scripts -->
   
	<xsl:script>
		function sectionNum(e) {
			if (e)
			{
				return sectionNum(e.selectSingleNode("ancestor(CD)")) +
					formatIndex(childNumber(e), "1");
			}
			else
			{
				return "";
			}
		}
    
		var prodCount = 1;
		function prodNum() {
			return formatIndex(prodCount++, "1");
		}

	</xsl:script>
</xsl:stylesheet>
